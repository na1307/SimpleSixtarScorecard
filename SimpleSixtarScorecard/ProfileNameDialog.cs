using static SimpleSixtarScorecard.Properties.Strings;

namespace SimpleSixtarScorecard;

internal sealed partial class ProfileNameDialog : LocalizableDialog {
    public ProfileNameDialog(bool createNew) {
        InitializeComponent();
        label1.Text = createNew ? WhatsYourName + Environment.NewLine + Environment.NewLine + YouCanAlways : WhatsYourName;
    }

    public string UserName => textBox1.Text;
}
