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
    /// Тесты для анализа связности графа
    /// </summary>
    public class ConnectivityTests
    {
        /// <summary>
        /// Связный граф имеет одну компоненту
        /// </summary>
        [Fact]
        public void FindConnectedComponents_SingleComponent_ReturnsOneList()
        {
            // Arrange: связный граф Склад_А-Склад_Б-Склад_В
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            graph.AddEdge(a, b, 10.0);
            graph.AddEdge(b, c, 15.0);

            // Act
            var components = Connectivity.FindConnectedComponents(graph);

            // Assert
            Assert.Single(components);
            Assert.Equal(3, components[0].Count);
        }

        /// <summary>
        /// Граф с двумя компонентами возвращает два списка
        /// </summary>
        [Fact]
        public void FindConnectedComponents_TwoComponents_ReturnsTwoLists()
        {
            // Arrange: Склад_А-Склад_Б и Склад_В-Склад_Г (две компоненты)
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            var d = new Vertex("Склад_Г");
            graph.AddEdge(a, b, 10.0);
            graph.AddEdge(c, d, 15.0);

            // Act
            var components = Connectivity.FindConnectedComponents(graph);

            // Assert
            Assert.Equal(2, components.Count);
            Assert.Equal(2, components[0].Count);
            Assert.Equal(2, components[1].Count);
        }

        /// <summary>
        /// Изолированные вершины — каждая отдельная компонента
        /// </summary>
        [Fact]
        public void FindConnectedComponents_IsolatedVertices_EachIsSeparateComponent()
        {
            // Arrange: три изолированные вершины
            var graph = new Graph();
            var a = new Vertex("Склад_А");
            var b = new Vertex("Склад_Б");
            var c = new Vertex("Склад_В");
            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);

            // Act
            var components = Connectivity.FindConnectedComponents(graph);

            // Assert
            Assert.Equal(3, components.Count);
            foreach (var component in components)
                Assert.Single(component);
        }

        /// <summary>
        /// Для ориентированного графа выбрасывается исключение
        /// </summary>
        [Fact]
        public void FindConnectedComponents_DirectedGraph_Throws()
        {
            // Arrange
            var graph = new Graph(isDirected: true);
            graph.AddVertex(new Vertex("Склад_А"));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                Connectivity.FindConnectedComponents(graph));
        }

        /// <summary>
        /// Связный граф возвращает true
        /// </summary>
        [Fact]
        public void IsConnected_SingleComponent_ReturnsTrue()
        {
            // Arrange
            var graph = new Graph();
            graph.AddEdge(new Vertex("Склад_А"), new Vertex("Склад_Б"), 10.0);
            graph.AddEdge(new Vertex("Склад_Б"), new Vertex("Склад_В"), 15.0);

            // Act & Assert
            Assert.True(Connectivity.IsConnected(graph));
        }

        /// <summary>
        /// Несвязный граф возвращает false
        /// </summary>
        [Fact]
        public void IsConnected_MultipleComponents_ReturnsFalse()
        {
            // Arrange
            var graph = new Graph();
            graph.AddEdge(new Vertex("Склад_А"), new Vertex("Склад_Б"), 10.0);
            graph.AddVertex(new Vertex("Склад_В")); // изолирована

            // Act & Assert
            Assert.False(Connectivity.IsConnected(graph));
        }

        /// <summary>
        /// Пустой граф считается связным (по определению)
        /// </summary>
        [Fact]
        public void IsConnected_EmptyGraph_ReturnsTrue_ByDefinition()
        {
            // Arrange
            var graph = new Graph();

            // Act & Assert
            Assert.True(Connectivity.IsConnected(graph));
        }
    }
}
