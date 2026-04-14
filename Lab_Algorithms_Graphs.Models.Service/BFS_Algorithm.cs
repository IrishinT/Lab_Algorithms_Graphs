using System;
using System.Collections.Generic;
using System.Linq;
using Lab_Algorithms_Graphs.Models;

namespace Lab_Algorithms_Graphs.Service
{
    /// <summary>
    /// Реализует алгоритм обхода графа в ширину (Breadth-First Search, BFS).
    /// </summary>
    /// <remarks>
    /// BFS обходит граф уровень за уровнем, используя очередь.
    /// Сложность: O(V + E), где V — количество вершин, E — количество рёбер.
    /// Применяется для:
    /// - Поиска кратчайшего пути по количеству рёбер
    /// - Проверки достижимости вершин
    /// - Поиска компонент связности
    /// </remarks>
    public static class BFS_Algorithm
    {

        /// <summary>
        /// Выполняет обход графа в ширину от заданной стартовой вершины.
        /// </summary>
        /// <param name="graph">Граф для обхода.</param>
        /// <param name="start">Стартовая вершина.</param>
        /// <returns>
        /// Список вершин в порядке их посещения алгоритмом BFS.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Если graph или start равны null.
        /// </exception>
        public static List<Vertex> Traverse(Graph graph, Vertex start, Action<string>? logger = null)
        {
            var result = new List<Vertex>();
            var visited = new HashSet<Vertex>();
            var queue = new Queue<Vertex>();

            visited.Add(start);
            queue.Enqueue(start);

            // ЛОГИРОВАНИЕ НАЧАЛА
            logger?.Invoke($"[Начало BFS] Помещаем стартовую вершину '{start}' в очередь и отмечаем как посещенную.\n");

            int step = 1;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current);

                // ЛОГИРОВАНИЕ ШАГА
                logger?.Invoke($"--- Шаг {step++} ---");
                logger?.Invoke($"Извлекли из очереди: {current}");

                var addedNeighbors = new List<string>();

                foreach (var neighbor in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                        addedNeighbors.Add(neighbor.ToString()); // Для лога
                    }
                }

                // ЛОГИРОВАНИЕ СОСТОЯНИЯ
                if (addedNeighbors.Count > 0)
                    logger?.Invoke($"Нашли новых соседей: {string.Join(", ", addedNeighbors)}. Добавляем их в очередь.");
                else
                    logger?.Invoke($"Непосещенных соседей нет.");

                logger?.Invoke($"Состояние очереди: [{(queue.Count > 0 ? string.Join(", ", queue) : "пусто")}]");
                logger?.Invoke($"Посещенные вершины: {string.Join(", ", result)}\n");
            }

            logger?.Invoke("Очередь пуста. Обход завершен!\n");
            return result;
        }


        /// <summary>
        /// Проверяет, достижима ли целевая вершина из стартовой.
        /// </summary>
        /// <param name="graph">Граф для проверки.</param>
        /// <param name="from">Стартовая вершина.</param>
        /// <param name="to">Целевая вершина.</param>
        /// <returns>
        /// <c>true</c>, если существует путь от <paramref name="from"/> 
        /// до <paramref name="to"/>; иначе <c>false</c>.
        /// </returns>
        public static bool IsReachable(Graph graph, Vertex from, Vertex to)
        {
            // Вершина всегда достижима из самой себя
            if (from.Equals(to)) return true;

            var visited = new HashSet<Vertex>();
            var queue = new Queue<Vertex>();

            visited.Add(from);
            queue.Enqueue(from);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                // Перебираем соседей
                foreach (var neighbor in graph.GetNeighbors(current))
                {
                    // Если нашли целевую вершину — сразу возвращаем true
                    if (neighbor.Equals(to)) return true;

                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            // Если очередь опустела, а целевая вершина не найдена — недостижима
            return false;
        }

        /// <summary>
        /// Находит кратчайший путь между двумя вершинами по количеству рёбер.
        /// </summary>
        /// <param name="graph">Граф для поиска пути.</param>
        /// <param name="from">Стартовая вершина.</param>
        /// <param name="to">Целевая вершина.</param>
        /// <returns>
        /// Список вершин, составляющих кратчайший путь;
        /// <c>null</c>, если путь не существует.
        /// </returns>
        /// <remarks>
        /// Поскольку BFS обходит граф по уровням, первый найденный путь
        /// до целевой вершины гарантированно является кратчайшим
        /// по количеству рёбер (для невзвешенного графа).
        /// </remarks>
        public static List<Vertex>? FindShortestPath(Graph graph, Vertex from, Vertex to)
        {
            // Путь из вершины в саму себя
            if (from.Equals(to)) return new List<Vertex> { from };

            var visited = new HashSet<Vertex>();
            var queue = new Queue<Vertex>();

            // Словарь: для каждой вершины запоминаем, из какой вершины мы в неё пришли
            var previous = new Dictionary<Vertex, Vertex?>();

            visited.Add(from);
            queue.Enqueue(from);
            previous[from] = null;  // У стартовой вершины нет предка

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var neighbor in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);

                        // Запоминаем, что в neighbor мы пришли из current
                        previous[neighbor] = current;

                        // Если достигли цели — восстанавливаем путь
                        if (neighbor.Equals(to))
                        {
                            // Восстанавливаем путь
                            var path = new List<Vertex>();
                            var step = to;

                            // Идём назад по цепочке previous, пока не дойдём до null
                            while (step != null)
                            {
                                // Вставляем в начало списка, чтобы путь был в прямом порядке
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
