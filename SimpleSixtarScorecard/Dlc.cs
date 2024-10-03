using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

[JsonConverter(typeof(JsonStringEnumConverter<Dlc>))]
public enum Dlc {
    Base = 1,
    FlowerAndDestiny,
    Touhou01,
    LuminousAndDarkness,
    Pocotone,
    YomohasPlanet,
    Wacca,
    Oshiribeat,
    Dystopia,
    UnitedNetwalk
}
