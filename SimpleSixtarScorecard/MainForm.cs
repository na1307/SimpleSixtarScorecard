using SimpleSixtarScorecard.Properties;

namespace SimpleSixtarScorecard;

public sealed partial class MainForm : Form {
    private SortableBindingList<Song> songs = new(Song.SongList);
    private int dlc;
    private int category;

    public MainForm() {
        InitializeComponent();
        label1.Text = string.Format(Strings.UserName, Profile.Instance.UserName);

        // Song data
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = songs;
        label2.Text = string.Format(Strings.Songs, songs.Count);

        // ComboBoxes
        comboBox1.DataSource = ((string[])([Strings.All])).Concat(Enum.GetValues(typeof(Dlc)).Cast<Dlc>().Select(dlc => dlc.ToName())).ToArray();
        comboBox2.DataSource = ((string[])([Strings.All])).Concat(Enum.GetValues(typeof(Category)).Cast<Category>().Select(category => category.ToString())).ToArray();
    }

    private void button1_Click(object sender, EventArgs e) {
        // Change username
        using ProfileNameDialog dialog = new(false);

        if (dialog.ShowDialog() == DialogResult.OK) {
            Profile.Instance.UserName = dialog.UserName.Trim();
            label1.Text = string.Format(Strings.UserName, Profile.Instance.UserName);
        }
    }

    private void DataGridView1_SelectionChanged(object sender, EventArgs e) {
        int index;

        try {
            // Selected song index
            index = dataGridView1.SelectedRows[0].Index;
        } catch (ArgumentOutOfRangeException) {
            // Disable if no song is selected
            panel1.Visible = false;
            return;
        }

        // Shows if a song is selected
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
        label2.Text = string.Format(Strings.Songs, songs.Count);

        bool enumTest(Song song) {
            if (dlc == 0 && category == 0) {
                // If DLC and Category are both "All"
                return true;
            } else if (dlc != 0 && category == 0) {
                // If DLC is specified
                return dlcTest();
            } else if (dlc == 0 && category != 0) {
                // If Category is specified
                return categoryTest();
            } else {
                // If both are specified
                return dlcTest() && categoryTest();
            }

            bool dlcTest() => song.Dlc == (Dlc)dlc;
            bool categoryTest() => song.Category == (Category)category;
        }
    }
}
