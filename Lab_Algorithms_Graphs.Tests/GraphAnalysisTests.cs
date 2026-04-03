using Lab_Algorithms_Graphs.Models;
using Lab_Algorithms_Graphs.Service;
using Xunit;

namespace Lab_Algorithms_Graphs.Tests
{
    /// <summary>
    /// Тесты для Лабораторной работы №6 (Анализ структуры и оптимизация сети)
    /// </summary>
    public class GraphAnalysisTests
    {
        #region Задача 1: Точки сочленения (Критические узлы)

        [Fact]
        public void FindArticulationPoints_LineGraph_ReturnsMiddleVertex()
        {
            // Arrange: Склад_А --- Склад_Б --- Склад_В
            // Если убрать Б, то А и В станут несвязными. Б - точка сочленения.
            var graph = new Graph();
            var a = new Vertex("А");
            var b = new Vertex("Б");
            var v = new Vertex("В");
            graph.AddEdge(a, b);
            graph.AddEdge(b, v);

            // Act
            var points = GraphAnalysis.FindArticulationPoints(graph);

            // Assert
            Assert.Contains(b, points);
            Assert.Single(points);
        }

        [Fact]
        public void FindArticulationPoints_CycleGraph_ReturnsNoPoints()
        {
            // Arrange: Замкнутое кольцо А-Б-В-А
            // Удаление любой одной вершины не разорвет связь. Точек нет.
            var graph = new Graph();
            var a = new Vertex("А");
            var b = new Vertex("Б");
            var v = new Vertex("В");
            graph.AddEdge(a, b);
            graph.AddEdge(b, v);
            graph.AddEdge(v, a);

            // Act
            var points = GraphAnalysis.FindArticulationPoints(graph);

            // Assert
            Assert.Empty(points);
        }

        #endregion

        #region Задача 2: Минимальное остовное дерево (MST)

        [Fact]
        public void GetMST_TriangleWithExpensiveEdge_ChoosesCheaperEdges()
        {
            // Arrange: Треугольник А-Б(1), Б-В(2), А-В(10)
            // MST должно выбрать ребра (1) и (2), проигнорировав (10)
            var graph = new Graph();
            var a = new Vertex("А");
            var b = new Vertex("Б");
            var v = new Vertex("В");
            graph.AddEdge(a, b, 1.0);
            graph.AddEdge(b, v, 2.0);
            graph.AddEdge(a, v, 10.0);

            // Act
            var mst = GraphAnalysis.GetMST(graph);
            double totalWeight = mst.Sum(e => e.Weight);

            // Assert
            Assert.Equal(2, mst.Count); // Для 3 вершин нужно 2 ребра
            Assert.Equal(3.0, totalWeight); // 1 + 2 = 3
        }

        #endregion

        #region Задача 3: Оптимальный хаб (Вариант 10)

        [Fact]
        public void FindDeliveryCenter_StarTopology_ReturnsCenter()
        {
            // Arrange: Звезда, где "Хаб" в центре, остальные вокруг
            // Хаб соединен со всеми (вес 1), остальные между собой не соединены.
            var graph = new Graph();
            var hub = new Vertex("Центр");
            var a = new Vertex("Магазин_А");
            var b = new Vertex("Магазин_Б");
            var v = new Vertex("Магазин_В");

            graph.AddEdge(hub, a, 1.0);
            graph.AddEdge(hub, b, 1.0);
            graph.AddEdge(hub, v, 1.0);

            // Act
            var (bestHub, totalCost) = GraphAnalysis.FindDeliveryCenter(graph);

            // Assert
            Assert.Equal(hub, bestHub);
            // Сумма путей от хаба: (0 до себя) + (1 до А) + (1 до Б) + (1 до В) = 3
            Assert.Equal(3.0, totalCost);
        }

        [Fact]
        public void FindDeliveryCenter_DisconnectedGraph_ReturnsNull()
        {
            // Arrange: Разделенный граф (Хаб-А и Б-В)
            // Нельзя найти центр для всей сети сразу.
            var graph = new Graph();
            graph.AddEdge(new Vertex("Хаб"), new Vertex("А"), 1.0);
            graph.AddEdge(new Vertex("Б"), new Vertex("В"), 1.0);

            // Act
            var (bestHub, _) = GraphAnalysis.FindDeliveryCenter(graph);

            // Assert
            Assert.Null(bestHub);
        }

        #endregion
    }
}