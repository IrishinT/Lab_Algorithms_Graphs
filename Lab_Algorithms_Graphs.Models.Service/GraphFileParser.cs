using Lab_Algorithms_Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Service
{
    /// <summary>
    /// Предоставляет методы для загрузки и сохранения графа из/в текстовый файл.
    /// </summary>
    /// <remarks>
    /// Формат файла:
    /// <code>
    /// [SECTION:VERTICES]
    /// Фамилия1
    /// Фамилия2
    /// ...
    /// [SECTION:EDGES]
    /// Фамилия1,Фамилия2
    /// Фамилия2,Фамилия3
    /// </code>
    /// Комментарии начинаются с символа '#'.
    /// Разделители в рёбрах: запятая или точка с запятой.
    /// </remarks>
    public static class GraphFileParser
    {
        /// <summary>
        /// Загружает граф из текстового файла.
        /// </summary>
        /// <param name="filePath">Путь к файлу .txt с описанием графа.</param>
        /// <param name="isDirected">
        /// <c>true</c> для создания ориентированного графа;
        /// <c>false</c> для неориентированного (по умолчанию).
        /// </param>
        /// <returns>Загруженный объект <see cref="Graph"/>.</returns>
        /// <exception cref="FileNotFoundException">
        /// Если файл по указанному пути не найден.
        /// </exception>
        /// <exception cref="FormatException">
        /// Если файл имеет неверный формат.
        /// </exception>
        public static Graph LoadFromTxt(string filePath, bool isDirected = false)
        {
            var graph = new Graph(isDirected);

            // Переменная для отслеживания текущей секции файла
            var section = string.Empty;

            // Читаем файл построчно (эффективно для больших файлов)
            foreach (var line in File.ReadLines(filePath))
            {
                // Убираем пробелы по краям
                var trimmed = line.Trim();

                // Пропускаем пустые строки и комментарии
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("#"))
                    continue;

                // Обработка заголовков секций
                if (trimmed.Equals("[SECTION:VERTICES]", StringComparison.OrdinalIgnoreCase))
                {
                    section = "VERTICES";
                    continue;
                }
                if (trimmed.Equals("[SECTION:EDGES]", StringComparison.OrdinalIgnoreCase))
                {
                    section = "EDGES";
                    continue;
                }

                // Парсинг содержимого в зависимости от текущей секции
                switch (section)
                {
                    case "VERTICES":
                        // Создаём вершину и добавляем в граф
                        graph.AddVertex(new Vertex(trimmed));
                        break;
                    case "EDGES":
                        var parts = trimmed.Split(',', ';');
                        if (parts.Length >= 2)
                        {
                            var from = new Vertex(parts[0].Trim());
                            var to = new Vertex(parts[1].Trim());

                            // читаем вес (третий параметр)
                            double weight = 1.0;
                            if (parts.Length >= 3 && double.TryParse(parts[2], out var w))
                                weight = w;

                            var edge = new Edge(from, to, weight);
                            graph.AddEdge(from, to, weight); // TODO: Нужно добавить вес в AddEdge
                        }
                        break;
                }
            }

            return graph;
        }

        /// <summary>
        /// Сохраняет граф в текстовый файл в стандартном формате.
        /// </summary>
        /// <param name="graph">Граф для сохранения.</param>
        /// <param name="filePath">Путь к выходному файлу.</param>
        /// <remarks>
        /// Для неориентированного графа каждое ребро записывается один раз
        /// (в лексикографическом порядке вершин), чтобы избежать дублирования.
        /// </remarks>
        public static void SaveToTxt(Graph graph, string filePath)
        {
            using var writer = new StreamWriter(filePath);

            // Записываем секцию вершин
            writer.WriteLine("[SECTION:VERTICES]");
            foreach (var v in graph.Vertices)
                writer.WriteLine(v.Id);

            // Записываем секцию рёбер
            writer.WriteLine("\n[SECTION:EDGES]");

            // Множество для отслеживания уже записанных рёбер
            var edges = new HashSet<Edge>();

            // Для неориентированного графа нормализуем порядок вершин
            // (чтобы ребро A-B и B-A записалось одинаково)
            foreach (var v in graph.Vertices)
            {
                foreach (var edge in graph.GetNeighborsWithWeights(v))
                {
                    // Для неориентированного графа нормализуем порядок
                    var normalizedEdge = graph.IsDirected
                        ? new Edge(v, edge.Neighbor, edge.Weight)
                        : new Edge(
                            string.Compare(v.Id, edge.Neighbor.Id, StringComparison.Ordinal) < 0 ? v : edge.Neighbor,
                            string.Compare(v.Id, edge.Neighbor.Id, StringComparison.Ordinal) < 0 ? edge.Neighbor : v,
                            edge.Weight);

                    if (edges.Add(normalizedEdge))
                        writer.WriteLine($"{v.Id},{edge.Neighbor.Id},{edge.Weight}");
                }
            }
        }
    }
}
