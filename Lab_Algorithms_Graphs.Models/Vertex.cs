namespace Lab_Algorithms_Graphs.Models
{
    /// <summary>
    /// Представляет вершину графа — студента в социальной сети.
    /// </summary>
    /// <remarks>
    /// Вершина используется для хранения уникального идентификатора студента
    /// и его отображаемого имени. Класс переопределяет методы сравнения
    /// для корректной работы в коллекциях (Dictionary, HashSet).
    /// </remarks>
    public class Vertex
    {
        /// <summary>
        /// Получает уникальный идентификатор вершины (фамилия студента).
        /// </summary>
        /// <value>Строка, используемая как ключ для поиска вершины.</value>
        public string Id { get; }      // Уникальный идентификатор (имя студента)

        /// <summary>
        /// Получает отображаемое имя вершины для интерфейса пользователя.
        /// </summary>
        /// <value>Читаемое название, по умолчанию совпадает с Id.</value>
        public string Label { get; }   // Отображаемое имя

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Vertex"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор вершины (фамилия).</param>
        /// <param name="label">Отображаемое имя (опционально, по умолчанию = id).</param>
        public Vertex(string id, string? label = null)
        {
            Id = id;

            // Если label не передан, используем id как отображаемое имя
            Label = label ?? id;
        }

        /// <summary>
        /// Возвращает строковое представление вершины (отображаемое имя).
        /// </summary>
        /// <returns>Значение свойства <see cref="Label"/>.</returns>
        public override string ToString() => Label;

        /// <summary>
        /// Определяет, равна ли текущая вершина другому объекту.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>
        /// <c>true</c>, если объекты являются вершинами с одинаковым Id;
        /// иначе <c>false</c>.
        /// </returns>
        public override bool Equals(object? obj) => obj is Vertex v && Id == v.Id;

        /// <summary>
        /// Возвращает хэш-код вершины на основе её идентификатора.
        /// </summary>
        /// <returns>Хэш-код строки <see cref="Id"/>.</returns>
        public override int GetHashCode() => Id.GetHashCode();
    }
}
