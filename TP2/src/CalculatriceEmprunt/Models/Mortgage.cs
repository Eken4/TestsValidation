namespace CalculatriceEmprunt.Models
{
    public class Mortgage
    {
        public double TotalAmount { get; set; }
        public double CapitalBorrowed { get; set; }
        public int Duration { get; set; }
        public double Rate { get; set; }
        public double MonthlyRate => Rate / 12 / 100;
        public double SinglePayment { get; set; }

        public List<Payment> Payments { get; set; }

        public Mortgage(double capitalBorrowed, int duration, double rate)
        {
            this.CapitalBorrowed = capitalBorrowed;
            this.Duration = duration;
            this.Rate = rate;

            Payments = new List<Payment>();
        }

        public void Init()
        {
            this.SinglePayment = (this.CapitalBorrowed * this.MonthlyRate) / (1 - Math.Pow(1 + this.MonthlyRate, -this.Duration));
            this.TotalAmount = SinglePayment * this.Duration;
        }

        public void SetPayments()
        {
            double AmountLeft = CapitalBorrowed;

            for (int i = 1; i <= this.Duration; i++)
            {
                if (AmountLeft < SinglePayment)
                {
                    this.Payments.Add(new Payment(i, this.CapitalBorrowed, 0));
                    break;
                }

                double interestPaid = AmountLeft * (this.Rate);
                double capitalPaid = SinglePayment - interestPaid;
                AmountLeft -= capitalPaid;

                this.Payments.Add(new Payment(i, this.CapitalBorrowed - AmountLeft, AmountLeft));
            }
        }

        public string[] GetOutput()
        {
            string[] output = new string[this.Payments.Count + 2];
            output[0] = string.Join(",", "Coût total du crédit", TotalAmount.ToString());
            output[1] = string.Join(",", "Numéro de la mensualité", "Capital remboursé", "Capital restant");
            for (int i = 0; i < this.Payments.Count; i++)
            {
                output[i + 2] = Payments[i].ToString();
            }
            return output;
        }
    }
}
