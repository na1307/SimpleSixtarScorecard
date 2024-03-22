using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

public sealed record class DifficultyObject(
    [property: JsonPropertyName(DifficultyObject.CometPropertyName)] int Comet,
    [property: JsonPropertyName(DifficultyObject.NovaPropertyName)] int Nova,
    [property: JsonPropertyName(DifficultyObject.SupernovaPropertyName)] int Supernova,
    [property: JsonPropertyName(DifficultyObject.QuasarPropertyName)] int Quasar,
    [property: JsonPropertyName(DifficultyObject.StarlightPropertyName)] int Starlight) {
    public const string CometPropertyName = "comet";
    public const string NovaPropertyName = "nova";
    public const string SupernovaPropertyName = "supernova";
    public const string QuasarPropertyName = "quasar";
    public const string StarlightPropertyName = "starlight";
}
