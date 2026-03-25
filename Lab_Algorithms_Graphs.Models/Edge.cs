using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Algorithms_Graphs.Models
{
    public class Edge
    {
        public Vertex From { get; }
        public Vertex To { get; }
        public double Weight { get; }  // Для ЛР №4 пока не используется, но закладываем на будущее

        public Edge(Vertex from, Vertex to, double weight = 1.0)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        // Граф неориентированный: ребро A-B эквивалентно B-A
        public override bool Equals(object? obj) =>
            obj is Edge e &&
            ((From.Equals(e.From) && To.Equals(e.To)) ||
             (From.Equals(e.To) && To.Equals(e.From)));

        public override int GetHashCode() =>
            From.GetHashCode() ^ To.GetHashCode();
    }
}
