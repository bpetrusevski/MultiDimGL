using System.ComponentModel.DataAnnotations;

namespace PositionKeeping.Models
{
    public class AccountUnit
    {
        [Key]
        public long Id { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public PositionTypes PositionType { get; set; }
        public string Name { get; set; }
        public decimal AccruedInterest { get; set; }

        public List<AccountUnitBalance> PeriodBalances { get; set; }
    }
}
