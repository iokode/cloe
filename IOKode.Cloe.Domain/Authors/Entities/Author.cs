using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Domain.Authors.Entities
{
    public class Author
    {
        public Id<Author>? Id { get; set; }
        public string Name { get; set; }
    }
}