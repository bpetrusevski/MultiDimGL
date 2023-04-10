using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounts.Database
{
    [Table("Accounts")]
    public abstract class AccountArrangement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AccountId { get; set; }

        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }
        
        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(20)]
        public string CustomerID { get; set; }

        public decimal PendingDebit { get; set; }
        public decimal PendingCredit { get; set; }
        public decimal BalanceDebit { get; set; }
        public decimal BalanceCredit { get; set; }
        public decimal Balance { get; set; }
        public List<long> AccountUnits { get; set; }

    }
}
