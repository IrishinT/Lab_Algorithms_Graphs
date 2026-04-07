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
            lblStatus = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnReachable = new Button();
            btnComponents = new Button();
            btnDijkstra = new Button();
            btnAnalysis = new Button();
            btnCompare = new Button();
            cmbTo = new ComboBox();
            lblTo = new Label();
            cmbFrom = new ComboBox();
            lblFrom = new Label();
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
            txtFilePath = new TextBox();
            lblTitle = new Label();
            rtbOutput = new RichTextBox();
            splitContainerRight = new SplitContainer();
            dgvDistances = new DataGridView();
            pnlControls.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlLoadButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerRight).BeginInit();
            splitContainerRight.Panel1.SuspendLayout();
            splitContainerRight.Panel2.SuspendLayout();
            splitContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDistances).BeginInit();
            SuspendLayout();
            // 
            // pnlControls
            // 
            pnlControls.BackColor = Color.LightGray;
            pnlControls.Controls.Add(lblStatus);
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
            pnlControls.Controls.Add(txtFilePath);
            pnlControls.Controls.Add(lblTitle);
            pnlControls.Dock = DockStyle.Left;
            pnlControls.Location = new Point(0, 0);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new Size(338, 653);
            pnlControls.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Location = new Point(0, 627);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(3);
            lblStatus.Size = new Size(147, 26);
            lblStatus.TabIndex = 13;
            lblStatus.Text = "Статус: Ожидание...";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnReachable);
            flowLayoutPanel2.Controls.Add(btnComponents);
            flowLayoutPanel2.Controls.Add(btnDijkstra);
            flowLayoutPanel2.Controls.Add(btnAnalysis);
            flowLayoutPanel2.Controls.Add(btnCompare);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 439);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(338, 173);
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
            btnComponents.Size = new Size(108, 68);
            btnComponents.TabIndex = 1;
            btnComponents.Text = "Компоненты";
            btnComponents.UseVisualStyleBackColor = false;
            // 
            // btnDijkstra
            // 
            btnDijkstra.BackColor = Color.Aquamarine;
            btnDijkstra.Location = new Point(217, 3);
            btnDijkstra.Name = "btnDijkstra";
            btnDijkstra.Size = new Size(108, 68);
            btnDijkstra.TabIndex = 2;
            btnDijkstra.Text = "Дейкстра";
            btnDijkstra.UseVisualStyleBackColor = false;
            // 
            // btnAnalysis
            // 
            btnAnalysis.BackColor = Color.LightSkyBlue;
            btnAnalysis.Location = new Point(3, 77);
            btnAnalysis.Name = "btnAnalysis";
            btnAnalysis.Size = new Size(94, 67);
            btnAnalysis.TabIndex = 14;
            btnAnalysis.Text = "Глубокий анализ";
            btnAnalysis.UseVisualStyleBackColor = false;
            // 
            // btnCompare
            // 
            btnCompare.BackColor = Color.LightSkyBlue;
            btnCompare.Location = new Point(103, 77);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(168, 67);
            btnCompare.TabIndex = 15;
            btnCompare.Text = "Сравнение BFS и Дейкстры";
            btnCompare.UseVisualStyleBackColor = false;
            // 
            // cmbTo
            // 
            cmbTo.Dock = DockStyle.Top;
            cmbTo.FormattingEnabled = true;
            cmbTo.Location = new Point(0, 411);
            cmbTo.Name = "cmbTo";
            cmbTo.Size = new Size(338, 28);
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
            // cmbFrom
            // 
            cmbFrom.Dock = DockStyle.Top;
            cmbFrom.FormattingEnabled = true;
            cmbFrom.Location = new Point(0, 357);
            cmbFrom.Name = "cmbFrom";
            cmbFrom.Size = new Size(338, 28);
            cmbFrom.TabIndex = 9;
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
            flowLayoutPanel1.Size = new Size(338, 71);
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
            cmbStart.Size = new Size(338, 28);
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
            pnlLoadButtons.Size = new Size(338, 48);
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
            // txtFilePath
            // 
            txtFilePath.Dock = DockStyle.Top;
            txtFilePath.Location = new Point(0, 45);
            txtFilePath.Margin = new Padding(10);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.PlaceholderText = "Путь к файлу .txt";
            txtFilePath.Size = new Size(338, 27);
            txtFilePath.TabIndex = 1;
            txtFilePath.Text = "data/supply_network.txt";
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
            rtbOutput.Location = new Point(0, 0);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.ReadOnly = true;
            rtbOutput.Size = new Size(544, 324);
            rtbOutput.TabIndex = 1;
            rtbOutput.Text = "";
            // 
            // splitContainerRight
            // 
            splitContainerRight.Dock = DockStyle.Fill;
            splitContainerRight.Location = new Point(338, 0);
            splitContainerRight.Name = "splitContainerRight";
            splitContainerRight.Orientation = Orientation.Horizontal;
            // 
            // splitContainerRight.Panel1
            // 
            splitContainerRight.Panel1.Controls.Add(rtbOutput);
            // 
            // splitContainerRight.Panel2
            // 
            splitContainerRight.Panel2.Controls.Add(dgvDistances);
            splitContainerRight.Size = new Size(544, 653);
            splitContainerRight.SplitterDistance = 324;
            splitContainerRight.TabIndex = 0;
            // 
            // dgvDistances
            // 
            dgvDistances.AllowUserToAddRows = false;
            dgvDistances.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDistances.BackgroundColor = Color.White;
            dgvDistances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDistances.Dock = DockStyle.Fill;
            dgvDistances.Location = new Point(0, 0);
            dgvDistances.Name = "dgvDistances";
            dgvDistances.ReadOnly = true;
            dgvDistances.RowHeadersWidth = 51;
            dgvDistances.Size = new Size(544, 325);
            dgvDistances.TabIndex = 0;
            // 
            // GraphMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 653);
            Controls.Add(splitContainerRight);
            Controls.Add(pnlControls);
            Name = "GraphMainForm";
            Text = "Сеть поставок товаров";
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            pnlLoadButtons.ResumeLayout(false);
            splitContainerRight.Panel1.ResumeLayout(false);
            splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerRight).EndInit();
            splitContainerRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDistances).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlControls;
        private RichTextBox rtbOutput;
        private TextBox txtFilePath;
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
        private Label lblStatus;
        private Button btnDijkstra;
        private SplitContainer splitContainerRight;
        private DataGridView dgvDistances;
        private Button btnAnalysis;
        private Button btnCompare;
    }
}
