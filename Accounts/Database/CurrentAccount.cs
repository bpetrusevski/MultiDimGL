namespace Accounts.Database
{
    public class CurrentAccount : AccountArrangement
    {
        public decimal Limit { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal PendingDebit { get; set; }
        public decimal PendingCredit { get; set; }
        public decimal LedgerBalance { get; set; }

    }
}
