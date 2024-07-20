namespace SortingAlgorithms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Start = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            panel1 = new Panel();
            panel4 = new Panel();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            Stop = new Button();
            Randomize = new Button();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // Start
            // 
            Start.BackColor = Color.FromArgb(128, 255, 128);
            Start.FlatStyle = FlatStyle.Flat;
            Start.Location = new Point(21, 20);
            Start.Name = "Start";
            Start.Size = new Size(324, 208);
            Start.TabIndex = 0;
            Start.Text = "Start";
            Start.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Quick Sort", "Merge Sort", "Heap Sort", "Selection Sort", "Insertion Sort", "Bubble Sort" });
            comboBox1.Location = new Point(351, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(351, 17);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 2;
            label1.Text = "Choose Algorithm";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(Stop);
            panel1.Controls.Add(Randomize);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(Start);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBox1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 586);
            panel1.Name = "panel1";
            panel1.Size = new Size(1498, 336);
            panel1.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Controls.Add(button1);
            panel4.Controls.Add(richTextBox1);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(917, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(326, 336);
            panel4.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(21, 17);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Save Logs";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 12F);
            richTextBox1.Location = new Point(102, 9);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(218, 315);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // Stop
            // 
            Stop.BackColor = Color.Red;
            Stop.FlatStyle = FlatStyle.Flat;
            Stop.Location = new Point(21, 20);
            Stop.Name = "Stop";
            Stop.Size = new Size(324, 208);
            Stop.TabIndex = 5;
            Stop.Text = "Stop";
            Stop.UseVisualStyleBackColor = false;
            Stop.Visible = false;
            Stop.Click += Stop_Click;
            // 
            // Randomize
            // 
            Randomize.BackColor = Color.DarkOrange;
            Randomize.FlatStyle = FlatStyle.Flat;
            Randomize.Location = new Point(351, 80);
            Randomize.Name = "Randomize";
            Randomize.Size = new Size(132, 61);
            Randomize.TabIndex = 4;
            Randomize.Text = "Randomize";
            Randomize.UseVisualStyleBackColor = false;
            Randomize.Click += Randomize_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.WindowFrame;
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(1243, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(255, 336);
            panel2.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 83.3333359F));
            tableLayoutPanel1.Size = new Size(255, 336);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 56);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 1;
            label3.Text = "Descs";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 0;
            label2.Text = "Algorithm";
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1498, 586);
            panel3.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1498, 922);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sorting Algorithms - Efe Yıldırım";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button Start;
        private ComboBox comboBox1;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button Randomize;
        private Button Stop;
        private Label label3;
        private Label label2;
        private Button button1;
        private RichTextBox richTextBox1;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
