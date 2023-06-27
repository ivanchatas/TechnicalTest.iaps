using TechnicalTest.iaps.Domain.Contracts;

namespace TechnicalTest.iaps.Domain.Entities
{
    public sealed class Category : BaseEntity
    { 
        public string Name { get; set; }
        public List<Paper> Papers { get; } = new();
    }
}
