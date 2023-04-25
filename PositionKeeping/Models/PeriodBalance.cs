using System.ComponentModel.DataAnnotations;

namespace PositionKeeping.Models
{
    public class PeriodBalance
    {
        [Key]
        public long AccountUnitId { get; set; }
        public decimal balance { get; set; }
        [Key]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
