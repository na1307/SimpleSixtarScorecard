using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

[JsonConverter(typeof(JsonStringEnumConverter<Mode>))]
public enum Mode {
    Lunar,
    Solar
}
