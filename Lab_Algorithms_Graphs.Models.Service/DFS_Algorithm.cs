using Lab_Algorithms_Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Service
{
    /// <summary>
    /// Реализует алгоритм обхода графа в глубину (Depth-First Search, DFS).
    /// </summary>
    /// <remarks>
    /// DFS уходит как можно глубже по одной ветке перед возвратом,
    /// используя стек (итеративная версия) или рекурсию.
    /// Сложность: O(V + E).
    /// Применяется для:
    /// - Проверки связности графа
    /// - Обнаружения циклов
    /// - Топологической сортировки (для ориентированных ациклических графов)
    /// </remarks>
    public static class DFS_Algorithm
    {
        /// <summary>
        /// Выполняет итеративный обход графа в глубину от заданной вершины.
        /// </summary>
        /// <param name="graph">Граф для обхода.</param>
        /// <param name="start">Стартовая вершина.</param>
        /// <returns>
        /// Список вершин в порядке их посещения алгоритмом DFS.
        /// </returns>
        /// <remarks>
        /// Итеративная реализация предпочтительнее рекурсивной для больших графов,
        /// так как избегает переполнения стека вызовов.
        /// Соседи добавляются в стек в обратном порядке для более 
        /// "естественного" порядка обхода (аналогично рекурсии).
        /// </remarks>
        public static List<Vertex> Traverse(Graph graph, Vertex start)
        {
            var result = new List<Vertex>();
            var visited = new HashSet<Vertex>();

            // Стек для хранения вершин (LIFO — последним пришёл, первым ушёл)
            var stack = new Stack<Vertex>();

            stack.Push(start);

            while (stack.Count > 0)
            {
                // Извлекаем вершину из вершины стека
                var current = stack.Pop();

                // Если уже посещали — пропускаем (может быть дубль в стеке)
                if (visited.Contains(current)) continue;

                visited.Add(current);
                result.Add(current);

                // Добавляем соседей в обратном порядке для "естественного" обхода
                // Reverse() нужен, чтобы первый сосед был обработан первым
                foreach (var neighbor in graph.GetNeighbors(current).Reverse())
                {
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
                }
            }

            return result;
        }

        /// <summary>
        /// Выполняет рекурсивный обход графа в глубину с вызовом делегата
        /// для каждой посещённой вершины.
        /// </summary>
        /// <param name="graph">Граф для обхода.</param>
        /// <param name="start">Стартовая вершина.</param>
        /// <param name="onVisit">Делегат, вызываемый при посещении вершины.</param>
        /// <param name="visited">
        /// Опциональное множество уже посещённых вершин
        /// (для продолжения обхода с сохранением состояния).
        /// </param>
        /// <remarks>
        /// Рекурсивная версия удобна для учебных целей и отладки,
        /// но может вызвать StackOverflowException на графах
        /// с большой глубиной.
        /// </remarks>
        public static void TraverseRecursive(Graph graph, Vertex start,
            Action<Vertex> onVisit, HashSet<Vertex>? visited = null)
        {
            // Если множество visited не передано — создаём новое
            visited ??= new HashSet<Vertex>();

            // Если уже посещали — выходим
            if (visited.Contains(start)) return;

            visited.Add(start);

            // Помечаем как посещённую и вызываем делегат
            onVisit(start);

            // Рекурсивно обходим всех соседей
            foreach (var neighbor in graph.GetNeighbors(start))
                TraverseRecursive(graph, neighbor, onVisit, visited);
        }
    }
}
