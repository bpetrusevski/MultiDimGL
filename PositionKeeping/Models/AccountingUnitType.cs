using System.ComponentModel.DataAnnotations;

namespace PositionKeeping.Models
{
    public class AccountingUnitType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ClassificationValue<AccountingCategory> AccountingCategory { get; set; }
        public DebitCreditFlag AL { get; set; }
    }
}
