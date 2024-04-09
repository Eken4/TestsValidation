namespace CalculatriceEmprunt.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal CapitalPaid { get; set; }
        public decimal InterestPaid { get; set; }
        public decimal CreditLeft { get; set; }
        public decimal CreditPaid { get; set; }

        public Payment(int id, decimal capitalPaid, decimal interestPaid, decimal amountPaid, decimal amountLeft)
        {
            Id = id;
            CapitalPaid = capitalPaid;
            InterestPaid = interestPaid;
            CreditPaid = amountPaid;
            CreditLeft = amountLeft;
        }

        public override string ToString()
        {
            return string.Join(",", Id, CapitalPaid, InterestPaid, CreditPaid, CreditLeft);
        }
    }
}
