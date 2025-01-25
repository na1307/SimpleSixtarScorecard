using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

internal sealed record class SongDifficulty(
    [property: JsonPropertyName("comet")] int Comet,
    [property: JsonPropertyName("nova")] int Nova,
    [property: JsonPropertyName("supernova")] int Supernova,
    [property: JsonPropertyName("quasar")] int Quasar,
    [property: JsonPropertyName("starlight")] int Starlight);
