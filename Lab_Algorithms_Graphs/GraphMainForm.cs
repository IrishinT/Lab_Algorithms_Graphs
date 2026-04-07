using Lab_Algorithms_Graphs.Models;
using Lab_Algorithms_Graphs.Service;
using System.Diagnostics;
using System.Net;

namespace Lab_Algorithms_Graphs
{
    public partial class GraphMainForm : Form
    {
        // Поле для хранения текущего графа (null, если ещё не загружен)
        private Graph? _graph;

        public GraphMainForm()
        {
            InitializeComponent();

            btnLoad.Click += btnLoad_Click;
            btnBrowse.Click += btnBrowse_Click;
            btnBFS.Click += btnBFS_Click;
            btnDFS.Click += btnDFS_Click;
            btnReachable.Click += btnReachable_Click;
            btnComponents.Click += btnComponents_Click;
            btnDijkstra.Click += btnDijkstra_Click;
            btnAnalysis.Click += btnAnalysis_Click;
            btnCompare.Click += btnCompare_Click;
        }

        private void InitDistancesGrid()
        {
            dgvDistances.Rows.Clear();
            dgvDistances.Columns.Clear();
            dgvDistances.Columns.Add("Target", "Объект назначения");
            dgvDistances.Columns.Add("Dist", "Мин. Стоимость");
            dgvDistances.Columns.Add("Path", "Предыдущий узел");

            dgvDistances.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDistances.AllowUserToAddRows = false;
            dgvDistances.RowHeadersVisible = false;
        }

        /// <summary>
        ///  Обработчик кнопки "Загрузить граф".
        /// </summary>
        private void btnLoad_Click(object? sender, EventArgs e)
        {
            try
            {
                _graph = GraphFileParser.LoadFromTxt(txtFilePath.Text);
                InitDistancesGrid();

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

                lblStatus.Text = $"Загружено: {_graph.VertexCount} вершин, {_graph.EdgeCount} рёбер";
                lblStatus.BackColor = Color.FromArgb(200, 255, 200);

                rtbOutput.Clear();
                rtbOutput.AppendText($"Граф успешно загружен!\n");
                rtbOutput.AppendText($"Вершин: {_graph.VertexCount}\n");
                rtbOutput.AppendText($"Рёбер: {_graph.EdgeCount}\n");
                rtbOutput.AppendText($"Тип: {(_graph.IsDirected ? "Ориентированный" : "Неориентированный")}\n");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Ошибка загрузки!";
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

        private void btnBFS_Click(object? sender, EventArgs e)
        {
            if (_graph == null || cmbStart.SelectedItem is not Vertex start)
            {
                MessageBox.Show("Загрузите граф и выберите стартовую вершину");
                return;
            }

            var sw = Stopwatch.StartNew();
            var order = BFS_Algorithm.Traverse(_graph, start);
            sw.Stop();

            rtbOutput.Clear();
            rtbOutput.AppendText($"[BFS] Обход от объекта: {start}\n");
            rtbOutput.AppendText($"Порядок посещения:\n");
            rtbOutput.AppendText(string.Join(" -> ", order) + "\n");
            rtbOutput.AppendText($"\nВсего вершин: {order.Count}\n");
            rtbOutput.AppendText($"\nВремя выполнения: {sw.Elapsed.TotalMilliseconds:F4} мс\n");
            rtbOutput.ScrollToCaret();
        }

        private void btnDFS_Click(object? sender, EventArgs e)
        {
            if (_graph == null || cmbStart.SelectedItem is not Vertex start)
            {
                MessageBox.Show("Загрузите граф и выберите стартовую вершину");
                return;
            }

            var sw = Stopwatch.StartNew();
            var order = DFS_Algorithm.Traverse(_graph, start);
            sw.Stop();

            rtbOutput.Clear();
            rtbOutput.AppendText($"[DFS] Обход от объекта: {start}\n");
            rtbOutput.AppendText($"Порядок посещения:\n");
            rtbOutput.AppendText(string.Join(" -> ", order) + "\n");
            rtbOutput.AppendText($"\nВсего вершин: {order.Count}\n");
            rtbOutput.AppendText($"\nВремя выполнения алгоритма DFS: {sw.Elapsed.TotalMilliseconds:F4} мс\n");
            rtbOutput.ScrollToCaret();
        }

        private void btnReachable_Click(object? sender, EventArgs e)
        {
            if (_graph == null ||
                cmbFrom.SelectedItem is not Vertex from ||
                cmbTo.SelectedItem is not Vertex to)
            {
                MessageBox.Show("Загрузите граф и выберите две вершины");
                return;
            }

            var sw = Stopwatch.StartNew();
            var reachable = BFS_Algorithm.IsReachable(_graph, from, to);
            var path = BFS_Algorithm.FindShortestPath(_graph, from, to);
            sw.Stop();

            rtbOutput.Clear();
            rtbOutput.AppendText($"[Достижимость] {from} -> {to}\n\n");

            if (reachable)
            {
                rtbOutput.AppendText($"✓ Вершина {to} ДОСТИЖИМА из {from}\n");
                if (path != null)
                {
                    rtbOutput.AppendText($"\nКратчайший путь ({path.Count - 1} рукопожатий):\n");
                    rtbOutput.AppendText(string.Join(" → ", path) + "\n");
                }
            }
            else
            {
                rtbOutput.AppendText($"✗ Вершина {to} НЕ достижима из {from}\n");
            }

            rtbOutput.AppendText($"\nВремя поиска пути (BFS): {sw.Elapsed.TotalMilliseconds:F4} мс\n");
            rtbOutput.ScrollToCaret();
        }

        private void btnComponents_Click(object? sender, EventArgs e)
        {
            if (_graph == null)
            {
                MessageBox.Show("Загрузите граф");
                return;
            }

            var sw = Stopwatch.StartNew();
            var components = Connectivity.FindConnectedComponents(_graph);
            sw.Stop();

            rtbOutput.Clear();
            rtbOutput.AppendText($"[Компоненты связности]\n\n");

            if (components.Count == 1)
            {
                rtbOutput.AppendText($"Граф СВЯЗНЫЙ\n");
                rtbOutput.AppendText($"Все {components[0].Count} объектов входят в одну группу знакомств\n");
            }
            else
            {
                rtbOutput.AppendText($"Граф НЕСВЯЗНЫЙ\n");
                rtbOutput.AppendText($"Найдено компонент: {components.Count}\n\n");

                for (int i = 0; i < components.Count; i++)
                {
                    rtbOutput.AppendText($"Компонента {i + 1} ({components[i].Count} объектов.):\n");
                    rtbOutput.AppendText(string.Join(", ", components[i]) + "\n\n");
                }
            }

            rtbOutput.AppendText($"\nВремя поиска компонент связности: {sw.Elapsed.TotalMilliseconds:F4} мс\n");
            rtbOutput.ScrollToCaret();
        }

        private void btnDijkstra_Click(object sender, EventArgs e)
        {
            if (_graph == null || cmbFrom.SelectedItem is not Vertex from)
            {
                MessageBox.Show("Загрузите граф и выберите начальную вершину!");
                return;
            }

            // Запуск алгоритма
            var sw = Stopwatch.StartNew();
            var (distances, parents) = Dijkstra_Algorithm.Run(_graph, from);
            sw.Stop();

            dgvDistances.Rows.Clear();
            InitDistancesGrid();

            foreach (var v in _graph.Vertices.OrderBy(v => v.Label))
            {
                string d = double.IsPositiveInfinity(distances[v]) ? "∞" : distances[v].ToString("F2");
                string p = parents[v]?.Label ?? "—";
                dgvDistances.Rows.Add(v.Label, d, p);
            }

            rtbOutput.Clear();
            rtbOutput.AppendText($"[Dijkstra] Анализ от узла: {from}\n");
            rtbOutput.AppendText($"Таблица расстояний до всех объектов обновлена внизу.\n\n");

            if (cmbTo.SelectedItem is Vertex to && !from.Equals(to))
            {
                rtbOutput.AppendText($"--- Поиск конкретного пути до {to} ---\n");
                if (double.IsPositiveInfinity(distances[to]))
                {
                    rtbOutput.AppendText("❌ Путь недоступен.\n");
                }
                else
                {
                    var path = Dijkstra_Algorithm.GetPath(parents, to);
                    rtbOutput.AppendText($"Кратчайшая стоимость: {distances[to]:F2}\n");
                    rtbOutput.AppendText($"Маршрут: {string.Join(" → ", path)}\n");
                }
            }

            rtbOutput.AppendText($"\nВремя выполнения Дейкстры: {sw.Elapsed.TotalMilliseconds:F4} мс\n");
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            if (_graph == null)
            {
                MessageBox.Show("Сначала загрузите граф!");
                return;
            }

            rtbOutput.Clear();
            rtbOutput.SelectionFont = new Font(rtbOutput.Font, FontStyle.Bold | FontStyle.Underline);
            rtbOutput.AppendText("ОТЧЕТ ПО АНАЛИЗУ СЕТИ ПОСТАВОК\n\n");

            // --- 1. Точки сочленения ---

            var sw1 = Stopwatch.StartNew();
            var points = GraphAnalysis.FindArticulationPoints(_graph);
            sw1.Stop();

            rtbOutput.SelectionFont = new Font(rtbOutput.Font, FontStyle.Bold);
            rtbOutput.AppendText("1. КРИТИЧЕСКИЕ СКЛАДЫ:\n");
            if (points.Count > 0)
                rtbOutput.AppendText($"При выходе из строя этих узлов сеть разрывается: {string.Join(", ", points)}\n");
            else
                rtbOutput.AppendText("Критических складов не обнаружено. Сеть надежна.\n");
            rtbOutput.AppendText($"Время поиска: {sw1.Elapsed.TotalMilliseconds:F4} мс\n\n");
            rtbOutput.AppendText("\n");

            // --- 2. Минимальное остовное дерево (MST) ---
            var sw2 = Stopwatch.StartNew();
            var mst = GraphAnalysis.GetMST(_graph);
            sw2.Stop();

            rtbOutput.SelectionFont = new Font(rtbOutput.Font, FontStyle.Bold);
            rtbOutput.AppendText("2. МИНИМАЛЬНАЯ ИНФРАСТРУКТУРА (MST):\n");
            rtbOutput.AppendText($"Минимальный набор дорог для связи всех точек (сумма: {mst.Sum(x => x.Weight):F2}):\n");
            foreach (var edge in mst.Take(10)) // выводим первые 10 для краткости
                rtbOutput.AppendText($" • {edge.From} ↔ {edge.To} ({edge.Weight})\n");
            rtbOutput.AppendText($"Время построения дерева: {sw2.Elapsed.TotalMilliseconds:F4} мс\n\n");
            rtbOutput.AppendText("\n");

            // --- 3. Основная задача варианта №10 ---
            var sw3 = Stopwatch.StartNew();
            var (hub, totalDist) = GraphAnalysis.FindDeliveryCenter(_graph);
            sw3.Stop();

            rtbOutput.SelectionFont = new Font(rtbOutput.Font, FontStyle.Bold);
            rtbOutput.AppendText("3. ОПТИМАЛЬНЫЙ МАРШРУТ ДОСТАВКИ:\n");
            if (hub != null)
            {
                rtbOutput.AppendText($"Идеальная точка для центрального хаба: {hub}\n");
                rtbOutput.AppendText($"Обеспечивает минимальный средний маршрут до всех магазинов.\n");
                rtbOutput.AppendText($"Суммарная стоимость доставки по всей сети: {totalDist:F2}");
            }
            else
            {
                rtbOutput.AppendText("Невозможно найти центр (граф несвязный).");
            }
            rtbOutput.AppendText($"⏱ Время расчёта логистического центра: {sw3.Elapsed.TotalMilliseconds:F4} мс\n");
            rtbOutput.ScrollToCaret();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (_graph == null || cmbFrom.SelectedItem is not Vertex from)
            {
                MessageBox.Show("Загрузите граф и выберите начальную точку (От:).");
                return;
            }

            // 1. Перенастраиваем колонки нашей таблицы dgvDistances
            dgvDistances.Columns.Clear();
            dgvDistances.Columns.Add("Target", "Назначение");
            dgvDistances.Columns.Add("BfsPath", "Маршрут (BFS)");
            dgvDistances.Columns.Add("BfsCost", "Цена (BFS)");
            dgvDistances.Columns.Add("DijkPath", "Маршрут (Дейкстра)");
            dgvDistances.Columns.Add("DijkCost", "Цена (Дейкстра)");

            dgvDistances.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDistances.AllowUserToAddRows = false;
            dgvDistances.RowHeadersVisible = false;

            // 2. Запуск алгоритма Дейкстры (Поиск по весам)
            var swDijkstra = Stopwatch.StartNew();
            var (dijkstraDistances, dijkstraParents) = Dijkstra_Algorithm.Run(_graph, from);
            swDijkstra.Stop();

            // 3. Запуск алгоритма BFS (Поиск по количеству ребер)
            var swBfs = Stopwatch.StartNew();
            var bfsPaths = new Dictionary<Vertex, List<Vertex>?>();
            foreach (var v in _graph.Vertices)
            {
                bfsPaths[v] = BFS_Algorithm.FindShortestPath(_graph, from, v);
            }
            swBfs.Stop();

            dgvDistances.Rows.Clear();

            // 4. Заполняем таблицу сравнения для каждой вершины
            foreach (var to in _graph.Vertices.OrderBy(v => v.Label))
            {
                if (from.Equals(to)) continue; // Пропускаем путь в саму себя

                // --- Данные Дейкстры ---
                string dPathStr = "—";
                string dCostStr = "∞";
                double dCostVal = double.PositiveInfinity;

                if (!double.IsPositiveInfinity(dijkstraDistances[to]))
                {
                    var dPath = Dijkstra_Algorithm.GetPath(dijkstraParents, to);
                    dPathStr = string.Join(" → ", dPath.Select(x => x.Label));
                    dCostVal = dijkstraDistances[to];
                    dCostStr = dCostVal.ToString("F2");
                }

                // --- Данные BFS ---
                string bPathStr = "—";
                string bCostStr = "∞";
                double bCostVal = double.PositiveInfinity;

                var bPath = bfsPaths[to];
                if (bPath != null)
                {
                    bPathStr = string.Join(" -> ", bPath.Select(x => x.Label));

                    // BFS не считает веса сам, поэтому суммируем стоимость найденного пути вручную
                    bCostVal = 0;
                    for (int i = 0; i < bPath.Count - 1; i++)
                    {
                        var edge = _graph.GetNeighborsWithWeights(bPath[i]).First(x => x.Neighbor.Equals(bPath[i + 1]));
                        bCostVal += edge.Weight;
                    }
                    bCostStr = bCostVal.ToString("F2");
                }

                // Добавляем строку в таблицу
                int rowIndex = dgvDistances.Rows.Add(to.Label, bPathStr, bCostStr, dPathStr, dCostStr);

                // 5. Визуальный анализ: Подсвечиваем разницу
                if (bCostVal != double.PositiveInfinity && dCostVal != double.PositiveInfinity)
                {
                    // Если Дейкстра нашел маршрут дешевле, чем BFS — красим строку в зеленый!
                    if (dCostVal < bCostVal)
                    {
                        dgvDistances.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }

            // 6. Вывод логов и времени в текстовое поле
            rtbOutput.Clear();
            rtbOutput.SelectionFont = new Font(rtbOutput.Font, FontStyle.Bold | FontStyle.Underline);
            rtbOutput.AppendText($"АНАЛИЗ И СРАВНЕНИЕ АЛГОРИТМОВ\n\n");
            rtbOutput.SelectionFont = new Font(rtbOutput.Font, FontStyle.Regular);

            rtbOutput.AppendText($"Начальная точка: {from}\n\n");
            rtbOutput.AppendText("Таблица (внизу) заполнена!\n");
            rtbOutput.AppendText("Строки, выделенные зеленым цветом, показывают ситуации, когда прямой путь по количеству остановок (BFS) оказался дороже, чем путь в обход (Дейкстра).\n\n");

            rtbOutput.AppendText($"Время работы BFS (обход до всех): {swBfs.Elapsed.TotalMilliseconds:F4} мс\n");
            rtbOutput.AppendText($"Время работы Дейкстры: {swDijkstra.Elapsed.TotalMilliseconds:F4} мс\n");
            rtbOutput.ScrollToCaret();
        }

    }
}
