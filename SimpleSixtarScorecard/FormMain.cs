namespace SimpleSixtarScorecard;

public partial class FormMain : Form {
    private Song[] songs = Song.SongList;

    public FormMain() {
        InitializeComponent();
        label1.Text = Profile.Instance.UserName + " ´Ô";

        // °î µ¥ÀÌÅÍ °¡Á®¿À±â
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = songs;
        label2.Text = "ÃÑ " + songs.Length.ToString() + "°î";
    }

    private void button1_Click(object sender, EventArgs e) {
        // »ç¿ëÀÚ ÀÌ¸§ ¹Ù²Ù±â
        using ProfileNameDialog dialog = new(false);

        if (dialog.ShowDialog() == DialogResult.OK) {
            Profile.Instance.UserName = dialog.UserName.Trim();
            label1.Text = Profile.Instance.UserName + " ´Ô";
        }
    }

    private void DataGridView1_SelectionChanged(object sender, EventArgs e) {
        int index;

        try {
            // ¼±ÅÃµÈ °î ÀÎµ¦½º
            index = dataGridView1.SelectedRows[0].Index;
        } catch (ArgumentOutOfRangeException) {
            // ¼±ÅÃµÈ °îÀÌ ¾øÀ¸¸é ºñÈ°¼ºÈ­
            panel1.Visible = false;
            return;
        }

        panel1.Visible = true;
        panel1.Controls.Clear();

        if (index != -1) {
            panel1.Controls.Add(new EditControl(songs[index]));
        }
    }

    private void textBox1_TextChanged(object sender, EventArgs e) {
        songs = !string.IsNullOrWhiteSpace(textBox1.Text)
           // ¹®ÀÚ¿­ °Ë»ö
           ? Song.SongList.Where(song => song.Title.Contains(textBox1.Text.Trim(), StringComparison.OrdinalIgnoreCase) || song.Composer.Contains(textBox1.Text.Trim(), StringComparison.OrdinalIgnoreCase)).ToArray()
           : Song.SongList;

        dataGridView1.DataSource = songs;
        label2.Text = "ÃÑ " + songs.Length.ToString() + "°î";
    }
}
