using Json.Schema;
using System.Reflection;
using System.Text.Json;

namespace SimpleSixtarScorecard;

internal static class Program {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static async Task Main() {
        try {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Verify songdata.json
#if NETCOREAPP3_0_OR_GREATER
            await
#endif
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SimpleSixtarScorecard.songdata.schema.json")) {
                if (stream == null) {
                    ErrMsg("Song data schema not found!");
                    return;
                }

#if NETCOREAPP3_0_OR_GREATER
                await
#endif
                using FileStream songdata = new("songdata.json", FileMode.Open, FileAccess.Read);
                using var json = await JsonDocument.ParseAsync(songdata);

                if (!(await JsonSchema.FromStream(stream)).Evaluate(json).IsValid) {
                    ErrMsg("Song data is invalid!");
                    return;
                }
            }

            // Profile creation
            if (!File.Exists(Profile.ProfileFile)) {
                using ProfileNameDialog dialog = new(true);

                if (dialog.ShowDialog() == DialogResult.OK) {
#if NETCOREAPP3_0_OR_GREATER
                    await
#endif
                    using FileStream fs = new(Profile.ProfileFile, FileMode.CreateNew, FileAccess.Write);
                    await using Utf8JsonWriter writer = new(fs);

                    writer.WriteStartObject();
                    writer.WriteString(Profile.UserNamePropertyName, dialog.UserName.Trim());
                    writer.WriteStartArray(Profile.ResultsPropertyName);
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                } else {
                    return;
                }
            }

            Application.Run(new MainForm());
        } catch (Exception e) {
            ErrMsg(e.ToString());
        }
    }
}
