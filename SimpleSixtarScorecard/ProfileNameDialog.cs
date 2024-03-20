namespace SimpleSixtarScorecard;

public partial class ProfileNameDialog : Dialog {
    public ProfileNameDialog(bool createNew) {
        InitializeComponent();
        label1.Text = createNew ? "이름이 무엇인가요?\r\n\r\n언제든지 변경할 수 있습니다." : "이름이 무엇인가요?";
    }

    public string UserName => textBox1.Text;
}
