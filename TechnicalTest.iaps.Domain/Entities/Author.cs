using TechnicalTest.iaps.Domain.Contracts;

namespace TechnicalTest.iaps.Domain.Entities
{
    public sealed class Author : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Initials { get; set; }
        public List<Paper> Papers { get; } = new();
    }
}
