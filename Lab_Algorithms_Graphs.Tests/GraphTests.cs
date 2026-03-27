using Lab_Algorithms_Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Tests
{
    /// <summary>
    /// Тесты для класса Graph (список смежности с весами)
    /// </summary>
    public class GraphTests
    {
        #region Конструктор и свойства

        /// <summary>
        /// Граф по умолчанию неориентированный
        /// </summary>
        [Fact]
        public void Ctor_Default_IsUndirected()
        {
            // Act
            var graph = new Graph();

            // Assert
            Assert.False(graph.IsDirected);
        }

        /// <summary>
        /// Можно создать ориентированный граф
        /// </summary>
        [Fact]
        public void Ctor_WithIsDirected_SetsProperty()
        {
            // Act
            var graph = new Graph(isDirected: true);

            // Assert
            Assert.True(graph.IsDirected);
        }

        /// <summary>
        /// Пустой граф имеет 0 вершин и рёбер
        /// </summary>
        [Fact]
        public void EmptyGraph_HasZeroVerticesAndEdges()
        {
            // Arrange
            var graph = new Graph();

            // Act & Assert
            Assert.Empty(graph.Vertices);
            Assert.Equal(0, graph.VertexCount);
            Assert.Equal(0, graph.EdgeCount);
        }

        #endregion

        #region AddVertex

        /// <summary>
        /// Добавление новой вершины увеличивает счётчик
        /// </summary>
        [Fact]
        public void AddVertex_NewVertex_IncreasesCount()
        {
            // Arrange
            var graph = new Graph();
            var v = new Vertex("Склад_1");

            // Act
            graph.AddVertex(v);

            // Assert
            Assert.Contains(v, graph.Vertices);
            Assert.Equal(1, graph.VertexCount);
        }

        /// <summary>
        /// Добавление вершины с тем же Id не создаёт дубликат
        /// </summary>
        [Fact]
        public void AddVertex_DuplicateById_DoesNotIncreaseCount()
        {
            // Arrange
            var graph = new Graph();
            var v1 = new Vertex("Склад_2");
            var v2 = new Vertex("Склад_2"); // тот же Id

            // Act
            graph.AddVertex(v1);
            graph.AddVertex(v2);

            // Assert
            Assert.Equal(1, graph.VertexCount);
        }

        /// <summary>
        /// Добавление null вершины вызывает исключение
        /// </summary>
        [Fact]
        public void AddVertex_Null_Throws()
        {
            // Arrange
            var graph = new Graph();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => graph.AddVertex(null!));
        }

        #endregion

        #region AddEdge

        /// <summary>
        /// Для неориентированного графа ребро добавляется в обе стороны
        /// </summary>
        [Fact]
        public void AddEdge_Undirected_AddsBothDirections()
        {
            // Arrange
            var graph = new Graph(isDirected: false);
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");

            // Act
            graph.AddEdge(a, b, 10.0);

            // Assert
            Assert.Contains(b, graph.GetNeighbors(a));
            Assert.Contains(a, graph.GetNeighbors(b));
            Assert.Equal(1, graph.EdgeCount); // одно ребро, не два!
        }

        /// <summary>
        /// Для ориентированного графа ребро добавляется в одну сторону
        /// </summary>
        [Fact]
        public void AddEdge_Directed_AddsOneDirection()
        {
            // Arrange
            var graph = new Graph(isDirected: true);
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");

            // Act
            graph.AddEdge(a, b, 10.0);

            // Assert
            Assert.Contains(b, graph.GetNeighbors(a));
            Assert.DoesNotContain(a, graph.GetNeighbors(b));
            Assert.Equal(1, graph.EdgeCount);
        }

        /// <summary>
        /// Повторное добавление того же ребра не создаёт дубликат
        /// </summary>
        [Fact]
        public void AddEdge_Duplicate_DoesNotIncreaseCount()
        {
            // Arrange
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");

            // Act
            graph.AddEdge(a, b, 10.0);
            graph.AddEdge(a, b, 10.0); // повтор

            // Assert
            Assert.Equal(1, graph.EdgeCount);
        }

        /// <summary>
        /// Добавление ребра с null начальной вершиной вызывает исключение
        /// </summary>
        [Fact]
        public void AddEdge_NullFrom_Throws()
        {
            // Arrange
            var graph = new Graph();
            var b = new Vertex("Склад_Б");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => graph.AddEdge(null!, b));
        }

        /// <summary>
        /// Добавление ребра с null конечной вершиной вызывает исключение
        /// </summary>
        [Fact]
        public void AddEdge_NullTo_Throws()
        {
            // Arrange
            var graph = new Graph();
            var a = new Vertex("Склад_А");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => graph.AddEdge(a, null!));
        }

        #endregion

        #region GetNeighbors

        /// <summary>
        /// Изолированная вершина не имеет соседей
        /// </summary>
        [Fact]
        public void GetNeighbors_IsolatedVertex_ReturnsEmpty()
        {
            // Arrange
            var graph = new Graph();
            var v = new Vertex("Склад_Изолированный");
            graph.AddVertex(v);

            // Act
            var neighbors = graph.GetNeighbors(v);

            // Assert
            Assert.Empty(neighbors);
        }

        /// <summary>
        /// Запрос соседей несуществующей вершины возвращает пустую коллекцию (не исключение)
        /// </summary>
        [Fact]
        public void GetNeighbors_UnknownVertex_ReturnsEmpty_NotThrows()
        {
            // Arrange
            var graph = new Graph();
            var unknown = new Vertex("Несуществующий");

            // Act
            var neighbors = graph.GetNeighbors(unknown);

            // Assert
            Assert.Empty(neighbors); // безопасно, не исключение
        }

        #endregion

        #region GetVertexById

        /// <summary>
        /// Поиск существующей вершины возвращает её
        /// </summary>
        [Fact]
        public void GetVertexById_Exists_ReturnsVertex()
        {
            // Arrange
            var graph = new Graph();
            var v = new Vertex("Склад_Тест");
            graph.AddVertex(v);

            // Act
            var result = graph.GetVertexById("Склад_Тест");

            // Assert
            Assert.Same(v, result);
        }

        /// <summary>
        /// Поиск несуществующей вершины возвращает null
        /// </summary>
        [Fact]
        public void GetVertexById_NotExists_ReturnsNull()
        {
            // Arrange
            var graph = new Graph();

            // Act
            var result = graph.GetVertexById("НетТакого");

            // Assert
            Assert.Null(result);
        }

        #endregion

        #region EdgeCount calculation

        /// <summary>
        /// Для неориентированного графа счётчик рёбер делит на 2
        /// </summary>
        [Fact]
        public void EdgeCount_Undirected_DividesByTwo()
        {
            // Arrange
            var graph = new Graph(isDirected: false);
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            graph.AddEdge(a, b, 10.0);
            graph.AddEdge(b, c, 15.0);

            // Act & Assert
            Assert.Equal(2, graph.EdgeCount); // не 4!
        }

        /// <summary>
        /// Для ориентированного графа счётчик не делит
        /// </summary>
        [Fact]
        public void EdgeCount_Directed_DoesNotDivide()
        {
            // Arrange
            var graph = new Graph(isDirected: true);
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            graph.AddEdge(a, b, 10.0);
            graph.AddEdge(b, c, 15.0);

            // Act & Assert
            Assert.Equal(2, graph.EdgeCount);
        }

        #endregion

        #region GetNeighborsWithWeights

        /// <summary>
        /// Метод возвращает соседей с весами рёбер
        /// </summary>
        [Fact]
        public void GetNeighborsWithWeights_ReturnsWeightedEdges()
        {
            // Arrange
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            graph.AddEdge(a, b, 25.0);

            // Act
            var neighbors = graph.GetNeighborsWithWeights(a);

            // Assert
            var neighborList = neighbors.ToList();
            Assert.Single(neighborList);
            Assert.Same(b, neighborList[0].Neighbor);
            Assert.Equal(25.0, neighborList[0].Weight);
        }

        #endregion
    }
}
