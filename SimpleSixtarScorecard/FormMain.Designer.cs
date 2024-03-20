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
        label1 = new Label();
        button1 = new Button();
        dataGridView1 = new DataGridView();
        nameColumn = new DataGridViewTextBoxColumn();
        composerColumn = new DataGridViewTextBoxColumn();
        solarQuasarColumn = new DataGridViewTextBoxColumn();
        lunarQuasarColumn = new DataGridViewTextBoxColumn();
        dlcColumn = new DataGridViewTextBoxColumn();
        categoryColumn = new DataGridViewTextBoxColumn();
        label2 = new Label();
        panel1 = new Panel();
        textBox1 = new TextBox();
        label3 = new Label();
        label4 = new Label();
        comboBox1 = new ComboBox();
        label5 = new Label();
        label6 = new Label();
        comboBox2 = new ComboBox();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        label1.Font = new Font("맑은 고딕", 12F);
        label1.Location = new Point(12, 12);
        label1.Name = "label1";
        label1.Size = new Size(604, 21);
        label1.TabIndex = 0;
        label1.Text = "label1";
        // 
        // button1
        // 
        button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        button1.Location = new Point(622, 12);
        button1.Name = "button1";
        button1.Size = new Size(150, 25);
        button1.TabIndex = 1;
        button1.Text = "사용자 이름 바꾸기";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AllowUserToResizeRows = false;
        dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameColumn, composerColumn, solarQuasarColumn, lunarQuasarColumn, dlcColumn, categoryColumn });
        dataGridView1.Location = new Point(12, 66);
        dataGridView1.MultiSelect = false;
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.Size = new Size(760, 425);
        dataGridView1.TabIndex = 2;
        dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        // 
        // nameColumn
        // 
        nameColumn.DataPropertyName = "Title";
        nameColumn.HeaderText = "제목";
        nameColumn.Name = "nameColumn";
        nameColumn.ReadOnly = true;
        nameColumn.Width = 220;
        // 
        // composerColumn
        // 
        composerColumn.DataPropertyName = "Composer";
        composerColumn.HeaderText = "작곡가";
        composerColumn.Name = "composerColumn";
        composerColumn.ReadOnly = true;
        composerColumn.Width = 220;
        // 
        // solarQuasarColumn
        // 
        solarQuasarColumn.DataPropertyName = "SolarQuasar";
        solarQuasarColumn.HeaderText = "솔라 퀘이사 난이도";
        solarQuasarColumn.Name = "solarQuasarColumn";
        solarQuasarColumn.ReadOnly = true;
        solarQuasarColumn.Width = 140;
        // 
        // lunarQuasarColumn
        // 
        lunarQuasarColumn.DataPropertyName = "LunarQuasar";
        lunarQuasarColumn.HeaderText = "루나 퀘이사 난이도";
        lunarQuasarColumn.Name = "lunarQuasarColumn";
        lunarQuasarColumn.ReadOnly = true;
        lunarQuasarColumn.Width = 140;
        // 
        // dlcColumn
        // 
        dlcColumn.DataPropertyName = "DlcName";
        dlcColumn.HeaderText = "DLC";
        dlcColumn.Name = "dlcColumn";
        dlcColumn.ReadOnly = true;
        dlcColumn.Width = 150;
        // 
        // categoryColumn
        // 
        categoryColumn.DataPropertyName = "Category";
        categoryColumn.HeaderText = "카테고리";
        categoryColumn.Name = "categoryColumn";
        categoryColumn.ReadOnly = true;
        categoryColumn.Width = 80;
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        label2.Location = new Point(697, 40);
        label2.Name = "label2";
        label2.Size = new Size(75, 23);
        label2.TabIndex = 4;
        label2.TextAlign = ContentAlignment.MiddleRight;
        // 
        // panel1
        // 
        panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panel1.Location = new Point(12, 497);
        panel1.Name = "panel1";
        panel1.Size = new Size(760, 252);
        panel1.TabIndex = 5;
        // 
        // textBox1
        // 
        textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        textBox1.Location = new Point(431, 40);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(260, 23);
        textBox1.TabIndex = 6;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        label3.AutoSize = true;
        label3.Location = new Point(391, 44);
        label3.Name = "label3";
        label3.Size = new Size(34, 15);
        label3.TabIndex = 7;
        label3.Text = "검색:";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(12, 44);
        label4.Name = "label4";
        label4.Size = new Size(34, 15);
        label4.TabIndex = 8;
        label4.Text = "필터:";
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(88, 41);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(150, 23);
        comboBox1.TabIndex = 9;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(52, 44);
        label5.Name = "label5";
        label5.Size = new Size(30, 15);
        label5.TabIndex = 10;
        label5.Text = "DLC";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(244, 44);
        label6.Name = "label6";
        label6.Size = new Size(55, 15);
        label6.TabIndex = 11;
        label6.Text = "카테고리";
        // 
        // comboBox2
        // 
        comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox2.FormattingEnabled = true;
        comboBox2.Location = new Point(305, 41);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new Size(80, 23);
        comboBox2.TabIndex = 12;
        comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 761);
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
        StartPosition = FormStartPosition.CenterScreen;
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
    private DataGridViewTextBoxColumn nameColumn;
    private DataGridViewTextBoxColumn composerColumn;
    private DataGridViewTextBoxColumn solarQuasarColumn;
    private DataGridViewTextBoxColumn lunarQuasarColumn;
    private DataGridViewTextBoxColumn dlcColumn;
    private DataGridViewTextBoxColumn categoryColumn;
    private Label label4;
    private ComboBox comboBox1;
    private Label label5;
    private Label label6;
    private ComboBox comboBox2;
}
