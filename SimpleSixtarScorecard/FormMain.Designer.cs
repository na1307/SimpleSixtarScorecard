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
        label2 = new Label();
        panel1 = new Panel();
        textBox1 = new TextBox();
        label3 = new Label();
        nameColumn = new DataGridViewTextBoxColumn();
        composerColumn = new DataGridViewTextBoxColumn();
        solarQuasarColumn = new DataGridViewTextBoxColumn();
        lunarQuasarColumn = new DataGridViewTextBoxColumn();
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
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameColumn, composerColumn, solarQuasarColumn, lunarQuasarColumn });
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
        panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panel1.Location = new Point(12, 497);
        panel1.Name = "panel1";
        panel1.Size = new Size(760, 252);
        panel1.TabIndex = 5;
        // 
        // textBox1
        // 
        textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        textBox1.Location = new Point(441, 40);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(250, 23);
        textBox1.TabIndex = 6;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        label3.AutoSize = true;
        label3.Location = new Point(401, 43);
        label3.Name = "label3";
        label3.Size = new Size(34, 15);
        label3.TabIndex = 7;
        label3.Text = "검색:";
        // 
        // nameColumn
        // 
        nameColumn.DataPropertyName = "Title";
        nameColumn.HeaderText = "제목";
        nameColumn.Name = "nameColumn";
        nameColumn.ReadOnly = true;
        nameColumn.Width = 235;
        // 
        // composerColumn
        // 
        composerColumn.DataPropertyName = "Composer";
        composerColumn.HeaderText = "작곡가";
        composerColumn.Name = "composerColumn";
        composerColumn.ReadOnly = true;
        composerColumn.Width = 235;
        // 
        // solarQuasarColumn
        // 
        solarQuasarColumn.DataPropertyName = "SolarQuasar";
        solarQuasarColumn.HeaderText = "솔라 퀘이사 난이도";
        solarQuasarColumn.Name = "solarQuasarColumn";
        solarQuasarColumn.ReadOnly = true;
        solarQuasarColumn.Width = 135;
        // 
        // lunarQuasarColumn
        // 
        lunarQuasarColumn.DataPropertyName = "LunarQuasar";
        lunarQuasarColumn.HeaderText = "루나 퀘이사 난이도";
        lunarQuasarColumn.Name = "lunarQuasarColumn";
        lunarQuasarColumn.ReadOnly = true;
        lunarQuasarColumn.Width = 135;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 761);
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
}
