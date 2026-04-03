using Lab_Algorithms_Graphs.Models;

namespace Lab_Algorithms_Graphs.Service
{
    public static class GraphAnalysis
    {
        // Вспомогательные поля для поиска точек сочленения
        private static int _timer;
        private static Dictionary<Vertex, int> _tin; // Время захода в вершину
        private static Dictionary<Vertex, int> _low; // Минимальное время захода в поддерево
        private static HashSet<Vertex> _articulationPoints;

        // --- ЗАДАЧА 1: Поиск точек сочленения ---
        public static List<Vertex> FindArticulationPoints(Graph graph)
        {
            _timer = 0;
            _tin = new Dictionary<Vertex, int>();
            _low = new Dictionary<Vertex, int>();
            _articulationPoints = new HashSet<Vertex>();

            foreach (var v in graph.Vertices)
            {
                if (!_tin.ContainsKey(v))
                    DFS_Articulation(graph, v, null);
            }
            return _articulationPoints.ToList();
        }

        private static void DFS_Articulation(Graph graph, Vertex v, Vertex? p)
        {
            _tin[v] = _low[v] = ++_timer;
            int children = 0;

            foreach (var to in graph.GetNeighbors(v))
            {
                if (to.Equals(p)) continue;
                if (_tin.ContainsKey(to))
                {
                    _low[v] = Math.Min(_low[v], _tin[to]);
                }
                else
                {
                    DFS_Articulation(graph, to, v);
                    _low[v] = Math.Min(_low[v], _low[to]);
                    if (_low[to] >= _tin[v] && p != null)
                        _articulationPoints.Add(v);
                    children++;
                }
            }
            if (p == null && children > 1)
                _articulationPoints.Add(v);
        }

        // --- ЗАДАЧА 2: Минимальное остовное дерево (Алгоритм Прима) ---
        public static List<Edge> GetMST(Graph graph)
        {
            var resultEdges = new List<Edge>();
            if (graph.VertexCount == 0) return resultEdges;

            var visited = new HashSet<Vertex>();
            var start = graph.Vertices.First();
            visited.Add(start);

            while (visited.Count < graph.VertexCount)
            {
                Edge? minEdge = null;

                foreach (var u in visited)
                {
                    foreach (var neighbor in graph.GetNeighborsWithWeights(u))
                    {
                        if (!visited.Contains(neighbor.Neighbor))
                        {
                            if (minEdge == null || neighbor.Weight < minEdge.Weight)
                                minEdge = new Edge(u, neighbor.Neighbor, neighbor.Weight);
                        }
                    }
                }

                if (minEdge == null) break; // Граф несвязный

                visited.Add(minEdge.To);
                resultEdges.Add(minEdge);
            }
            return resultEdges;
        }

        // --- ЗАДАЧА 3 (Вариант 10): Оптимальный логистический хаб ---
        // Ищем вершину, сумма кратчайших путей от которой до всех остальных минимальна
        public static (Vertex? Hub, double TotalDistance) FindDeliveryCenter(Graph graph)
        {
            Vertex? bestHub = null;
            double minTotalDistance = double.PositiveInfinity;

            foreach (var candidate in graph.Vertices)
            {
                // Используем уже готовый алгоритм Дейкстры из ЛР №5
                var (distances, _) = Dijkstra_Algorithm.Run(graph, candidate);

                double currentSum = 0;
                bool isPossible = true;

                foreach (var d in distances.Values)
                {
                    if (double.IsPositiveInfinity(d)) { isPossible = false; break; }
                    currentSum += d;
                }

                if (isPossible && currentSum < minTotalDistance)
                {
                    minTotalDistance = currentSum;
                    bestHub = candidate;
                }
            }
            return (bestHub, minTotalDistance);
        }
    }
}