using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Models
{
    public class Graph
    {
        // Список смежности: вершина → список соседей
        private readonly Dictionary<Vertex, List<Vertex>> _adjacencyList;
        private readonly Dictionary<string, Vertex> _vertexIndex;

        public IReadOnlyCollection<Vertex> Vertices => _vertexIndex.Values;
        public bool IsDirected { get; }

        public Graph(bool isDirected = false)
        {
            _adjacencyList = new Dictionary<Vertex, List<Vertex>>();
            _vertexIndex = new Dictionary<string, Vertex>();
            IsDirected = isDirected;
        }

        public void AddVertex(Vertex vertex)
        {
            if (!_vertexIndex.ContainsKey(vertex.Id))
            {
                _vertexIndex[vertex.Id] = vertex;
                _adjacencyList[vertex] = new List<Vertex>();
            }
        }

        public void AddEdge(Vertex from, Vertex to)
        {
            AddVertex(from);
            AddVertex(to);

            if (!_adjacencyList[from].Contains(to))
                _adjacencyList[from].Add(to);

            // Для неориентированного графа добавляем обратное ребро
            if (!IsDirected && !_adjacencyList[to].Contains(from))
                _adjacencyList[to].Add(from);
        }

        public IEnumerable<Vertex> GetNeighbors(Vertex vertex) =>
            _adjacencyList.TryGetValue(vertex, out var neighbors)
                ? neighbors
                : Enumerable.Empty<Vertex>();

        public Vertex? GetVertexById(string id) =>
            _vertexIndex.TryGetValue(id, out var vertex) ? vertex : null;

        public int VertexCount => _vertexIndex.Count;
        public int EdgeCount => IsDirected
            ? _adjacencyList.Values.Sum(list => list.Count)
            : _adjacencyList.Values.Sum(list => list.Count) / 2;
    }
}
