using System.ComponentModel;

namespace SimpleSixtarScorecard;

internal sealed record class Result : INotifyPropertyChanged {
    public const string SongIdPropertyName = "songid";
    public const string ModePropertyName = "mode";
    public const string DifficultyPropertyName = "difficulty";
    public const string ScorePropertyName = "score";
    public const string FullComboPropertyName = "fullcombo";
    private int scoreField;
    private bool fullComboField;

    public event PropertyChangedEventHandler? PropertyChanged;

    public required string SongId { get; init; }

    public required Mode Mode { get; init; }

    public required Difficulty Difficulty { get; init; }

    public int Score {
        get => scoreField;
        set {
            if (scoreField != value) {
                scoreField = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Score)));
            }
        }
    }

    public bool FullCombo {
        get => fullComboField;
        set {
            if (fullComboField != value) {
                fullComboField = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullCombo)));
            }
        }
    }
}
