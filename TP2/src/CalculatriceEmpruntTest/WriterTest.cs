using CalculatriceEmprunt;

namespace CalculatriceEmpruntTest
{
    public class WriterTest
    {
        public WriterTest() { }

        [Fact]
        public void CreateFileTest()
        {
            string path = "test.csv";
            IWriter writer = new CSVWriter(path);
            Assert.True(File.Exists(path));
        }
    }
}
