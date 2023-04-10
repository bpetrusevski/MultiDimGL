namespace PaymantInitiation.Models
{
    public class PaymentInstruction
    {
        public string InstructionId { get; set; }

        public string DebitAccount { get; set; }

        public string CreditAccount { get; set; } 

        public AmountType InstructedAmout { get; set; }
        public AmountType Fee { get; set; }

        public string Description { get; set; }

        public string BenReferrenceNumber { get; set; }
        public string Channel { get; set; }

    }


}
