using Lab_Algorithms_Graphs.Models;

namespace Lab_Algorithms_Graphs.Tests
{
    /// <summary>
    /// Тесты для класса Vertex (вершина графа — склад или магазин)
    /// </summary>
    public class VertexTests
    {
        #region Конструктор

        /// <summary>
        /// Проверяет создание вершины с указанным идентификатором
        /// </summary>
        [Fact]
        public void Ctor_WithId_SetsIdProperty()
        {
            // Arrange
            var id = "Склад_Центральный";

            // Act
            var vertex = new Vertex(id);

            // Assert
            Assert.Equal(id, vertex.Id);
        }

        /// <summary>
        /// Проверяет, что Label по умолчанию равен Id
        /// </summary>
        [Fact]
        public void Ctor_WithoutLabel_SetsLabelEqualToId()
        {
            // Arrange & Act
            var vertex = new Vertex("Магазин_1");

            // Assert
            Assert.Equal("Магазин_1", vertex.Label);
        }

        /// <summary>
        /// Проверяет, что можно задать кастомный Label
        /// </summary>
        [Fact]
        public void Ctor_WithLabel_SetsCustomLabel()
        {
            // Arrange
            var id = "Склад_Север";
            var label = "СХ-1";

            // Act
            var vertex = new Vertex(id, label);

            // Assert
            Assert.Equal(id, vertex.Id);
            Assert.Equal(label, vertex.Label);
        }

        #endregion

        #region ToString

        /// <summary>
        /// ToString() должен возвращать Label
        /// </summary>
        [Fact]
        public void ToString_ReturnsLabel()
        {
            // Arrange
            var vertex = new Vertex("Склад_Юг", "СХ-2");

            // Act
            var result = vertex.ToString();

            // Assert
            Assert.Equal("СХ-2", result);
        }

        #endregion

        #region Equals и GetHashCode

        /// <summary>
        /// Две вершины с одинаковым Id считаются равными
        /// </summary>
        [Fact]
        public void Equals_SameId_ReturnsTrue()
        {
            // Arrange
            var v1 = new Vertex("Склад_Восток");
            var v2 = new Vertex("Склад_Восток");

            // Act & Assert
            Assert.True(v1.Equals(v2));
            Assert.True(v2.Equals(v1));
        }

        /// <summary>
        /// Вершины с разными Id не равны
        /// </summary>
        [Fact]
        public void Equals_DifferentId_ReturnsFalse()
        {
            // Arrange
            var v1 = new Vertex("Склад_Запад");
            var v2 = new Vertex("Магазин_1");

            // Act & Assert
            Assert.False(v1.Equals(v2));
        }

        /// <summary>
        /// Сравнение с null возвращает false
        /// </summary>
        [Fact]
        public void Equals_Null_ReturnsFalse()
        {
            // Arrange
            var vertex = new Vertex("Распределитель_А");

            // Act & Assert
            Assert.False(vertex.Equals(null));
        }

        /// <summary>
        /// Сравнение с объектом другого типа возвращает false
        /// </summary>
        [Fact]
        public void Equals_DifferentType_ReturnsFalse()
        {
            // Arrange
            var vertex = new Vertex("Распределитель_Б");
            var other = "Распределитель_Б"; // строка, не вершина

            // Act & Assert
            Assert.False(vertex.Equals(other));
        }

        /// <summary>
        /// Равные вершины имеют одинаковый хэш-код
        /// </summary>
        [Fact]
        public void GetHashCode_SameId_ReturnsSameHash()
        {
            // Arrange
            var v1 = new Vertex("Магазин_2");
            var v2 = new Vertex("Магазин_2");

            // Act & Assert
            Assert.Equal(v1.GetHashCode(), v2.GetHashCode());
        }

        /// <summary>
        /// GetHashCode стабильно возвращает одно значение для одного объекта
        /// </summary>
        [Fact]
        public void GetHashCode_MultipleCalls_ReturnsSameValue()
        {
            // Arrange
            var vertex = new Vertex("Магазин_3");
            var hash1 = vertex.GetHashCode();
            var hash2 = vertex.GetHashCode();

            // Act & Assert
            Assert.Equal(hash1, hash2);
        }

        #endregion

        #region Работа в коллекциях

        /// <summary>
        /// Vertex можно использовать как ключ в Dictionary
        /// </summary>
        [Fact]
        public void CanBeUsedAsDictionaryKey()
        {
            // Arrange
            var dict = new Dictionary<Vertex, int>();
            var vertex = new Vertex("Магазин_4");

            // Act
            dict[vertex] = 42;
            var lookup = new Vertex("Магазин_4"); // новая инстанция с тем же Id
            bool found = dict.TryGetValue(lookup, out var value);

            // Assert
            Assert.True(found);
            Assert.Equal(42, value);
        }

        /// <summary>
        /// HashSet не допускает дубликатов вершин с одинаковым Id
        /// </summary>
        [Fact]
        public void HashSet_PreventsDuplicatesByHashCode()
        {
            // Arrange
            var set = new HashSet<Vertex>();
            var v1 = new Vertex("Магазин_5");
            var v2 = new Vertex("Магазин_5");

            // Act
            set.Add(v1);
            var added = set.Add(v2); // попытка добавить дубликат

            // Assert
            Assert.False(added); // не добавлен, т.к. равен v1
            Assert.Single(set);
        }

        #endregion
    }
}