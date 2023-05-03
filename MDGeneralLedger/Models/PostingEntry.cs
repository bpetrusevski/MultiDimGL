using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDGeneralLedger.Models
{
    public class PostingEntry
    {

        [Key]
        public long Id { get; set; }

        public GlAccount GlAccount { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal FDebit { get; set; }
        public decimal FCredit { get; set; }
        public DateTime BookingDate { get; set; }
        public ClassificationValue<Currency> Currency { get; set; }
        public string JournalID { get; set; }
    }

}
