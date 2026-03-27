using Lab_Algorithms_Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Service
{
    /// <summary>
    /// Предоставляет методы для анализа связности неориентированного графа.
    /// </summary>
    public static class Connectivity
    {
        /// <summary>
        /// Находит все компоненты связности неориентированного графа.
        /// </summary>
        /// <param name="graph">Граф для анализа.</param>
        /// <returns>
        /// Список списков вершин, где каждый внутренний список
        /// представляет одну компоненту связности.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Если граф является ориентированным.
        /// </exception>
        /// <remarks>
        /// Компонента связности — максимальный подграф,
        /// в котором между любыми двумя вершинами существует путь.
        /// Метод использует итеративный DFS для обхода каждой компоненты.
        /// Сложность: O(V + E).
        /// </remarks>
        public static List<List<Vertex>> FindConnectedComponents(Graph graph)
        {
            // Метод работает только для неориентированных графов
            if (graph.IsDirected)
                throw new InvalidOperationException("Метод применим только к неориентированным графам");

            // Результат: список компонент (каждая компонента — список вершин)
            var components = new List<List<Vertex>>();

            // Множество посещённых вершин (общее для всех компонент)
            var visited = new HashSet<Vertex>();

            // Перебираем все вершины графа
            foreach (var vertex in graph.Vertices)
            {
                // Если вершина ещё не в составе ни одной компоненты
                if (!visited.Contains(vertex))
                {
                    // Начинаем новую компоненту
                    var component = new List<Vertex>();
                    var stack = new Stack<Vertex>();
                    stack.Push(vertex);

                    // DFS-обход для сбора всех вершин компоненты
                    while (stack.Count > 0)
                    {
                        var current = stack.Pop();
                        if (visited.Contains(current)) continue;

                        visited.Add(current);
                        component.Add(current);

                        // Добавляем непосещённых соседей в стек
                        foreach (var neighbor in graph.GetNeighbors(current))
                        {
                            if (!visited.Contains(neighbor))
                                stack.Push(neighbor);
                        }
                    }

                    // Добавляем собранную компоненту в результат
                    components.Add(component);
                }
            }

            return components;
        }

        /// <summary>
        /// Проверяет, является ли граф связным
        /// </summary>
        public static bool IsConnected(Graph graph) =>
            FindConnectedComponents(graph).Count == 1 || graph.VertexCount == 0;
    }
}
