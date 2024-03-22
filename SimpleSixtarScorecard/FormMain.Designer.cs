namespace SimpleSixtarScorecard;

partial class FormMain {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        label1 = new Label();
        button1 = new Button();
        dataGridView1 = new DataGridView();
        label2 = new Label();
        panel1 = new Panel();
        textBox1 = new TextBox();
        label3 = new Label();
        label4 = new Label();
        comboBox1 = new ComboBox();
        label5 = new Label();
        label6 = new Label();
        comboBox2 = new ComboBox();
        nameColumn = new DataGridViewTextBoxColumn();
        composerColumn = new DataGridViewTextBoxColumn();
        solarQuasarColumn = new DataGridViewTextBoxColumn();
        lunarQuasarColumn = new DataGridViewTextBoxColumn();
        dlcColumn = new DataGridViewTextBoxColumn();
        categoryColumn = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        resources.ApplyResources(label1, "label1");
        label1.Name = "label1";
        // 
        // button1
        // 
        resources.ApplyResources(button1, "button1");
        button1.Name = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // dataGridView1
        // 
        resources.ApplyResources(dataGridView1, "dataGridView1");
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AllowUserToResizeRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameColumn, composerColumn, solarQuasarColumn, lunarQuasarColumn, dlcColumn, categoryColumn });
        dataGridView1.MultiSelect = false;
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        // 
        // label2
        // 
        resources.ApplyResources(label2, "label2");
        label2.Name = "label2";
        // 
        // panel1
        // 
        resources.ApplyResources(panel1, "panel1");
        panel1.Name = "panel1";
        // 
        // textBox1
        // 
        resources.ApplyResources(textBox1, "textBox1");
        textBox1.Name = "textBox1";
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // label3
        // 
        resources.ApplyResources(label3, "label3");
        label3.Name = "label3";
        // 
        // label4
        // 
        resources.ApplyResources(label4, "label4");
        label4.Name = "label4";
        // 
        // comboBox1
        // 
        resources.ApplyResources(comboBox1, "comboBox1");
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Name = "comboBox1";
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // label5
        // 
        resources.ApplyResources(label5, "label5");
        label5.Name = "label5";
        // 
        // label6
        // 
        resources.ApplyResources(label6, "label6");
        label6.Name = "label6";
        // 
        // comboBox2
        // 
        resources.ApplyResources(comboBox2, "comboBox2");
        comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox2.FormattingEnabled = true;
        comboBox2.Name = "comboBox2";
        comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        // 
        // nameColumn
        // 
        nameColumn.DataPropertyName = "Title";
        resources.ApplyResources(nameColumn, "nameColumn");
        nameColumn.Name = "nameColumn";
        nameColumn.ReadOnly = true;
        // 
        // composerColumn
        // 
        composerColumn.DataPropertyName = "Composer";
        resources.ApplyResources(composerColumn, "composerColumn");
        composerColumn.Name = "composerColumn";
        composerColumn.ReadOnly = true;
        // 
        // solarQuasarColumn
        // 
        solarQuasarColumn.DataPropertyName = "SolarQuasar";
        resources.ApplyResources(solarQuasarColumn, "solarQuasarColumn");
        solarQuasarColumn.Name = "solarQuasarColumn";
        solarQuasarColumn.ReadOnly = true;
        // 
        // lunarQuasarColumn
        // 
        lunarQuasarColumn.DataPropertyName = "LunarQuasar";
        resources.ApplyResources(lunarQuasarColumn, "lunarQuasarColumn");
        lunarQuasarColumn.Name = "lunarQuasarColumn";
        lunarQuasarColumn.ReadOnly = true;
        // 
        // dlcColumn
        // 
        dlcColumn.DataPropertyName = "DlcName";
        resources.ApplyResources(dlcColumn, "dlcColumn");
        dlcColumn.Name = "dlcColumn";
        dlcColumn.ReadOnly = true;
        // 
        // categoryColumn
        // 
        categoryColumn.DataPropertyName = "Category";
        resources.ApplyResources(categoryColumn, "categoryColumn");
        categoryColumn.Name = "categoryColumn";
        categoryColumn.ReadOnly = true;
        // 
        // FormMain
        // 
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(comboBox2);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(comboBox1);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(textBox1);
        Controls.Add(panel1);
        Controls.Add(label2);
        Controls.Add(dataGridView1);
        Controls.Add(button1);
        Controls.Add(label1);
        Name = "FormMain";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Button button1;
    private DataGridView dataGridView1;
    private Label label2;
    private Panel panel1;
    private TextBox textBox1;
    private Label label3;
    private Label label4;
    private ComboBox comboBox1;
    private Label label5;
    private Label label6;
    private ComboBox comboBox2;
    private DataGridViewTextBoxColumn nameColumn;
    private DataGridViewTextBoxColumn composerColumn;
    private DataGridViewTextBoxColumn solarQuasarColumn;
    private DataGridViewTextBoxColumn lunarQuasarColumn;
    private DataGridViewTextBoxColumn dlcColumn;
    private DataGridViewTextBoxColumn categoryColumn;
}
