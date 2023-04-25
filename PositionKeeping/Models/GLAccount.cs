using System.ComponentModel.DataAnnotations;

namespace PositionKeeping.Models
{
    public class GLAccount
    {
        [Key]
        public string AccountNumber { get; set; }
        [Required]
        public string Name { get; set; }
        public DebitCreditFlag AL { get; set; }

        public ClassificationValue<AccountingCategory> AccountingCategory { get; set; }
    }
}
