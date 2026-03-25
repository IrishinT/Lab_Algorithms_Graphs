namespace Lab_Algorithms_Graphs.Models
{
    public class Vertex
    {
        public string Id { get; }      // Уникальный идентификатор (имя студента)
        public string Label { get; }   // Отображаемое имя

        public Vertex(string id, string? label = null)
        {
            Id = id;
            Label = label ?? id;
        }

        public override string ToString() => Label;
        public override bool Equals(object? obj) => obj is Vertex v && Id == v.Id;
        public override int GetHashCode() => Id.GetHashCode();
    }
}
