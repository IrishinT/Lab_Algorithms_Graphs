using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Models
{
    /// <summary>
    /// Представляет ребро графа — знакомство между двумя студентами.
    /// </summary>
    /// <remarks>
    /// Для неориентированного графа (социальная сеть) ребро A-B
    /// считается эквивалентным ребру B-A. Вес ребра зарезервирован.
    /// </remarks>
    public class Edge
    {
        /// <summary>
        /// Получает начальную вершину ребра.
        /// </summary>
        public Vertex From { get; }

        /// <summary>
        /// Получает конечную вершину ребра.
        /// </summary>
        public Vertex To { get; }

        /// <summary>
        /// Получает вес ребра (расстояние, время, стоимость).
        /// </summary>
        /// <remarks>
        /// </remarks>
        public double Weight { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Edge"/>.
        /// </summary>
        /// <param name="from">Начальная вершина ребра.</param>
        /// <param name="to">Конечная вершина ребра.</param>
        /// <param name="weight">Вес ребра (по умолчанию 1.0).</param>
        public Edge(Vertex from, Vertex to, double weight = 1.0)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        /// <summary>
        /// Определяет, равно ли текущее ребро другому объекту.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>
        /// <c>true</c> для неориентированного графа, если ребра соединяют
        /// те же вершины в любом порядке (A-B = B-A);
        /// для ориентированного — только при точном совпадении направления.
        /// </returns>
        public override bool Equals(object? obj) =>
            obj is Edge e &&
            ((From.Equals(e.From) && To.Equals(e.To)) ||
             (From.Equals(e.To) && To.Equals(e.From)));

        /// <summary>
        /// Возвращает хэш-код ребра, независимый от направления
        /// (для неориентированного графа).
        /// </summary>
        /// <returns>
        /// XOR хэш-кодов вершин From и To.
        /// </returns>
        public override int GetHashCode() =>
            From.GetHashCode() ^ To.GetHashCode();

        /// <summary>
        /// Возвращает строковое представление ребра.
        /// </summary>
        /// <returns>Формат: "Склад_А → Склад_Б (вес)"</returns>
        public override string ToString() =>
            $"{From} -> {To} ({Weight})";
    }
}
