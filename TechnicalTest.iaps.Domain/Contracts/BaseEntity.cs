using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.iaps.Domain.Contracts
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
