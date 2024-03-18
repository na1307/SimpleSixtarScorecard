namespace SimpleSixtarScorecard;

public partial class FormMain : Form {
    private static readonly SortableBindingList<Song> staticSongs = new(Song.SongList);
    private SortableBindingList<Song> songs = staticSongs;

    public FormMain() {
        InitializeComponent();
        label1.Text = Profile.Instance.UserName + " ¥‘";

        // ∞Ó µ•¿Ã≈Õ ∞°¡Æø¿±‚
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = songs;
        label2.Text = "√— " + songs.Count.ToString() + "∞Ó";
    }

    private void button1_Click(object sender, EventArgs e) {
        // ªÁøÎ¿⁄ ¿Ã∏ß πŸ≤Ÿ±‚
        using ProfileNameDialog dialog = new(false);

        if (dialog.ShowDialog() == DialogResult.OK) {
            Profile.Instance.UserName = dialog.UserName.Trim();
            label1.Text = Profile.Instance.UserName + " ¥‘";
        }
    }

    private void DataGridView1_SelectionChanged(object sender, EventArgs e) {
        int index;

        try {
            // º±≈√µ» ∞Ó ¿Œµ¶Ω∫
            index = dataGridView1.SelectedRows[0].Index;
        } catch (ArgumentOutOfRangeException) {
            // º±≈√µ» ∞Ó¿Ã æ¯¿∏∏È ∫Ò»∞º∫»≠
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
           // πÆ¿⁄ø≠ ∞Àªˆ
           ? new SortableBindingList<Song>(Song.SongList.Where(song => song.Title.Contains(textBox1.Text.Trim(), StringComparison.OrdinalIgnoreCase) || song.Composer.Contains(textBox1.Text.Trim(), StringComparison.OrdinalIgnoreCase)).ToArray())
           : staticSongs;

        dataGridView1.DataSource = songs;
        label2.Text = "√— " + songs.Count.ToString() + "∞Ó";
    }
}
