using Lab_Algorithms_Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Tests
{
    /// <summary>
    /// Тесты для класса Edge (ребро графа — маршрут доставки)
    /// </summary>
    public class EdgeTests
    {
        private readonly Vertex _warehouse;
        private readonly Vertex _store;

        public EdgeTests()
        {
            _warehouse = new Vertex("Склад_А");
            _store = new Vertex("Магазин_1");
        }

        #region Конструктор

        /// <summary>
        /// Проверяет установку всех свойств в конструкторе
        /// </summary>
        [Fact]
        public void Ctor_SetsProperties()
        {
            // Act
            var edge = new Edge(_warehouse, _store, 15.5);

            // Assert
            Assert.Same(_warehouse, edge.From);
            Assert.Same(_store, edge.To);
            Assert.Equal(15.5, edge.Weight);
        }

        /// <summary>
        /// Проверяет вес по умолчанию (1.0 для невзвешенного графа ЛР №4)
        /// </summary>
        [Fact]
        public void Ctor_DefaultWeight_IsOne()
        {
            // Act
            var edge = new Edge(_warehouse, _store);

            // Assert
            Assert.Equal(1.0, edge.Weight);
        }

        #endregion

        #region Equals для неориентированного графа

        /// <summary>
        /// Рёбра с одинаковым направлением равны
        /// </summary>
        [Fact]
        public void Equals_SameDirection_ReturnsTrue()
        {
            // Arrange
            var e1 = new Edge(_warehouse, _store);
            var e2 = new Edge(_warehouse, _store);

            // Act & Assert
            Assert.True(e1.Equals(e2));
        }

        /// <summary>
        /// Для неориентированного графа рёбра А-Б и Б-А равны
        /// </summary>
        [Fact]
        public void Equals_OppositeDirection_ReturnsTrue_ForUndirected()
        {
            // Arrange
            var e1 = new Edge(_warehouse, _store);
            var e2 = new Edge(_store, _warehouse);

            // Act & Assert
            Assert.True(e1.Equals(e2)); // неориентированное ребро
        }

        /// <summary>
        /// Рёбра с разными вершинами не равны
        /// </summary>
        [Fact]
        public void Equals_DifferentVertices_ReturnsFalse()
        {
            // Arrange
            var store2 = new Vertex("Магазин_2");
            var e1 = new Edge(_warehouse, _store);
            var e2 = new Edge(_warehouse, store2);

            // Act & Assert
            Assert.False(e1.Equals(e2));
        }

        /// <summary>
        /// Сравнение с null возвращает false
        /// </summary>
        [Fact]
        public void Equals_Null_ReturnsFalse()
        {
            // Arrange
            var edge = new Edge(_warehouse, _store);

            // Act & Assert
            Assert.False(edge.Equals(null));
        }

        #endregion

        #region GetHashCode

        /// <summary>
        /// Хэш-код симметричен для неориентированного графа
        /// </summary>
        [Fact]
        public void GetHashCode_Symmetric_ForUndirected()
        {
            // Arrange
            var e1 = new Edge(_warehouse, _store);
            var e2 = new Edge(_store, _warehouse);

            // Act & Assert
            Assert.Equal(e1.GetHashCode(), e2.GetHashCode());
        }

        /// <summary>
        /// Хэш-код стабилен при множественных вызовах
        /// </summary>
        [Fact]
        public void GetHashCode_Stable()
        {
            // Arrange
            var edge = new Edge(_warehouse, _store);
            var h1 = edge.GetHashCode();
            var h2 = edge.GetHashCode();

            // Act & Assert
            Assert.Equal(h1, h2);
        }

        #endregion

        #region ToString

        /// <summary>
        /// ToString включает вершины и вес
        /// </summary>
        [Fact]
        public void ToString_IncludesVerticesAndWeight()
        {
            // Arrange
            var edge = new Edge(_warehouse, _store, 25.5);

            // Act
            var result = edge.ToString();

            // Assert
            Assert.Contains("Склад_А", result);
            Assert.Contains("Магазин_1", result);
            Assert.Contains("25,5", result);
        }

        #endregion
    }
}
