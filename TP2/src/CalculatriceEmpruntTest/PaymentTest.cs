using CalculatriceEmprunt.Models;

namespace CalculatriceEmpruntTest
{
    public class PaymentTest
    {
        public PaymentTest() { }

        [Theory]
        [InlineData(1, 5000, 15000, "1,5000,15000")]
        public void ToStringTest(int id, double amountPaid, double amountLeft, string expectedOutput)
        {
            Payment payment = new Payment(id, amountPaid, amountLeft);
            Assert.Equal(expectedOutput, payment.ToString());

        }

    }
}
