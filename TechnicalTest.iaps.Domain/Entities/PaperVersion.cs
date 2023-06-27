using TechnicalTest.iaps.Domain.Contracts;

namespace TechnicalTest.iaps.Domain.Entities
{
    public class PaperVersion : BaseEntity
    {
        public string Version { get; set; }
        public DateTime Created { get; set; }
        public string PaperId { get; set; }
        public virtual Paper Paper { get; set; }
    }
}
