using CalculatriceEmprunt.Models;

namespace CalculatriceEmpruntTest
{
    public class MortgageTest
    {
        public MortgageTest() { }

        [Theory]
        [InlineData(1.5, 0.00125)]
        [InlineData(3, 0.00250)]
        public void MonthlyRateTest(double annualRate, double monthlyRate)
        {
            Mortgage mortgage = new Mortgage(50000, 120, annualRate);
            Assert.Equal(monthlyRate, mortgage.MonthlyRate);

        }

        [Theory]
        [InlineData(50000, 120, 1.5, 454.4907979)]
        public void SinglePaymentTest(double capitalBorrowed, int duration, double rate, double expectedPayment)
        {
            Mortgage mortgage = new Mortgage(capitalBorrowed, duration, rate);
            mortgage.Init();
            Assert.Equal(expectedPayment, mortgage.SinglePayment);

        }

        [Theory]
        [InlineData(50000, 120, 1.5, 54538.89575)]
        public void TotalAmountTest(double capitalBorrowed, int duration, double rate, double expectedAmount)
        {
            Mortgage mortgage = new Mortgage(capitalBorrowed, duration, rate);
            mortgage.Init();
            Assert.Equal(expectedAmount, mortgage.TotalAmount);

        }
    }
}
