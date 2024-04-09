namespace CalculatriceEmprunt.Models
{
    public class Mortgage
    {
        public decimal CapitalBorrowed { get; set; }
        public int DurationMonths => DurationYears * 12;
        public int DurationYears { get; set; }
        public decimal Rate { get; set; }
        public decimal MonthlyRate => Rate / 12 / 100;
        public decimal SinglePayment { get; set; }

        public List<Payment> Payments { get; set; }

        public Mortgage(decimal capitalBorrowed, int durationYears, decimal rate)
        {
            this.CapitalBorrowed = capitalBorrowed;
            this.DurationYears = durationYears;
            this.Rate = rate;

            Payments = new List<Payment>();
        }

        public void Init()
        {
            decimal divider = (decimal)Math.Pow(1 + (double)this.MonthlyRate, -this.DurationMonths);
            this.SinglePayment = Math.Round((this.CapitalBorrowed * this.MonthlyRate) / (1 - divider), 2);
            SetPayments();
        }

        public void SetPayments()
        {
            decimal AmountLeft = CapitalBorrowed;

            for (int i = 1; i <= this.DurationMonths; i++)
            {
                if (AmountLeft < SinglePayment)
                {
                    this.Payments.Add(new Payment(i, 0, 0, this.CapitalBorrowed, 0));
                    break;
                }

                decimal interestPaid = Math.Round(AmountLeft * (this.MonthlyRate), 2);
                decimal capitalPaid = Math.Round(SinglePayment - interestPaid, 2);
                AmountLeft -= capitalPaid;

                this.Payments.Add(new Payment(i, capitalPaid, interestPaid, this.CapitalBorrowed - AmountLeft, AmountLeft));
            }
        }

        public string[] GetOutput()
        {
            string[] output = new string[this.Payments.Count + 1];
            output[0] = string.Join(",", "Numéro de la mensualité", "Capital remboursé ce mois ci", "Intérêts remboursés ce mois ci", "Capital remboursé", "Capital restant");
            for (int i = 0; i < this.Payments.Count; i++)
            {
                output[i + 1] = Payments[i].ToString();
            }
            return output;
        }
    }
}
