using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

[JsonConverter(typeof(JsonStringEnumConverter<DifficultyType>))]
public enum DifficultyType {
    Comet,
    Nova,
    Supernova,
    Quasar,
    Starlight
}
