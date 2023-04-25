using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PositionKeeping.Models
{ 

    public class PostingEntry
    {
        [Key]
        public long PostingId { get; set; }

        [Required]
        public AccountUnit AccountUnit { get; set; }

        [Required]
        public DebitCreditFlag DC { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public ClassificationValue<TransactionType> TransactionType { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ValueDate { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(30)]
        public string InstructionRef { get; set; }
    }

}
