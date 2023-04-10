using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PositionKeeping.Models
{ 

    [Table("PostingEntries")]
    public class PostingEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PostingId { get; set; }

        [Required]
        public AccountUnit AccountId { get; set; }

        [Required]
        public DebitCreditFlag DC { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [MaxLength(10)]
        public int TransactionType { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ValueDate { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(30)]
        public string InstructionRef { get; set; }
    }

}
