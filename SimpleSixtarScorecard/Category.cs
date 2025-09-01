using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

[JsonConverter(typeof(JsonStringEnumConverter<Category>))]
public enum Category {
    All,
    Original,
    Variety,
    Remix,
    Touhou,
    Collab
}
