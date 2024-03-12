using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

public sealed record class Result {
    public const string SongIdPropertyName = "songid";
    public const string ModePropertyName = "mode";
    public const string DifficultyPropertyName = "difficulty";
    public const string ScorePropertyName = "score";
    public const string FullComboPropertyName = "fullcombo";

    [JsonPropertyName(SongIdPropertyName)]
    public required string SongId { get; init; }

    [JsonPropertyName(ModePropertyName)]
    public required Mode Mode { get; init; }

    [JsonPropertyName(DifficultyPropertyName)]
    public required Difficulty Difficulty { get; init; }

    [JsonPropertyName(ScorePropertyName)]
    public int Score { get; set; }

    [JsonPropertyName(FullComboPropertyName)]
    public bool FullCombo { get; set; }
}
