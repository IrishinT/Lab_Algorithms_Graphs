using Lab_Algorithms_Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Service
{
    public static class Connectivity
    {
        /// <summary>
        /// Находит все компоненты связности неориентированного графа.
        /// Возвращает список списков вершин (каждый список — одна компонента).
        /// </summary>
        public static List<List<Vertex>> FindConnectedComponents(Graph graph)
        {
            if (graph.IsDirected)
                throw new InvalidOperationException("Метод применим только к неориентированным графам");

            var components = new List<List<Vertex>>();
            var visited = new HashSet<Vertex>();

            foreach (var vertex in graph.Vertices)
            {
                if (!visited.Contains(vertex))
                {
                    var component = new List<Vertex>();
                    var stack = new Stack<Vertex>();
                    stack.Push(vertex);

                    while (stack.Count > 0)
                    {
                        var current = stack.Pop();
                        if (visited.Contains(current)) continue;

                        visited.Add(current);
                        component.Add(current);

                        foreach (var neighbor in graph.GetNeighbors(current))
                        {
                            if (!visited.Contains(neighbor))
                                stack.Push(neighbor);
                        }
                    }
                    components.Add(component);
                }
            }

            return components;
        }

        /// <summary>
        /// Проверяет, является ли граф связным
        /// </summary>
        public static bool IsConnected(Graph graph) =>
            FindConnectedComponents(graph).Count == 1;
    }
}
