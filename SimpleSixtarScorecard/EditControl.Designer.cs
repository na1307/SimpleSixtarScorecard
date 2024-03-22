namespace SimpleSixtarScorecard;

partial class EditControl {
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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(EditControl));
        groupBoxSolar = new GroupBox();
        radioButtonSStarlight = new RadioButton();
        radioButtonSQuasar = new RadioButton();
        radioButtonSSuperNova = new RadioButton();
        radioButtonSNova = new RadioButton();
        radioButtonSComet = new RadioButton();
        radioButtonLComet = new RadioButton();
        radioButtonLNova = new RadioButton();
        radioButtonLSuperNova = new RadioButton();
        radioButtonLQuasar = new RadioButton();
        radioButtonLStarlight = new RadioButton();
        groupBoxLunar = new GroupBox();
        label3 = new Label();
        textBoxScore = new TextBox();
        checkBoxFullCombo = new CheckBox();
        button1 = new Button();
        groupBoxSolar.SuspendLayout();
        groupBoxLunar.SuspendLayout();
        SuspendLayout();
        // 
        // groupBoxSolar
        // 
        resources.ApplyResources(groupBoxSolar, "groupBoxSolar");
        groupBoxSolar.Controls.Add(radioButtonSStarlight);
        groupBoxSolar.Controls.Add(radioButtonSQuasar);
        groupBoxSolar.Controls.Add(radioButtonSSuperNova);
        groupBoxSolar.Controls.Add(radioButtonSNova);
        groupBoxSolar.Controls.Add(radioButtonSComet);
        groupBoxSolar.Name = "groupBoxSolar";
        groupBoxSolar.TabStop = false;
        // 
        // radioButtonSStarlight
        // 
        resources.ApplyResources(radioButtonSStarlight, "radioButtonSStarlight");
        radioButtonSStarlight.Name = "radioButtonSStarlight";
        radioButtonSStarlight.UseVisualStyleBackColor = true;
        // 
        // radioButtonSQuasar
        // 
        resources.ApplyResources(radioButtonSQuasar, "radioButtonSQuasar");
        radioButtonSQuasar.Name = "radioButtonSQuasar";
        radioButtonSQuasar.UseVisualStyleBackColor = true;
        // 
        // radioButtonSSuperNova
        // 
        resources.ApplyResources(radioButtonSSuperNova, "radioButtonSSuperNova");
        radioButtonSSuperNova.Name = "radioButtonSSuperNova";
        radioButtonSSuperNova.UseVisualStyleBackColor = true;
        // 
        // radioButtonSNova
        // 
        resources.ApplyResources(radioButtonSNova, "radioButtonSNova");
        radioButtonSNova.Name = "radioButtonSNova";
        radioButtonSNova.UseVisualStyleBackColor = true;
        // 
        // radioButtonSComet
        // 
        resources.ApplyResources(radioButtonSComet, "radioButtonSComet");
        radioButtonSComet.Name = "radioButtonSComet";
        radioButtonSComet.UseVisualStyleBackColor = true;
        // 
        // radioButtonLComet
        // 
        resources.ApplyResources(radioButtonLComet, "radioButtonLComet");
        radioButtonLComet.Name = "radioButtonLComet";
        radioButtonLComet.UseVisualStyleBackColor = true;
        // 
        // radioButtonLNova
        // 
        resources.ApplyResources(radioButtonLNova, "radioButtonLNova");
        radioButtonLNova.Name = "radioButtonLNova";
        radioButtonLNova.UseVisualStyleBackColor = true;
        // 
        // radioButtonLSuperNova
        // 
        resources.ApplyResources(radioButtonLSuperNova, "radioButtonLSuperNova");
        radioButtonLSuperNova.Name = "radioButtonLSuperNova";
        radioButtonLSuperNova.UseVisualStyleBackColor = true;
        // 
        // radioButtonLQuasar
        // 
        resources.ApplyResources(radioButtonLQuasar, "radioButtonLQuasar");
        radioButtonLQuasar.Name = "radioButtonLQuasar";
        radioButtonLQuasar.UseVisualStyleBackColor = true;
        // 
        // radioButtonLStarlight
        // 
        resources.ApplyResources(radioButtonLStarlight, "radioButtonLStarlight");
        radioButtonLStarlight.Name = "radioButtonLStarlight";
        radioButtonLStarlight.UseVisualStyleBackColor = true;
        // 
        // groupBoxLunar
        // 
        resources.ApplyResources(groupBoxLunar, "groupBoxLunar");
        groupBoxLunar.Controls.Add(radioButtonLStarlight);
        groupBoxLunar.Controls.Add(radioButtonLQuasar);
        groupBoxLunar.Controls.Add(radioButtonLSuperNova);
        groupBoxLunar.Controls.Add(radioButtonLNova);
        groupBoxLunar.Controls.Add(radioButtonLComet);
        groupBoxLunar.Name = "groupBoxLunar";
        groupBoxLunar.TabStop = false;
        // 
        // label3
        // 
        resources.ApplyResources(label3, "label3");
        label3.Name = "label3";
        // 
        // textBoxScore
        // 
        resources.ApplyResources(textBoxScore, "textBoxScore");
        textBoxScore.Name = "textBoxScore";
        textBoxScore.Leave += textBoxScore_Leave;
        // 
        // checkBoxFullCombo
        // 
        resources.ApplyResources(checkBoxFullCombo, "checkBoxFullCombo");
        checkBoxFullCombo.Name = "checkBoxFullCombo";
        checkBoxFullCombo.UseVisualStyleBackColor = true;
        // 
        // button1
        // 
        resources.ApplyResources(button1, "button1");
        button1.Name = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // EditControl
        // 
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(button1);
        Controls.Add(checkBoxFullCombo);
        Controls.Add(textBoxScore);
        Controls.Add(label3);
        Controls.Add(groupBoxLunar);
        Controls.Add(groupBoxSolar);
        Name = "EditControl";
        groupBoxSolar.ResumeLayout(false);
        groupBoxLunar.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private GroupBox groupBoxSolar;
    private RadioButton radioButtonSNova;
    private RadioButton radioButtonSComet;
    private RadioButton radioButtonSStarlight;
    private RadioButton radioButtonSQuasar;
    private RadioButton radioButtonSSuperNova;
    private RadioButton radioButtonLComet;
    private RadioButton radioButtonLNova;
    private RadioButton radioButtonLSuperNova;
    private RadioButton radioButtonLQuasar;
    private RadioButton radioButtonLStarlight;
    private GroupBox groupBoxLunar;
    private Label label3;
    private TextBox textBoxScore;
    private CheckBox checkBoxFullCombo;
    private Button button1;
}