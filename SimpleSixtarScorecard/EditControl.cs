using SimpleSixtarScorecard.Properties;

namespace SimpleSixtarScorecard;

public partial class EditControl : UserControl {
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
            var diff = getDiff();
            button.Text = getDiffText();

            // If difficulty is not 0 (== if a chart exists)
            if (diff != 0) {
                // Difficulty
                button.Text += " - " + diff.ToString("D2");
                var result = Profile.Instance.Results.Find(r => r.SongId == song.Id && r.Mode == mode && r.Difficulty == difficulty);

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

            int getDiff() {
                var diffObj = mode switch {
                    Mode.Solar => song.DifficultySolar,
                    Mode.Lunar => song.DifficultyLunar,
                    _ => throw new NotImplementedException(),
                };

                return difficulty switch {
                    Difficulty.Comet => diffObj.Comet,
                    Difficulty.Nova => diffObj.Nova,
                    Difficulty.Supernova => diffObj.Supernova,
                    Difficulty.Quasar => diffObj.Quasar,
                    Difficulty.Starlight => diffObj.Starlight,
                    _ => throw new NotImplementedException(),
                };
            }

            string getDiffText() {
                return difficulty switch {
                    Difficulty.Comet => Strings.Comet,
                    Difficulty.Nova => Strings.Nova,
                    Difficulty.Supernova => Strings.Supernova,
                    Difficulty.Quasar => Strings.Quasar,
                    Difficulty.Starlight => Strings.Starlight,
                    _ => throw new NotImplementedException(),
                };
            }
        }
    }

    private void button1_Click(object sender, EventArgs e) {
        var (mode, diff) = getModeAndDiff();
        var resultIndex = Profile.Instance.Results.FindIndex(i => i.SongId == song.Id && i.Mode == mode && i.Difficulty == diff);

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

    // Return mode and difficulty based on which button was clicked
    private (Mode mode, Difficulty diff) getModeAndDiff() {
        if (radioButtonSComet.Checked) {
            return (Mode.Solar, Difficulty.Comet);
        } else if (radioButtonSNova.Checked) {
            return (Mode.Solar, Difficulty.Nova);
        } else if (radioButtonSSupernova.Checked) {
            return (Mode.Solar, Difficulty.Supernova);
        } else if (radioButtonSQuasar.Checked) {
            return (Mode.Solar, Difficulty.Quasar);
        } else if (radioButtonSStarlight.Checked) {
            return (Mode.Solar, Difficulty.Starlight);
        } else if (radioButtonLComet.Checked) {
            return (Mode.Lunar, Difficulty.Comet);
        } else if (radioButtonLNova.Checked) {
            return (Mode.Lunar, Difficulty.Nova);
        } else if (radioButtonLSupernova.Checked) {
            return (Mode.Lunar, Difficulty.Supernova);
        } else if (radioButtonLQuasar.Checked) {
            return (Mode.Lunar, Difficulty.Quasar);
        } else if (radioButtonLStarlight.Checked) {
            return (Mode.Lunar, Difficulty.Starlight);
        } else {
            throw new NotImplementedException();
        }
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
            var result = Profile.Instance.Results.Find(r => r.SongId == song.Id && r.Mode == mode && r.Difficulty == getModeAndDiff().diff);
            textBoxScore.Text = result?.Score.ToString() ?? "0";
            checkBoxFullCombo.Checked = result?.FullCombo ?? false;
        }
    }

    private void Srb_CheckedChanged(object? sender, EventArgs e) => checkedChanged((RadioButton)sender!, groupBoxLunar, Mode.Solar);
    private void Lrb_CheckedChanged(object? sender, EventArgs e) => checkedChanged((RadioButton)sender!, groupBoxSolar, Mode.Lunar);

    private void textBoxScore_Leave(object sender, EventArgs e) {
        // Score must be a numeric value between 0 and 1,000,000 to be accepted; otherwise throw an error
        if (!(int.TryParse(textBoxScore.Text, out var number) && (number is >= 0 and <= 1000000))) {
            MessageBox.Show(Properties.Strings.InputScoreIsInvalid);
            textBoxScore.Focus();
        }
    }
}
