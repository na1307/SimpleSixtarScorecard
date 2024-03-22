namespace SimpleSixtarScorecard;

public partial class ProfileNameDialog : LocalizableDialog {
    public ProfileNameDialog(bool createNew) {
        InitializeComponent();
        label1.Text = createNew ? "What's your name?\r\n\r\nYou can always change it later." : "What's your name?";
    }

    public string UserName => textBox1.Text;
}
