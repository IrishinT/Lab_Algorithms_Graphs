using Lab_Algorithms_Graphs.Models;

namespace Lab_Algorithms_Graphs.Service
{
    public static class Dijkstra_Algorithm
    {
        public static (Dictionary<Vertex, double> Distances, Dictionary<Vertex, Vertex?> Parents) Run(Graph graph, Vertex start)
        {
            var distances = new Dictionary<Vertex, double>();
            var parents = new Dictionary<Vertex, Vertex?>();
            var visited = new HashSet<Vertex>();

            // Инициализация: расстояния бесконечны, родителей нет
            foreach (var v in graph.Vertices)
            {
                distances[v] = double.PositiveInfinity;
                parents[v] = null;
            }
            distances[start] = 0;

            for (int i = 0; i < graph.VertexCount; i++)
            {
                // Находим непосещенную вершину с минимальным расстоянием
                Vertex? current = null;
                double minDistance = double.PositiveInfinity;

                foreach (var v in graph.Vertices)
                {
                    if (!visited.Contains(v) && distances[v] < minDistance)
                    {
                        minDistance = distances[v];
                        current = v;
                    }
                }

                if (current == null) break; // Все достижимые вершины посещены
                visited.Add(current);

                // Релаксация ребер
                foreach (var edge in graph.GetNeighborsWithWeights(current))
                {
                    double newDist = distances[current] + edge.Weight;
                    if (newDist < distances[edge.Neighbor])
                    {
                        distances[edge.Neighbor] = newDist;
                        parents[edge.Neighbor] = current;
                    }
                }
            }

            return (distances, parents);
        }

        // Метод для восстановления пути
        public static List<Vertex> GetPath(Dictionary<Vertex, Vertex?> parents, Vertex target)
        {
            var path = new List<Vertex>();
            Vertex? current = target;
            while (current != null)
            {
                path.Add(current);
                current = parents[current];
            }
            path.Reverse();
            return path;
        }
    }
}