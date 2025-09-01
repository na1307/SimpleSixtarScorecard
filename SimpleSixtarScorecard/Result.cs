using System.ComponentModel;

namespace SimpleSixtarScorecard;

internal sealed record class Result : INotifyPropertyChanged {
    public const string SongIdPropertyName = "songid";
    public const string ModePropertyName = "mode";
    public const string DifficultyPropertyName = "difficulty";
    public const string ScorePropertyName = "score";
    public const string FullComboPropertyName = "fullcombo";

    public event PropertyChangedEventHandler? PropertyChanged;

    public required string SongId { get; init; }

    public required Mode Mode { get; init; }

    public required DifficultyType Difficulty { get; init; }

    public int Score {
        get;
        set {
            if (field != value) {
                field = value;
                PropertyChanged?.Invoke(this, new(nameof(Score)));
            }
        }
    }

    public bool FullCombo {
        get;
        set {
            if (field != value) {
                field = value;
                PropertyChanged?.Invoke(this, new(nameof(FullCombo)));
            }
        }
    }
}
