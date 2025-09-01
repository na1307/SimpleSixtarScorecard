////#define USE_LOCAL

using Json.Schema;
#if NET48
using System.Net.Http;
#endif
using System.Reflection;
using System.Text.Json;

namespace SimpleSixtarScorecard;

internal static class Program {
    private static JsonDocument? json;

    public static JsonDocument Json => json!;

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

                using HttpClient hc = new();
                Stream? songdataStream = null;
#if !USE_LOCAL
                if (await IsInternetConnected(hc)) {
                    try {
                        const string url
                            = "https://raw.githubusercontent.com/na1307/SimpleSixtarScorecard/refs/heads/main/SimpleSixtarScorecard.Legacy/songdata.json";

                        songdataStream = await hc.GetStreamAsync(new Uri(url));
                    } catch (HttpRequestException) {
                        // Do nothing
                    }
                }
#endif
                songdataStream ??= new FileStream("songdata.json", FileMode.Open, FileAccess.Read);
                var jsonSchema = await JsonSchema.FromStream(stream);

                using (songdataStream) {
                    json = await JsonDocument.ParseAsync(songdataStream);

                    if (!jsonSchema.Evaluate(json).IsValid) {
                        ErrMsg("Song data is invalid!");
                        return;
                    }
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
#if !DEBUG
            ErrMsg(e.ToString());
#else
            throw;
#endif
        }
    }

    private static async Task<bool> IsInternetConnected(HttpClient hc) {
        try {
            using CancellationTokenSource cts = new(TimeSpan.FromSeconds(5));

            await hc.GetAsync(new Uri("http://www.gstatic.com/generate_204"), cts.Token);

            return true;
        } catch {
            return false;
        }
    }
}
