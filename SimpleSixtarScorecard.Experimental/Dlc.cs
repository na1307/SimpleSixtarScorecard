using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

[JsonConverter(typeof(JsonStringEnumConverter<Dlc>))]
public enum Dlc {
    All,
    Base,
    FlowerAndDestiny,
    Touhou01,
    LuminousAndDarkness,
    Pocotone,
    YomohasPlanet,
    Wacca,
    Oshiribeat,
    Dystopia,
    UnitedNetwalk,
    Kalpa
}
