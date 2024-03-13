using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

public sealed record class Song(
    [property: JsonPropertyName(Song.IdPropertyName)] string Id,
    [property: JsonPropertyName(Song.TitlePropertyName)] string Title,
    [property: JsonPropertyName(Song.ComposerPropertyName)] string Composer,
    [property: JsonPropertyName(Song.DifficultySolarPropertyName)] DifficultyObject DifficultySolar,
    [property: JsonPropertyName(Song.DifficultyLunarPropertyName)] DifficultyObject DifficultyLunar) {
    public const string IdPropertyName = "id";
    public const string TitlePropertyName = "title";
    public const string ComposerPropertyName = "composer";
    public const string DifficultySolarPropertyName = "difficultys";
    public const string DifficultyLunarPropertyName = "difficultyl";

    public static Song[] SongList { get; } = JsonSerializer.Deserialize<Song[]>(File.ReadAllBytes("songdata.json"))!;

    public int SolarQuasar => DifficultySolar.Quasar;
    public int LunarQuasar => DifficultyLunar.Quasar;
}
