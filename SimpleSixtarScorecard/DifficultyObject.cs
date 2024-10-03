using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

public sealed record class DifficultyObject(
    [property: JsonPropertyName("comet")] int Comet,
    [property: JsonPropertyName("nova")] int Nova,
    [property: JsonPropertyName("supernova")] int Supernova,
    [property: JsonPropertyName("quasar")] int Quasar,
    [property: JsonPropertyName("starlight")] int Starlight);
