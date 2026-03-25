using System;
using System.Collections.Generic;
using System.Linq;
using Lab_Algorithms_Graphs.Models;

namespace Lab_Algorithms_Graphs.Service
{
    public static class BFS_Algorithm
    {
        /// <summary>
        /// Обход графа в ширину. Возвращает порядок посещения вершин.
        /// </summary>
        public static List<Vertex> Traverse(Graph graph, Vertex start)
        {
            var result = new List<Vertex>();
            var visited = new HashSet<Vertex>();
            var queue = new Queue<Vertex>();

            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current);

                foreach (var neighbor in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Проверка достижимости вершины to из вершины from
        /// </summary>
        public static bool IsReachable(Graph graph, Vertex from, Vertex to)
        {
            if (from.Equals(to)) return true;

            var visited = new HashSet<Vertex>();
            var queue = new Queue<Vertex>();

            visited.Add(from);
            queue.Enqueue(from);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var neighbor in graph.GetNeighbors(current))
                {
                    if (neighbor.Equals(to)) return true;
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Поиск кратчайшего пути по количеству рёбер (возвращает цепочку вершин)
        /// </summary>
        public static List<Vertex>? FindShortestPath(Graph graph, Vertex from, Vertex to)
        {
            if (from.Equals(to)) return new List<Vertex> { from };

            var visited = new HashSet<Vertex>();
            var queue = new Queue<Vertex>();
            var previous = new Dictionary<Vertex, Vertex?>();

            visited.Add(from);
            queue.Enqueue(from);
            previous[from] = null;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var neighbor in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        previous[neighbor] = current;

                        if (neighbor.Equals(to))
                        {
                            // Восстанавливаем путь
                            var path = new List<Vertex>();
                            var step = to;
                            while (step != null)
                            {
                                path.Insert(0, step);
                                step = previous[step];
                            }
                            return path;
                        }
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return null; // Путь не найден
        }
    }
}
