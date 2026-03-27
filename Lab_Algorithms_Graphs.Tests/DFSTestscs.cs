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
    /// Тесты для алгоритма DFS (обход в глубину)
    /// </summary>
    public class DFSTests
    {
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
            var result = DFS_Algorithm.Traverse(graph, start);

            // Assert
            Assert.Single(result);
            Assert.Contains(start, result);
        }

        /// <summary>
        /// Обход посещает все связанные вершины
        /// </summary>
        [Fact]
        public void Traverse_VisitsAllConnectedVertices()
        {
            // Arrange: полный граф из 4 вершин
            var graph = new Graph();
            var vertices = new[] {
                new Vertex("Склад_А"), new Vertex("Склад_Б"),
                new Vertex("Склад_В"), new Vertex("Склад_Г")
            };
            // Соединяем все со всеми
            for (int i = 0; i < vertices.Length; i++)
                for (int j = i + 1; j < vertices.Length; j++)
                    graph.AddEdge(vertices[i], vertices[j], 10.0);

            // Act
            var result = DFS_Algorithm.Traverse(graph, vertices[0]);

            // Assert
            Assert.Equal(4, result.Count);
            foreach (var v in vertices)
                Assert.Contains(v, result);
        }

        /// <summary>
        /// Рекурсивный обход вызывает делегат для каждой вершины
        /// </summary>
        [Fact]
        public void TraverseRecursive_CallsOnVisitForEachVertex()
        {
            // Arrange
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            graph.AddEdge(a, b, 10.0);
            graph.AddEdge(b, c, 15.0);

            var visited = new List<Vertex>();

            // Act
            DFS_Algorithm.TraverseRecursive(graph, a, visited.Add);

            // Assert
            Assert.Equal(3, visited.Count);
            Assert.Contains(a, visited);
            Assert.Contains(b, visited);
            Assert.Contains(c, visited);
        }

        /// <summary>
        /// Рекурсивный обход пропускает заранее посещённые вершины
        /// </summary>
        [Fact]
        public void TraverseRecursive_WithPreVisited_SkipsThem()
        {
            // Arrange
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            graph.AddEdge(a, b, 10.0);

            var preVisited = new HashSet<Vertex> { b };
            var visited = new List<Vertex>();

            // Act: начинаем с Склад_А, но Склад_Б уже посещён
            DFS_Algorithm.TraverseRecursive(graph, a, visited.Add, preVisited);

            // Assert
            Assert.Contains(a, visited);
            Assert.DoesNotContain(b, visited); // пропущен, т.к. уже в preVisited
        }
    }
}
