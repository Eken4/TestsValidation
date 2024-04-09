using CalculatriceEmprunt.Models;

namespace CalculatriceEmpruntTest
{
    public class PaymentTest
    {
        public PaymentTest() { }

        [Theory]
        [InlineData(50000, 10, 1.5, 62.5)]
        public void InterestPaidTest(decimal capital, int duration, decimal rate, decimal expectedInterest)
        {
            Mortgage mortgage = new Mortgage(capital, duration, rate);
            mortgage.Init();
            Assert.Equal(expectedInterest, mortgage.Payments[0].InterestPaid) ;
        }

        [Theory]
        [InlineData(1, 5000, 15000, 0, 0, "1,5000,15000,0,0")]
        public void ToStringTest(int id, decimal capitalPaid, decimal interestPaid, decimal amountPaid, decimal amountLeft, string expectedOutput)
        {
            Payment payment = new Payment(id, capitalPaid, interestPaid, amountPaid, amountLeft);
            Assert.Equal(expectedOutput, payment.ToString());

        }

    }
}
