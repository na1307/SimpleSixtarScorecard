namespace SimpleSixtarScorecard;

public sealed record class Song(
    int OrderNumber,
    string Id,
    string Title,
    string Composer,
    Dlc Dlc,
    Category Category,
    int? LunarComet,
    int? LunarNova,
    int? LunarSupernova,
    int? LunarQuasar,
    int? LunarStarlight,
    int? SolarComet,
    int? SolarNova,
    int? SolarSupernova,
    int? SolarQuasar,
    int? SolarStarlight);
