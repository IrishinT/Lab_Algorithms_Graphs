using Lab_Algorithms_Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Service
{
    public static class DFS_Algorithm
    {
        /// <summary>
        /// Обход графа в глубину (итеративный, через стек).
        /// Возвращает порядок посещения вершин.
        /// </summary>
        public static List<Vertex> Traverse(Graph graph, Vertex start)
        {
            var result = new List<Vertex>();
            var visited = new HashSet<Vertex>();
            var stack = new Stack<Vertex>();

            stack.Push(start);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (visited.Contains(current)) continue;

                visited.Add(current);
                result.Add(current);

                // Добавляем соседей в обратном порядке для "естественного" обхода
                foreach (var neighbor in graph.GetNeighbors(current).Reverse())
                {
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
                }
            }

            return result;
        }

        /// <summary>
        /// Рекурсивная версия DFS (для сравнения или учебных целей)
        /// </summary>
        public static void TraverseRecursive(Graph graph, Vertex start,
            Action<Vertex> onVisit, HashSet<Vertex>? visited = null)
        {
            visited ??= new HashSet<Vertex>();
            if (visited.Contains(start)) return;

            visited.Add(start);
            onVisit(start);

            foreach (var neighbor in graph.GetNeighbors(start))
                TraverseRecursive(graph, neighbor, onVisit, visited);
        }
    }
}
