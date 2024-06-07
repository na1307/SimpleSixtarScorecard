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
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        // Verify songdata.json
        await using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SimpleSixtarScorecard.songdata.schema.json")) {
            if (stream == null) {
                ErrMsg("Song data schema not found!");
                return;
            }

            await using FileStream songdata = new("songdata.json", FileMode.Open, FileAccess.Read);
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
                await using FileStream fs = new(Profile.ProfileFile, FileMode.CreateNew, FileAccess.Write);
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

        // Save profile when exited
        Application.ApplicationExit += Application_ApplicationExit;

        Application.Run(new MainForm());
    }

    private static void Application_ApplicationExit(object? sender, EventArgs e) => Profile.Instance.SaveProfile();
}
