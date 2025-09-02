using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

internal sealed record class Result(
    [property: JsonPropertyName("songid")] string SongId,
    [property: JsonPropertyName("mode")] Mode Mode,
    [property: JsonPropertyName("difficulty")]
    DifficultyType Difficulty,
    [property: JsonPropertyName("score")] int Score,
    [property: JsonPropertyName("fullcombo")]
    bool FullCombo);
