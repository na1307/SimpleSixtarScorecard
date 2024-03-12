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

        // songdata.json 검증
        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SimpleSixtarScorecard.songdata.schema.json")) {
            if (stream == null) {
                ErrMsg("schema not found!");
                return;
            }

            using FileStream songdata = new("songdata.json", FileMode.Open, FileAccess.Read);
            using var json = JsonDocument.Parse(songdata);

            if (!(await JsonSchema.FromStream(stream)).Evaluate(json).IsValid) {
                ErrMsg("songdata json is invalid!");
                return;
            }
        }

        // 프로필 생성 과정
        if (!File.Exists(Profile.ProfileFile)) {
            using ProfileNameDialog dialog = new(true);

            if (dialog.ShowDialog() == DialogResult.OK) {
                using FileStream fs = new(Profile.ProfileFile, FileMode.CreateNew, FileAccess.Write);
                using Utf8JsonWriter writer = new(fs);

                writer.WriteStartObject();
                writer.WriteString(Profile.UserNamePropertyName, dialog.UserName.Trim());
                writer.WriteStartArray(Profile.ResultsPropertyName);
                writer.WriteEndArray();
                writer.WriteEndObject();
            } else {
                return;
            }
        }

        // 종료될 때 프로필 저장
        Application.ApplicationExit += Application_ApplicationExit;

        Application.Run(new FormMain());
    }

    private static void Application_ApplicationExit(object? sender, EventArgs e) => Profile.Instance.SaveProfile();
}
