using System.ComponentModel.DataAnnotations;

namespace PositionKeeping.Models
{
    public class AccountingUnitType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
