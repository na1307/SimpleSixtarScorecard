﻿using SimpleSixtarScorecard.Properties;

namespace SimpleSixtarScorecard;

internal sealed partial class EditControl : UserControl {
    private readonly Song song;

    public EditControl(Song song) {
        InitializeComponent();
        this.song = song;

        rbInit();

        // Event registration
        foreach (var srb in groupBoxSolar.Controls.Cast<RadioButton>()) {
            srb.CheckedChanged += Srb_CheckedChanged;
        }

        foreach (var lrb in groupBoxLunar.Controls.Cast<RadioButton>()) {
            lrb.CheckedChanged += Lrb_CheckedChanged;
        }
    }

    // Return mode and difficulty based on which button was clicked
    private (Mode Mode, Difficulty Difficulty) SelectedModeAndDifficulty {
        get {
            if (radioButtonSComet.Checked) {
                return (Mode.Solar, Difficulty.Comet);
            }

            if (radioButtonSNova.Checked) {
                return (Mode.Solar, Difficulty.Nova);
            }

            if (radioButtonSSupernova.Checked) {
                return (Mode.Solar, Difficulty.Supernova);
            }

            if (radioButtonSQuasar.Checked) {
                return (Mode.Solar, Difficulty.Quasar);
            }

            if (radioButtonSStarlight.Checked) {
                return (Mode.Solar, Difficulty.Starlight);
            }

            if (radioButtonLComet.Checked) {
                return (Mode.Lunar, Difficulty.Comet);
            }

            if (radioButtonLNova.Checked) {
                return (Mode.Lunar, Difficulty.Nova);
            }

            if (radioButtonLSupernova.Checked) {
                return (Mode.Lunar, Difficulty.Supernova);
            }

            if (radioButtonLQuasar.Checked) {
                return (Mode.Lunar, Difficulty.Quasar);
            }

            if (radioButtonLStarlight.Checked) {
                return (Mode.Lunar, Difficulty.Starlight);
            }

            throw new InvalidOperationException();
        }
    }

    private void rbInit() {
        // Solar
        set(radioButtonSComet, Mode.Solar, Difficulty.Comet);
        set(radioButtonSNova, Mode.Solar, Difficulty.Nova);
        set(radioButtonSSupernova, Mode.Solar, Difficulty.Supernova);
        set(radioButtonSQuasar, Mode.Solar, Difficulty.Quasar);
        set(radioButtonSStarlight, Mode.Solar, Difficulty.Starlight);

        // Lunar
        set(radioButtonLComet, Mode.Lunar, Difficulty.Comet);
        set(radioButtonLNova, Mode.Lunar, Difficulty.Nova);
        set(radioButtonLSupernova, Mode.Lunar, Difficulty.Supernova);
        set(radioButtonLQuasar, Mode.Lunar, Difficulty.Quasar);
        set(radioButtonLStarlight, Mode.Lunar, Difficulty.Starlight);

        void set(RadioButton button, Mode mode, Difficulty difficulty) {
            var difficultyLevel = getDifficulty();
            button.Text = getDifficultyText();

            // If difficulty is not 0 (== if a chart exists)
            if (difficultyLevel != 0) {
                // Difficulty
                button.Text += " - " + difficultyLevel.ToString("D2");
                var result = Profile.Instance.Results.SingleOrDefault(r => r.SongId == song.Id && r.Mode == mode && r.Difficulty == difficulty);

                // If results exist
                if (result is not null) {
                    // Rank
                    var rank = result.Score switch {
                        1000000 => "PB",
                        >= 980000 => "SS",
                        >= 950000 => "S",
                        >= 900000 => "A+",
                        >= 850000 => "A",
                        >= 800000 => "B+",
                        >= 700000 => "B",
                        _ => "F",
                    };

                    // Score
                    button.Text += $"{Environment.NewLine}{result.Score} ({rank}){(result.FullCombo ? ", FC" : string.Empty)}";
                }
            } else {
                // Disable button if there's no chart
                button.Enabled = false;
            }

            int getDifficulty() {
                var diffObj = mode switch {
                    Mode.Solar => song.DifficultySolar,
                    Mode.Lunar => song.DifficultyLunar,
                    _ => throw new InvalidOperationException(),
                };

                return difficulty switch {
                    Difficulty.Comet => diffObj.Comet,
                    Difficulty.Nova => diffObj.Nova,
                    Difficulty.Supernova => diffObj.Supernova,
                    Difficulty.Quasar => diffObj.Quasar,
                    Difficulty.Starlight => diffObj.Starlight,
                    _ => throw new InvalidOperationException(),
                };
            }

            string getDifficultyText() => difficulty switch {
                Difficulty.Comet => Strings.Comet,
                Difficulty.Nova => Strings.Nova,
                Difficulty.Supernova => Strings.Supernova,
                Difficulty.Quasar => Strings.Quasar,
                Difficulty.Starlight => Strings.Starlight,
                _ => throw new InvalidOperationException(),
            };
        }
    }

    private void button1_Click(object sender, EventArgs e) {
        var (mode, diff) = SelectedModeAndDifficulty;
        var resultIndex = Profile.Instance.Results.Select((v, i) => new { v, i }).FirstOrDefault(a => a.v.SongId == song.Id && a.v.Mode == mode && a.v.Difficulty == diff)?.i ?? -1;

        // If there aren't any registered results
        if (resultIndex == -1) {
            // Register new results
            var score = int.Parse(textBoxScore.Text);

            // Score must be at least 1 to be registered
            if (score != 0) {
                Profile.Instance.Results.Add(new Result {
                    SongId = song.Id,
                    Mode = mode,
                    Difficulty = diff,
                    Score = score,
                    FullCombo = checkBoxFullCombo.Checked
                });
            }
        } else {
            // Edit pre-existing results
            Profile.Instance.Results[resultIndex].Score = int.Parse(textBoxScore.Text);
            Profile.Instance.Results[resultIndex].FullCombo = checkBoxFullCombo.Checked;
        }

        rbInit();
    }

    private void checkedChanged(RadioButton button, GroupBox box, Mode mode) {
        // Event fires upon clicking a specific button
        if (button.Checked) {
            // Enable score input field and FC checkbox
            label3.Enabled = true;
            textBoxScore.Enabled = true;
            checkBoxFullCombo.Enabled = true;
            button1.Enabled = true;

            // Uncheck other mode/difficulty combos' buttons
            foreach (var rb in box.Controls.Cast<RadioButton>()) {
                rb.Checked = false;
            }

            // Score input field and FC checkbox
            var result = Profile.Instance.Results.SingleOrDefault(r => r.SongId == song.Id && r.Mode == mode && r.Difficulty == SelectedModeAndDifficulty.Difficulty);
            textBoxScore.Text = result?.Score.ToString() ?? "0";
            checkBoxFullCombo.Checked = result?.FullCombo ?? false;
        }
    }

    private void Srb_CheckedChanged(object? sender, EventArgs e) => checkedChanged((RadioButton)sender!, groupBoxLunar, Mode.Solar);

    private void Lrb_CheckedChanged(object? sender, EventArgs e) => checkedChanged((RadioButton)sender!, groupBoxSolar, Mode.Lunar);

    private void textBoxScore_Leave(object sender, EventArgs e) {
        // Score must be a numeric value between 0 and 1,000,000 to be accepted; otherwise throw an error
        if (!(int.TryParse(textBoxScore.Text, out var number) && (number is >= 0 and <= 1000000))) {
            MessageBox.Show(Strings.InputScoreIsInvalid);
            textBoxScore.Focus();
        }
    }
}
