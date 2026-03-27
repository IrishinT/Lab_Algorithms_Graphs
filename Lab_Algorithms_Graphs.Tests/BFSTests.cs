using Lab_Algorithms_Graphs.Models;
using Lab_Algorithms_Graphs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Tests
{
    /// <summary>
    /// Тесты для алгоритма BFS (обход в ширину)
    /// </summary>
    public class BFSTests
    {
        #region Traverse

        /// <summary>
        /// Обход графа с одной вершиной возвращает эту вершину
        /// </summary>
        [Fact]
        public void Traverse_SingleVertex_ReturnsThatVertex()
        {
            // Arrange
            var graph = new Graph();
            var start = new Vertex("Склад_А");
            graph.AddVertex(start);

            // Act
            var result = BFS_Algorithm.Traverse(graph, start);

            // Assert
            Assert.Single(result);
            Assert.Contains(start, result);
        }

        /// <summary>
        /// Обход линейного графа посещает вершины по уровням
        /// </summary>
        [Fact]
        public void Traverse_LinearGraph_VisitsInOrder()
        {
            // Arrange: Склад_А — Склад_Б — Склад_В
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            graph.AddEdge(a, b, 10.0);
            graph.AddEdge(b, c, 15.0);

            // Act
            var result = BFS_Algorithm.Traverse(graph, a);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(a, result[0]); // начинаем с А
            Assert.Contains(b, result);
            Assert.Contains(c, result);
        }

        /// <summary>
        /// Обход несвязного графа посещает только компоненту стартовой вершины
        /// </summary>
        [Fact]
        public void Traverse_DisconnectedGraph_VisitsOnlyConnectedComponent()
        {
            // Arrange: Склад_А-Склад_Б и Склад_В (изолирован)
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            graph.AddEdge(a, b, 10.0);
            graph.AddVertex(c);

            // Act
            var result = BFS_Algorithm.Traverse(graph, a);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.DoesNotContain(c, result);
        }

        /// <summary>
        /// Передача null стартовой вершины вызывает исключение
        /// </summary>
        [Fact]
        public void Traverse_NullStart_Throws()
        {
            // Arrange
            var graph = new Graph();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                BFS_Algorithm.Traverse(graph, null!));
        }

        #endregion

        #region IsReachable

        /// <summary>
        /// Вершина достижима из самой себя
        /// </summary>
        [Fact]
        public void IsReachable_SameVertex_ReturnsTrue()
        {
            // Arrange
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            graph.AddVertex(a);

            // Act
            var result = BFS_Algorithm.IsReachable(graph, a, a);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Связанные вершины достижимы
        /// </summary>
        [Fact]
        public void IsReachable_Connected_ReturnsTrue()
        {
            // Arrange: Склад_А — Склад_Б — Склад_В
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            graph.AddEdge(a, b, 10.0);
            graph.AddEdge(b, c, 15.0);

            // Act
            var result = BFS_Algorithm.IsReachable(graph, a, c);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Несвязанные вершины недостижимы
        /// </summary>
        [Fact]
        public void IsReachable_Disconnected_ReturnsFalse()
        {
            // Arrange: две несвязные компоненты
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            var d = new Vertex("Склад_Г");
            graph.AddEdge(a, b, 10.0);
            graph.AddEdge(c, d, 15.0);

            // Act
            var result = BFS_Algorithm.IsReachable(graph, a, c);

            // Assert
            Assert.False(result);
        }

        #endregion

        #region FindShortestPath

        /// <summary>
        /// Путь из вершины в саму себя содержит одну вершину
        /// </summary>
        [Fact]
        public void FindShortestPath_SameVertex_ReturnsSingleVertexPath()
        {
            // Arrange
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            graph.AddVertex(a);

            // Act
            var path = BFS_Algorithm.FindShortestPath(graph, a, a);

            // Assert
            Assert.NotNull(path);
            Assert.Single(path);
            Assert.Contains(a, path);
        }

        /// <summary>
        /// Находит корректный путь в линейном графе
        /// </summary>
        [Fact]
        public void FindShortestPath_Linear_ReturnsCorrectPath()
        {
            // Arrange: Склад_А — Склад_Б — Склад_В — Склад_Г
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            var d = new Vertex("Склад_Г");
            graph.AddEdge(a, b, 10.0);
            graph.AddEdge(b, c, 15.0);
            graph.AddEdge(c, d, 20.0);

            // Act
            var path = BFS_Algorithm.FindShortestPath(graph, a, d);

            // Assert
            Assert.NotNull(path);
            Assert.Equal(4, path.Count);
            Assert.Equal(a, path[0]);
            Assert.Equal(d, path[^1]); // последний элемент
            Assert.Contains(b, path);
            Assert.Contains(c, path);
        }

        /// <summary>
        /// Если пути нет — возвращает null
        /// </summary>
        [Fact]
        public void FindShortestPath_NoPath_ReturnsNull()
        {
            // Arrange: две несвязные компоненты
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            graph.AddEdge(a, b, 10.0);
            graph.AddVertex(c);

            // Act
            var path = BFS_Algorithm.FindShortestPath(graph, a, c);

            // Assert
            Assert.Null(path);
        }

        /// <summary>
        /// При нескольких путях возвращает кратчайший по количеству рёбер
        /// </summary>
        [Fact]
        public void FindShortestPath_MultiplePaths_ReturnsShortest()
        {
            // Arrange:
            //   Склад_А — Склад_Б — Склад_В
            //   |                       |
            //   Склад_Г ———————— Склад_Д
            // Кратчайший путь Склад_А→Склад_Д: Склад_А-Склад_Г-Склад_Д (2 ребра)
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            var d = new Vertex("Склад_Г");
            var e = new Vertex("Склад_Д");

            graph.AddEdge(a, b, 10.0);
            graph.AddEdge(b, c, 15.0);
            graph.AddEdge(c, e, 20.0);
            graph.AddEdge(a, d, 12.0);
            graph.AddEdge(d, e, 18.0);

            // Act
            var path = BFS_Algorithm.FindShortestPath(graph, a, e);

            // Assert
            Assert.NotNull(path);
            Assert.Equal(3, path.Count); // Склад_А, Склад_Г, Склад_Д = 3 вершины, 2 ребра
            Assert.Equal(a, path[0]);
            Assert.Equal(e, path[^1]);
        }

        #endregion
    }
}
