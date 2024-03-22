namespace SimpleSixtarScorecard;

partial class ProfileNameDialog {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileNameDialog));
        label1 = new Label();
        textBox1 = new TextBox();
        SuspendLayout();
        // 
        // label1
        // 
        resources.ApplyResources(label1, "label1");
        label1.Name = "label1";
        // 
        // textBox1
        // 
        resources.ApplyResources(textBox1, "textBox1");
        textBox1.Name = "textBox1";
        // 
        // ProfileNameDialog
        // 
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(textBox1);
        Controls.Add(label1);
        Name = "ProfileNameDialog";
        Controls.SetChildIndex(label1, 0);
        Controls.SetChildIndex(textBox1, 0);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox textBox1;
}