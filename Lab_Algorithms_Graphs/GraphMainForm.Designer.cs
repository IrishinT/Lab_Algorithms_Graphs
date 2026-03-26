namespace Lab_Algorithms_Graphs
{
    partial class GraphMainForm
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
            pnlControls = new Panel();
            lblAnalysis = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnBFS = new Button();
            btnDFS = new Button();
            cmbStart = new ComboBox();
            lblStart = new Label();
            lblBFS = new Label();
            pnlLoadButtons = new FlowLayoutPanel();
            btnBrowse = new Button();
            btnLoad = new Button();
            textBox1 = new TextBox();
            lblTitle = new Label();
            rtbOutput = new RichTextBox();
            lblFrom = new Label();
            cmbFrom = new ComboBox();
            cmbTo = new ComboBox();
            lblTo = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnReachable = new Button();
            btnComponents = new Button();
            pnlControls.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlLoadButtons.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlControls
            // 
            pnlControls.BackColor = Color.LightGray;
            pnlControls.Controls.Add(flowLayoutPanel2);
            pnlControls.Controls.Add(cmbTo);
            pnlControls.Controls.Add(lblTo);
            pnlControls.Controls.Add(cmbFrom);
            pnlControls.Controls.Add(lblFrom);
            pnlControls.Controls.Add(lblAnalysis);
            pnlControls.Controls.Add(flowLayoutPanel1);
            pnlControls.Controls.Add(cmbStart);
            pnlControls.Controls.Add(lblStart);
            pnlControls.Controls.Add(lblBFS);
            pnlControls.Controls.Add(pnlLoadButtons);
            pnlControls.Controls.Add(textBox1);
            pnlControls.Controls.Add(lblTitle);
            pnlControls.Dock = DockStyle.Left;
            pnlControls.Location = new Point(0, 0);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new Size(250, 553);
            pnlControls.TabIndex = 0;
            // 
            // lblAnalysis
            // 
            lblAnalysis.AutoSize = true;
            lblAnalysis.Dock = DockStyle.Top;
            lblAnalysis.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblAnalysis.Location = new Point(0, 288);
            lblAnalysis.Name = "lblAnalysis";
            lblAnalysis.Padding = new Padding(10);
            lblAnalysis.Size = new Size(117, 43);
            lblAnalysis.TabIndex = 7;
            lblAnalysis.Text = "🔗 Анализ";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnBFS);
            flowLayoutPanel1.Controls.Add(btnDFS);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 217);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(250, 71);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // btnBFS
            // 
            btnBFS.BackColor = Color.PaleTurquoise;
            btnBFS.Location = new Point(3, 3);
            btnBFS.Name = "btnBFS";
            btnBFS.Size = new Size(87, 68);
            btnBFS.TabIndex = 0;
            btnBFS.Text = "Запустить BFS";
            btnBFS.UseVisualStyleBackColor = false;
            // 
            // btnDFS
            // 
            btnDFS.BackColor = Color.PaleTurquoise;
            btnDFS.Location = new Point(96, 3);
            btnDFS.Name = "btnDFS";
            btnDFS.Size = new Size(87, 68);
            btnDFS.TabIndex = 1;
            btnDFS.Text = "Запустить DFS";
            btnDFS.UseVisualStyleBackColor = false;
            // 
            // cmbStart
            // 
            cmbStart.Dock = DockStyle.Top;
            cmbStart.FormattingEnabled = true;
            cmbStart.Location = new Point(0, 189);
            cmbStart.Name = "cmbStart";
            cmbStart.Size = new Size(250, 28);
            cmbStart.TabIndex = 5;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Dock = DockStyle.Top;
            lblStart.Location = new Point(0, 163);
            lblStart.Name = "lblStart";
            lblStart.Padding = new Padding(3);
            lblStart.Size = new Size(90, 26);
            lblStart.TabIndex = 4;
            lblStart.Text = "Начиная с:";
            // 
            // lblBFS
            // 
            lblBFS.AutoSize = true;
            lblBFS.Dock = DockStyle.Top;
            lblBFS.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblBFS.Location = new Point(0, 120);
            lblBFS.Name = "lblBFS";
            lblBFS.Padding = new Padding(10);
            lblBFS.Size = new Size(163, 43);
            lblBFS.TabIndex = 3;
            lblBFS.Text = "🚀 Обход графа";
            // 
            // pnlLoadButtons
            // 
            pnlLoadButtons.Controls.Add(btnBrowse);
            pnlLoadButtons.Controls.Add(btnLoad);
            pnlLoadButtons.Dock = DockStyle.Top;
            pnlLoadButtons.Location = new Point(0, 72);
            pnlLoadButtons.Name = "pnlLoadButtons";
            pnlLoadButtons.Size = new Size(250, 48);
            pnlLoadButtons.TabIndex = 2;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(3, 3);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 29);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "Обзор...";
            btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(84, 3);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(85, 29);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Загрузить";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Top;
            textBox1.Location = new Point(0, 45);
            textBox1.Margin = new Padding(10);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Путь к файлу .txt";
            textBox1.Size = new Size(250, 27);
            textBox1.TabIndex = 1;
            textBox1.Text = "data/students_network.txt";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(10);
            lblTitle.Size = new Size(188, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📁 Загрузка графа";
            // 
            // rtbOutput
            // 
            rtbOutput.Dock = DockStyle.Fill;
            rtbOutput.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rtbOutput.Location = new Point(250, 0);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.ReadOnly = true;
            rtbOutput.Size = new Size(532, 553);
            rtbOutput.TabIndex = 1;
            rtbOutput.Text = "";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Dock = DockStyle.Top;
            lblFrom.Location = new Point(0, 331);
            lblFrom.Name = "lblFrom";
            lblFrom.Padding = new Padding(3);
            lblFrom.Size = new Size(35, 26);
            lblFrom.TabIndex = 8;
            lblFrom.Text = "От:";
            // 
            // cmbFrom
            // 
            cmbFrom.Dock = DockStyle.Top;
            cmbFrom.FormattingEnabled = true;
            cmbFrom.Location = new Point(0, 357);
            cmbFrom.Name = "cmbFrom";
            cmbFrom.Size = new Size(250, 28);
            cmbFrom.TabIndex = 9;
            // 
            // cmbTo
            // 
            cmbTo.Dock = DockStyle.Top;
            cmbTo.FormattingEnabled = true;
            cmbTo.Location = new Point(0, 411);
            cmbTo.Name = "cmbTo";
            cmbTo.Size = new Size(250, 28);
            cmbTo.TabIndex = 11;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Dock = DockStyle.Top;
            lblTo.Location = new Point(0, 385);
            lblTo.Name = "lblTo";
            lblTo.Padding = new Padding(3);
            lblTo.Size = new Size(37, 26);
            lblTo.TabIndex = 10;
            lblTo.Text = "До:";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnReachable);
            flowLayoutPanel2.Controls.Add(btnComponents);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 439);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(250, 71);
            flowLayoutPanel2.TabIndex = 12;
            // 
            // btnReachable
            // 
            btnReachable.BackColor = Color.Aquamarine;
            btnReachable.Location = new Point(3, 3);
            btnReachable.Name = "btnReachable";
            btnReachable.Size = new Size(94, 68);
            btnReachable.TabIndex = 0;
            btnReachable.Text = "Проверить путь";
            btnReachable.UseVisualStyleBackColor = false;
            // 
            // btnComponents
            // 
            btnComponents.BackColor = Color.Aquamarine;
            btnComponents.Location = new Point(103, 3);
            btnComponents.Name = "btnComponents";
            btnComponents.Size = new Size(113, 68);
            btnComponents.TabIndex = 1;
            btnComponents.Text = "Компоненты";
            btnComponents.UseVisualStyleBackColor = false;
            // 
            // GraphMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(rtbOutput);
            Controls.Add(pnlControls);
            Name = "GraphMainForm";
            Text = "Социальная сеть студентов";
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            pnlLoadButtons.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlControls;
        private RichTextBox rtbOutput;
        private TextBox textBox1;
        private Label lblTitle;
        private FlowLayoutPanel pnlLoadButtons;
        private Button btnBrowse;
        private Button btnLoad;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnBFS;
        private Button btnDFS;
        private ComboBox cmbStart;
        private Label lblStart;
        private Label lblBFS;
        private Label lblAnalysis;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnReachable;
        private Button btnComponents;
        private ComboBox cmbTo;
        private Label lblTo;
        private ComboBox cmbFrom;
        private Label lblFrom;
    }
}
