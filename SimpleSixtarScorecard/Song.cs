using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

public sealed record class Song(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("composer")] string Composer,
    [property: JsonPropertyName("dlc"), JsonConverter(typeof(JsonStringEnumConverter))] Dlc Dlc,
    [property: JsonPropertyName("category"), JsonConverter(typeof(JsonStringEnumConverter))] Category Category,
    [property: JsonPropertyName("difficultys")] DifficultyObject DifficultySolar,
    [property: JsonPropertyName("difficultyl")] DifficultyObject DifficultyLunar) {

    public static Song[] SongList { get; } = JsonSerializer.Deserialize<Song[]>(File.ReadAllBytes("songdata.json"))!;

    public int SolarQuasar => DifficultySolar.Quasar;
    public int LunarQuasar => DifficultyLunar.Quasar;
    public string DlcName => Dlc.ToName();
}
