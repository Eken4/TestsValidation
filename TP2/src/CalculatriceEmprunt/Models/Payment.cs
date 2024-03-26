namespace CalculatriceEmprunt.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public double AmountLeft { get; set; }
        public double AmountPaid { get; set; }

        public Payment(int id, double amountPaid, double amountLeft)
        {
            Id = id;
            AmountPaid = amountPaid;
            AmountLeft = amountLeft;
        }

        public string ToString()
        {
            return string.Join(",", Id, AmountPaid, AmountLeft);
        }
    }
}
