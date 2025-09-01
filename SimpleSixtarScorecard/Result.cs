namespace SimpleSixtarScorecard;

internal sealed record class Result(string SongId, Mode Mode, DifficultyType Difficulty, int Score, bool FullCombo);
