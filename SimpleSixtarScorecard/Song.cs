using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

public sealed record class Song(
    [property: JsonPropertyName("order_number")]
    int OrderNumber,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("composer")]
    string Composer,
    [property: JsonPropertyName("dlc")] Dlc Dlc,
    [property: JsonPropertyName("category")]
    Category Category,
    [property: JsonPropertyName("solar_comet")]
    int? SolarComet,
    [property: JsonPropertyName("solar_nova")]
    int? SolarNova,
    [property: JsonPropertyName("solar_supernova")]
    int? SolarSupernova,
    [property: JsonPropertyName("solar_quasar")]
    int? SolarQuasar,
    [property: JsonPropertyName("solar_starlight")]
    int? SolarStarlight,
    [property: JsonPropertyName("lunar_comet")]
    int? LunarComet,
    [property: JsonPropertyName("lunar_nova")]
    int? LunarNova,
    [property: JsonPropertyName("lunar_supernova")]
    int? LunarSupernova,
    [property: JsonPropertyName("lunar_quasar")]
    int? LunarQuasar,
    [property: JsonPropertyName("lunar_starlight")]
    int? LunarStarlight);
