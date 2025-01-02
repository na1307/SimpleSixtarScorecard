using System.ComponentModel;

namespace SimpleSixtarScorecard;

public sealed record class Result : INotifyPropertyChanged {
    public const string SongIdPropertyName = "songid";
    public const string ModePropertyName = "mode";
    public const string DifficultyPropertyName = "difficulty";
    public const string ScorePropertyName = "score";
    public const string FullComboPropertyName = "fullcombo";
    private int score;
    private bool fullCombo;

    public event PropertyChangedEventHandler? PropertyChanged;

    public required string SongId { get; init; }

    public required Mode Mode { get; init; }

    public required Difficulty Difficulty { get; init; }

    public int Score {
        get => score;
        set {
            if (score != value) {
                score = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Score)));
            }
        }
    }

    public bool FullCombo {
        get => fullCombo;
        set {
            if (fullCombo != value) {
                fullCombo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullCombo)));
            }
        }
    }
}
