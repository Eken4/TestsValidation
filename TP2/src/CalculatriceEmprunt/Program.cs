using CalculatriceEmprunt;
using CalculatriceEmprunt.Models;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            throw new ArgumentException("Usage : capital rate duration");
        }


        decimal.TryParse(args[0], out decimal capital);
        decimal.TryParse(args[1], out decimal rate);
        int.TryParse(args[2], out int duration);

        if (capital < 50000)
        {
            throw new ArgumentException("Capital must be over 50000");
        }


        if (duration < 9 || duration > 25)
        {
            throw new ArgumentException("Duration must be between 9 years and 25 years");
        }

        Mortgage mortgage = new Mortgage(capital, duration, rate);
        mortgage.Init();
        string[] data = mortgage.GetOutput();

        IWriter writer = new CSVWriter("./mortgage.csv");
        writer.WriteToFormat(data);
    }


}