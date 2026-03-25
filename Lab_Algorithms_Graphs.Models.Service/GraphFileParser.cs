using Lab_Algorithms_Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Service
{
    public static class GraphFileParser
    {
        /// <summary>
        /// Формат файла:
        /// # Вершины (по одной на строку)
        /// [SECTION:VERTICES]
        /// Ivanov
        /// Petrov
        /// ...
        /// # Рёбра (пара через запятую)
        /// [SECTION:EDGES]
        /// Ivanov,Petrov
        /// Petrov,Sidorov
        /// ...
        /// </summary>
        public static Graph LoadFromTxt(string filePath, bool isDirected = false)
        {
            var graph = new Graph(isDirected);
            var section = string.Empty;

            foreach (var line in File.ReadLines(filePath))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("#"))
                    continue;

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

                switch (section)
                {
                    case "VERTICES":
                        graph.AddVertex(new Vertex(trimmed));
                        break;
                    case "EDGES":
                        var parts = trimmed.Split(',', ';');
                        if (parts.Length >= 2)
                        {
                            var from = new Vertex(parts[0].Trim());
                            var to = new Vertex(parts[1].Trim());
                            graph.AddEdge(from, to);
                        }
                        break;
                }
            }

            return graph;
        }

        public static void SaveToTxt(Graph graph, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            writer.WriteLine("[SECTION:VERTICES]");
            foreach (var v in graph.Vertices)
                writer.WriteLine(v.Id);

            writer.WriteLine("\n[SECTION:EDGES]");
            var edges = new HashSet<Edge>();
            foreach (var v in graph.Vertices)
            {
                foreach (var neighbor in graph.GetNeighbors(v))
                {
                    var edge = graph.IsDirected
                        ? new Edge(v, neighbor)
                        : new Edge(
                            string.Compare(v.Id, neighbor.Id, StringComparison.Ordinal) < 0 ? v : neighbor,
                            string.Compare(v.Id, neighbor.Id, StringComparison.Ordinal) < 0 ? neighbor : v);

                    if (edges.Add(edge))
                        writer.WriteLine($"{v.Id},{neighbor.Id}");
                }
            }
        }
    }
}
