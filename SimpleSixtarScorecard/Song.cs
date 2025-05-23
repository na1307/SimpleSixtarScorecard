﻿using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

internal sealed record class Song(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("composer")] string Composer,
    [property: JsonPropertyName("dlc")] Dlc Dlc,
    [property: JsonPropertyName("category")] Category Category,
    [property: JsonPropertyName("difficultys")] SongDifficulty DifficultySolar,
    [property: JsonPropertyName("difficultyl")] SongDifficulty DifficultyLunar) {
    public static ReadOnlyCollection<Song> SongList { get; } = new(JsonSerializer.Deserialize<Song[]>(File.ReadAllBytes("songdata.json"))!);

    public int SolarQuasar => DifficultySolar.Quasar;

    public int LunarQuasar => DifficultyLunar.Quasar;

    public string DlcName => Dlc.ToName();
}
