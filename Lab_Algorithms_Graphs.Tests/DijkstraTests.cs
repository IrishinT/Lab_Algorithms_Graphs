using Lab_Algorithms_Graphs.Models;
using Lab_Algorithms_Graphs.Service;
using Xunit;

namespace Lab_Algorithms_Graphs.Tests
{
    /// <summary>
    /// Тесты для алгоритма Дейкстры (кратчайший путь во взвешенном графе)
    /// </summary>
    public class DijkstraTests
    {
        #region Тесты логики расстояний

        [Fact]
        public void Run_SingleVertex_DistanceToSelfIsZero()
        {
            // Arrange
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            graph.AddVertex(a);

            // Act
            var result = Dijkstra_Algorithm.Run(graph, a);

            // Assert
            Assert.Equal(0, result.Distances[a]);
        }

        [Fact]
        public void Run_LinearPath_ReturnsCorrectSumOfWeights()
        {
            // Arrange: Склад_А -(10)-> Склад_Б -(5.5)-> Склад_В
            var graph = new Graph(isDirected: true);
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");

            graph.AddEdge(a, b, 10.0);
            graph.AddEdge(b, c, 5.5);

            // Act
            var result = Dijkstra_Algorithm.Run(graph, a);

            // Assert
            Assert.Equal(15.5, result.Distances[c]);
        }

        [Fact]
        public void Run_ChoosesCheaperPath_NotShorterPath()
        {
            // Arrange:
            // Путь 1: А -> Б (Вес 100) — всего 1 шаг, но дорого
            // Путь 2: А -> В -> Г -> Б (Веса 5 + 5 + 5 = 15) — 3 шага, но дешево

            var graph = new Graph(isDirected: true);
            var a = new Vertex("А");
            var b = new Vertex("Б");
            var v = new Vertex("В");
            var g = new Vertex("Г");

            graph.AddEdge(a, b, 100.0); // Прямой путь
            graph.AddEdge(a, v, 5.0);
            graph.AddEdge(v, g, 5.0);
            graph.AddEdge(g, b, 5.0);

            // Act
            var result = Dijkstra_Algorithm.Run(graph, a);

            // Assert
            // Дейкстра должен выбрать путь за 15, а не за 100
            Assert.Equal(15.0, result.Distances[b]);
        }

        [Fact]
        public void Run_DisconnectedTarget_DistanceIsInfinity()
        {
            // Arrange
            var graph = new Graph();
            var a = new Vertex("А");
            var b = new Vertex("Б"); // Изолирована
            graph.AddVertex(a);
            graph.AddVertex(b);

            // Act
            var result = Dijkstra_Algorithm.Run(graph, a);

            // Assert
            Assert.Equal(double.PositiveInfinity, result.Distances[b]);
        }

        #endregion

        #region Тесты восстановления пути

        [Fact]
        public void GetPath_ValidPath_ReturnsCorrectSequence()
        {
            // Arrange: А -> В -> Б
            var graph = new Graph();
            var a = new Vertex("А");
            var b = new Vertex("Б");
            var v = new Vertex("В");
            graph.AddEdge(a, v, 1.0);
            graph.AddEdge(v, b, 1.0);

            // Act
            var result = Dijkstra_Algorithm.Run(graph, a);
            var path = Dijkstra_Algorithm.GetPath(result.Parents, b);

            // Assert
            Assert.Equal(3, path.Count);
            Assert.Equal(a, path[0]);
            Assert.Equal(v, path[1]);
            Assert.Equal(b, path[2]);
        }

        [Fact]
        public void GetPath_ToSelf_ReturnsSingleVertex()
        {
            // Arrange
            var graph = new Graph();
            var a = new Vertex("А");
            graph.AddVertex(a);

            // Act
            var result = Dijkstra_Algorithm.Run(graph, a);
            var path = Dijkstra_Algorithm.GetPath(result.Parents, a);

            // Assert
            Assert.Single(path);
            Assert.Equal(a, path[0]);
        }

        #endregion
    }
}