using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Models
{
    /// <summary>
    /// Представляет граф, хранящийся в виде списка смежности.
    /// </summary>
    /// <remarks>
    /// Основная структура данных для лабораторных работ №4–6.
    /// Поддерживает как ориентированные, так и неориентированные графы.
    /// Хранение в виде списка смежности обеспечивает эффективную работу
    /// с разреженными графами (O(V + E) память).
    /// </remarks>
    public class Graph
    {
        /// <summary>
        /// Список смежности: вершина → список пар (сосед, вес ребра).
        /// </summary>
        /// <remarks>
        /// Используется кортеж (Vertex, double) для хранения веса каждого ребра.
        /// Это требуется для ЛР №5 (алгоритм Дейкстры).
        /// </remarks>
        private readonly Dictionary<Vertex, List<(Vertex Neighbor, double Weight)>> _adjacencyList;

        /// <summary>
        /// Индекс для быстрого поиска вершины по идентификатору.
        /// </summary>
        private readonly Dictionary<string, Vertex> _vertexIndex;

        /// <summary>
        /// Получает коллекцию всех вершин графа (только для чтения).
        /// </summary>
        public IReadOnlyCollection<Vertex> Vertices => _vertexIndex.Values;

        /// <summary>
        /// Получает значение, указывающее, является ли граф ориентированным.
        /// </summary>
        public bool IsDirected { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Graph"/>.
        /// </summary>
        /// <param name="isDirected">
        /// <c>true</c> для ориентированного графа; 
        /// <c>false</c> для неориентированного (по умолчанию).
        /// </param>
        public Graph(bool isDirected = false)
        {
            _adjacencyList = new Dictionary<Vertex, List<(Vertex, double)>>();
            _vertexIndex = new Dictionary<string, Vertex>();
            IsDirected = isDirected;
        }

        /// <summary>
        /// Добавляет вершину в граф (склад или магазин).
        /// </summary>
        /// <param name="vertex">Вершина для добавления.</param>
        public void AddVertex(Vertex vertex)
        {
            if (vertex == null)
                throw new ArgumentNullException(nameof(vertex));

            if (!_vertexIndex.ContainsKey(vertex.Id))
            {
                _vertexIndex[vertex.Id] = vertex;
                _adjacencyList[vertex] = new List<(Vertex, double)>();
            }
        }

        /// <summary>
        /// Добавляет ребро между двумя вершинами (маршрут доставки).
        /// </summary>
        /// <param name="from">Начальная вершина (склад/магазин).</param>
        /// <param name="to">Конечная вершина (склад/магазин).</param>
        /// <param name="weight">Стоимость доставки по маршруту (по умолчанию 1.0).</param>
        /// <remarks>
        /// Для неориентированного графа добавляет ребро в обоих направлениях.
        /// Автоматически добавляет вершины, если они отсутствуют.
        /// </remarks>
        public void AddEdge(Vertex from, Vertex to, double weight = 1.0)
        {
            if (from == null) throw new ArgumentNullException(nameof(from));
            if (to == null) throw new ArgumentNullException(nameof(to));

            AddVertex(from);
            AddVertex(to);

            // Проверяем, нет ли уже такого ребра
            var existingEdge = _adjacencyList[from].FirstOrDefault(e => e.Neighbor.Equals(to));
            if (existingEdge.Neighbor == null)
            {
                _adjacencyList[from].Add((to, weight));
            }

            // Для неориентированного графа: добавляем обратное ребро
            if (!IsDirected)
            {
                var existingReverse = _adjacencyList[to].FirstOrDefault(e => e.Neighbor.Equals(from));
                if (existingReverse.Neighbor == null)
                {
                    _adjacencyList[to].Add((from, weight));
                }
            }
        }

        /// <summary>
        /// Возвращает коллекцию соседних вершин для заданной вершины.
        /// </summary>
        /// <param name="vertex">Вершина, для которой нужны соседи.</param>
        /// <returns>
        /// Перечислимая коллекция соседних вершин;
        /// пустая коллекция, если вершина не найдена.
        /// </returns>
        public IEnumerable<(Vertex Neighbor, double Weight)> GetNeighborsWithWeights(Vertex vertex) =>
            _adjacencyList.TryGetValue(vertex, out var neighbors)
                ? neighbors
                : Enumerable.Empty<(Vertex, double)>();

        /// <summary>
        /// Возвращает только соседей вершины (без весов).
        /// </summary>
        /// <remarks>
        /// Метод сохранён для совместимости с алгоритмами BFS/DFS из ЛР №4,
        /// которые не используют веса рёбер.
        /// </remarks>
        public IEnumerable<Vertex> GetNeighbors(Vertex vertex) =>
            GetNeighborsWithWeights(vertex).Select(e => e.Neighbor);

        /// <summary>
        /// Находит вершину по её уникальному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор вершины (фамилия студента).</param>
        /// <returns>
        /// Найденная вершина или <c>null</c>, если вершина не существует.
        /// </returns>
        public Vertex? GetVertexById(string id) =>
            _vertexIndex.TryGetValue(id, out var vertex) ? vertex : null;

        /// <summary>
        /// Получает количество вершин в графе.
        /// </summary>
        public int VertexCount => _vertexIndex.Count;

        /// <summary>
        /// Получает количество рёбер в графе.
        /// </summary>
        /// <remarks>
        /// Для ориентированного графа: сумма всех исходящих рёбер.
        /// Для неориентированного: делится на 2, так как каждое ребро
        /// хранится дважды (в обоих направлениях).
        /// </remarks>
        public int EdgeCount => IsDirected
            ? _adjacencyList.Values.Sum(list => list.Count)
            : _adjacencyList.Values.Sum(list => list.Count) / 2;
    }
}
