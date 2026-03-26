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
            rtbOutput = new RichTextBox();
            SuspendLayout();
            // 
            // pnlControls
            // 
            pnlControls.BackColor = Color.LightGray;
            pnlControls.Dock = DockStyle.Left;
            pnlControls.Location = new Point(0, 0);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new Size(250, 450);
            pnlControls.TabIndex = 0;
            // 
            // rtbOutput
            // 
            rtbOutput.Dock = DockStyle.Fill;
            rtbOutput.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rtbOutput.Location = new Point(250, 0);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(550, 450);
            rtbOutput.TabIndex = 1;
            rtbOutput.Text = "";
            // 
            // GraphMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbOutput);
            Controls.Add(pnlControls);
            Name = "GraphMainForm";
            Text = "Социальная сеть студентов";
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlControls;
        private RichTextBox rtbOutput;
    }
}
