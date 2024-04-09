using CalculatriceEmprunt.Models;

namespace CalculatriceEmpruntTest
{
    public class MortgageTest
    {
        public MortgageTest() { }

        [Theory]
        [InlineData(1.5, 0.00125)]
        [InlineData(3, 0.00250)]
        public void MonthlyRateTest(decimal annualRate, decimal expectedMonthlyRate)
        {
            Mortgage mortgage = new Mortgage(50000, 120, annualRate);
            Assert.Equal(expectedMonthlyRate, mortgage.MonthlyRate);

        }

        [Theory]
        [InlineData(50000, 10, 1.5, 448.96)]
        [InlineData(100000, 12, 4, 875.53)]
        [InlineData(75492, 9, 2.7, 788.15)]
        [InlineData(150000, 25, 3, 711.32)]
        public void SinglePaymentTest(decimal capitalBorrowed, int duration, decimal rate, decimal expectedPayment)
        {
            Mortgage mortgage = new Mortgage(capitalBorrowed, duration, rate);
            mortgage.Init();
            Assert.Equal(expectedPayment, mortgage.SinglePayment);
        }
    }
}
