using Lab_Algorithms_Graphs.Models;
using Lab_Algorithms_Graphs.Service;

namespace Lab_Algorithms_Graphs
{
    public partial class GraphMainForm : Form
    {
        private Graph? _graph;

        public GraphMainForm()
        {
            InitializeComponent();

            btnLoad.Click += btnLoad_Click;
            btnBrowse.Click += btnBrowse_Click;
        }

        private void btnLoad_Click(object? sender, EventArgs e)
        {
            try
            {
                _graph = GraphFileParser.LoadFromTxt(txtFilePath.Text);

                // Заполняем ComboBox вершинами
                cmbStart.Items.Clear();
                cmbFrom.Items.Clear();
                cmbTo.Items.Clear();

                foreach (var v in _graph.Vertices)
                {
                    cmbStart.Items.Add(v);
                    cmbFrom.Items.Add(v);
                    cmbTo.Items.Add(v);
                }

                // Выбираем первую вершину по умолчанию
                if (cmbStart.Items.Count > 0) cmbStart.SelectedIndex = 0;
                if (cmbFrom.Items.Count > 0) cmbFrom.SelectedIndex = 0;
                if (cmbTo.Items.Count > 0) cmbTo.SelectedIndex = 1;

                lblStatus.Text = $"✓ Загружено: {_graph.VertexCount} вершин, {_graph.EdgeCount} рёбер";
                lblStatus.BackColor = Color.FromArgb(200, 255, 200);

                rtbOutput.Clear();
                rtbOutput.AppendText($"Граф успешно загружен!\n");
                rtbOutput.AppendText($"Вершин: {_graph.VertexCount}\n");
                rtbOutput.AppendText($"Рёбер: {_graph.EdgeCount}\n");
                rtbOutput.AppendText($"Тип: {(_graph.IsDirected ? "Ориентированный" : "Неориентированный")}\n");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "✗ Ошибка загрузки";
                lblStatus.BackColor = Color.FromArgb(255, 200, 200);
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка загрузки",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Text files|*.txt",
                Title = "Выберите файл с графом"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
                txtFilePath.Text = dialog.FileName;
        }

    }
}
