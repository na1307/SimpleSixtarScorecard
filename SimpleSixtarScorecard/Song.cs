using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

public sealed record class Song(
    [property: JsonPropertyName(Song.IdPropertyName)] string Id,
    [property: JsonPropertyName(Song.TitlePropertyName)] string Title,
    [property: JsonPropertyName(Song.ComposerPropertyName)] string Composer,
    [property: JsonPropertyName(Song.DlcPropertyName), JsonConverter(typeof(JsonStringEnumConverter))] Dlc Dlc,
    [property: JsonPropertyName(Song.CategoryPropertyName), JsonConverter(typeof(JsonStringEnumConverter))] Category Category,
    [property: JsonPropertyName(Song.DifficultySolarPropertyName)] DifficultyObject DifficultySolar,
    [property: JsonPropertyName(Song.DifficultyLunarPropertyName)] DifficultyObject DifficultyLunar) {
    public const string IdPropertyName = "id";
    public const string TitlePropertyName = "title";
    public const string ComposerPropertyName = "composer";
    public const string DlcPropertyName = "dlc";
    public const string CategoryPropertyName = "category";
    public const string DifficultySolarPropertyName = "difficultys";
    public const string DifficultyLunarPropertyName = "difficultyl";

    public static Song[] SongList { get; } = JsonSerializer.Deserialize<Song[]>(File.ReadAllBytes("songdata.json"))!;

    public int SolarQuasar => DifficultySolar.Quasar;
    public int LunarQuasar => DifficultyLunar.Quasar;
    public string DlcName => Dlc switch {
        Dlc.Base => "본편",
        Dlc.FlowerAndDestiny => "Flower & Destiny",
        Dlc.Touhou01 => "동방 프로젝트 팩 01",
        Dlc.LuminousAndDarkness => "Luminous & Darkness",
        Dlc.Pocotone => "포코톤",
        Dlc.YomohasPlanet => "Yomoha's Planet",
        Dlc.Wacca => "WACCA",
        Dlc.Oshiribeat => "오시리비트",
        Dlc.Dystopia => "디스토피아",
        _ => throw new NotImplementedException(),
    };
}
