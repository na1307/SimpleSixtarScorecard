namespace SimpleSixtarScorecard;

public sealed record class Song(
    string Id,
    string Title,
    string Composer,
    Dlc Dlc,
    Category Category,
    int? SolarComet,
    int? SolarNova,
    int? SolarSupernova,
    int? SolarQuasar,
    int? SolarStarlight,
    int? LunarComet,
    int? LunarNova,
    int? LunarSupernova,
    int? LunarQuasar,
    int? LunarStarlight);
