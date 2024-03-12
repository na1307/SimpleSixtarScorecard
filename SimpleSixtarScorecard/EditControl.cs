namespace SimpleSixtarScorecard;

public partial class EditControl : UserControl {
    private readonly Song song;
    private readonly Dictionary<RadioButton, string> initialString = [];

    public EditControl(Song song) {
        InitializeComponent();
        this.song = song;

        // 솔라
        initialString[radioButtonSComet] = radioButtonSComet.Text;
        initialString[radioButtonSNova] = radioButtonSNova.Text;
        initialString[radioButtonSSuperNova] = radioButtonSSuperNova.Text;
        initialString[radioButtonSQuasar] = radioButtonSQuasar.Text;
        initialString[radioButtonSStarlight] = radioButtonSStarlight.Text;

        // 루나
        initialString[radioButtonLComet] = radioButtonLComet.Text;
        initialString[radioButtonLNova] = radioButtonLNova.Text;
        initialString[radioButtonLSuperNova] = radioButtonLSuperNova.Text;
        initialString[radioButtonLQuasar] = radioButtonLQuasar.Text;
        initialString[radioButtonLStarlight] = radioButtonLStarlight.Text;

        rbInit();

        // 이벤트 등록
        foreach (var srb in groupBoxSolar.Controls.Cast<RadioButton>()) {
            srb.CheckedChanged += Srb_CheckedChanged;
        }

        foreach (var lrb in groupBoxLunar.Controls.Cast<RadioButton>()) {
            lrb.CheckedChanged += Lrb_CheckedChanged;
        }
    }

    private void rbInit() {
        // 솔라
        set(radioButtonSComet, Mode.Solar, Difficulty.Comet);
        set(radioButtonSNova, Mode.Solar, Difficulty.Nova);
        set(radioButtonSSuperNova, Mode.Solar, Difficulty.SuperNova);
        set(radioButtonSQuasar, Mode.Solar, Difficulty.Quasar);
        set(radioButtonSStarlight, Mode.Solar, Difficulty.Starlight);

        // 루나
        set(radioButtonLComet, Mode.Lunar, Difficulty.Comet);
        set(radioButtonLNova, Mode.Lunar, Difficulty.Nova);
        set(radioButtonLSuperNova, Mode.Lunar, Difficulty.SuperNova);
        set(radioButtonLQuasar, Mode.Lunar, Difficulty.Quasar);
        set(radioButtonLStarlight, Mode.Lunar, Difficulty.Starlight);

        void set(RadioButton button, Mode mode, Difficulty difficulty) {
            var diff = getDiff();

            // 난이도가 0이 아니면 (== 채보가 있으면)
            if (diff != 0) {
                // 난이도
                button.Text = initialString[button] + " - " + diff.ToString("D2");
                var result = Profile.Instance.Results.Find(r => r.SongId == song.Id && r.Mode == mode && r.Difficulty == difficulty);

                // 결과가 있으면
                if (result is not null) {
                    // 랭크
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

                    // 점수
                    button.Text += Environment.NewLine + result.Score + "점 (" + rank + ")" + (result.FullCombo ? ", FC" : string.Empty);
                }
            } else {
                // 없으면 버튼 비활성화
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
                    Difficulty.SuperNova => diffObj.SuperNova,
                    Difficulty.Quasar => diffObj.Quasar,
                    Difficulty.Starlight => diffObj.Starlight,
                    _ => throw new NotImplementedException(),
                };
            }
        }
    }

    private void button1_Click(object sender, EventArgs e) {
        var (mode, diff) = getModeAndDiff();
        var resultIndex = Profile.Instance.Results.FindIndex(i => i.SongId == song.Id && i.Mode == mode && i.Difficulty == diff);

        // 등록된 결과가 없으면
        if (resultIndex == -1) {
            // 결과 새로 등록
            var score = int.Parse(textBoxScore.Text);

            // 점수가 1 이상이어야지만 등록함
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
            // 이미 등록된 결과 수정
            Profile.Instance.Results[resultIndex].Score = int.Parse(textBoxScore.Text);
            Profile.Instance.Results[resultIndex].FullCombo = checkBoxFullCombo.Checked;
        }

        rbInit();
    }

    // 체크된 버튼에 따라 모드와 난이도를 반환하는 메서드
    private (Mode mode, Difficulty diff) getModeAndDiff() {
        if (radioButtonSComet.Checked) {
            return (Mode.Solar, Difficulty.Comet);
        } else if (radioButtonSNova.Checked) {
            return (Mode.Solar, Difficulty.Nova);
        } else if (radioButtonSSuperNova.Checked) {
            return (Mode.Solar, Difficulty.SuperNova);
        } else if (radioButtonSQuasar.Checked) {
            return (Mode.Solar, Difficulty.Quasar);
        } else if (radioButtonSStarlight.Checked) {
            return (Mode.Solar, Difficulty.Starlight);
        } else if (radioButtonLComet.Checked) {
            return (Mode.Lunar, Difficulty.Comet);
        } else if (radioButtonLNova.Checked) {
            return (Mode.Lunar, Difficulty.Nova);
        } else if (radioButtonLSuperNova.Checked) {
            return (Mode.Lunar, Difficulty.SuperNova);
        } else if (radioButtonLQuasar.Checked) {
            return (Mode.Lunar, Difficulty.Quasar);
        } else if (radioButtonLStarlight.Checked) {
            return (Mode.Lunar, Difficulty.Starlight);
        } else {
            throw new NotImplementedException();
        }
    }

    private void checkedChanged(RadioButton button, GroupBox box, Mode mode) {
        // 지정된 버튼이 체크되면
        if (button.Checked) {
            // 점수 입력창, 풀 콤보 체크박스 활성화
            label3.Enabled = true;
            textBoxScore.Enabled = true;
            checkBoxFullCombo.Enabled = true;
            button1.Enabled = true;

            // 다른 모드의 버튼은 체크 해제
            foreach (var rb in box.Controls.Cast<RadioButton>()) {
                rb.Checked = false;
            }

            // 점수 입력창, 풀 콤보 체크박스
            var result = Profile.Instance.Results.Find(r => r.SongId == song.Id && r.Mode == mode && r.Difficulty == getModeAndDiff().diff);
            textBoxScore.Text = result?.Score.ToString() ?? "0";
            checkBoxFullCombo.Checked = result?.FullCombo ?? false;
        }
    }

    private void Srb_CheckedChanged(object? sender, EventArgs e) => checkedChanged((RadioButton)sender!, groupBoxLunar, Mode.Solar);
    private void Lrb_CheckedChanged(object? sender, EventArgs e) => checkedChanged((RadioButton)sender!, groupBoxSolar, Mode.Lunar);

    private void textBoxScore_Leave(object sender, EventArgs e) {
        // 숫자가 아니거나 0보다 작거나 1000000보다 크면
        if (!(int.TryParse(textBoxScore.Text, out var number) && (number is >= 0 and <= 1000000))) {
            MessageBox.Show("점수가 올바르지 않음!");
            textBoxScore.Focus();
        }
    }
}
