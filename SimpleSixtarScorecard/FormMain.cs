namespace SimpleSixtarScorecard;

public partial class FormMain : Form {
    private SortableBindingList<Song> songs = new(Song.SongList);
    private int dlc = 0;
    private int category = 0;

    public FormMain() {
        InitializeComponent();
        label1.Text = Profile.Instance.UserName + " 님";

        // 곡 데이터 가져오기
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = songs;
        label2.Text = "총 " + songs.Count.ToString() + "곡";

        // 콤보박스 설정
        comboBox1.DataSource = ((string[])(["모두"])).Concat(Enum.GetValues<Dlc>().Select(dlc => dlc.ToName())).ToArray();
        comboBox2.DataSource = ((string[])(["모두"])).Concat(Enum.GetValues<Category>().Select(category => category.ToString())).ToArray();
    }

    private void button1_Click(object sender, EventArgs e) {
        // 사용자 이름 바꾸기
        using ProfileNameDialog dialog = new(false);

        if (dialog.ShowDialog() == DialogResult.OK) {
            Profile.Instance.UserName = dialog.UserName.Trim();
            label1.Text = Profile.Instance.UserName + " 님";
        }
    }

    private void DataGridView1_SelectionChanged(object sender, EventArgs e) {
        int index;

        try {
            // 선택된 곡 인덱스
            index = dataGridView1.SelectedRows[0].Index;
        } catch (ArgumentOutOfRangeException) {
            // 선택된 곡이 없으면 비활성화
            panel1.Visible = false;
            return;
        }

        // 선택된 곡이 있으면 표시
        panel1.Visible = true;
        panel1.Controls.Clear();

        if (index != -1) {
            panel1.Controls.Add(new EditControl(songs[index]));
        }
    }

    private void textBox1_TextChanged(object sender, EventArgs e) => refreshSongs();

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        dlc = comboBox1.SelectedIndex;
        refreshSongs();
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
        category = comboBox2.SelectedIndex;
        refreshSongs();
    }

    private void refreshSongs() {
        var tmpSongs = !string.IsNullOrWhiteSpace(textBox1.Text)
            ? Song.SongList.Where(song => enumTest(song) && (song.Title.Contains(textBox1.Text.Trim(), StringComparison.OrdinalIgnoreCase) || song.Composer.Contains(textBox1.Text.Trim(), StringComparison.OrdinalIgnoreCase))).ToArray()
            : Song.SongList.Where(enumTest).ToArray();

        songs = new(tmpSongs);
        dataGridView1.DataSource = songs;
        label2.Text = "총 " + songs.Count.ToString() + "곡";

        bool enumTest(Song song) {
            if (dlc == 0 && category == 0) {
                // DLC와 카테고리가 둘 다 "모두"라면
                return true;
            } else if (dlc != 0 && category == 0) {
                // DLC가 지정되어 있으면
                return dlcTest();
            } else if (dlc == 0 && category != 0) {
                // 카테고리가 지정되어 있으면
                return categoryTest();
            } else {
                // 둘 다 지정되어 있으면
                return dlcTest() && categoryTest();
            }

            // 1을 빼는 이유: 열거형은 0부터 시작하는데 여기서는 0이 "모두"로 설정되어 있기 때문
            bool dlcTest() => song.Dlc == (Dlc)(dlc - 1);
            bool categoryTest() => song.Category == (Category)(category - 1);
        }
    }
}
