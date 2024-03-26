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
        double.TryParse(args[0], out double capital);
        double.TryParse(args[1], out double rate);
        int.TryParse(args[2], out int duration);

        if (capital < 50000)
        {
            throw new ArgumentException("Capital must be over 50000");
        }

        if (duration < 108 || duration > 300)
        {
            throw new ArgumentException("Duration must be between 9 years (108 months) and 25 years (300 months)");
        }

        Mortgage mortgage = new Mortgage(capital, duration, rate);
        mortgage.Init();
        mortgage.SetPayments();
        string[] data = mortgage.GetOutput();

        IWriter writer = new CSVWriter("./mortgage.csv");
        writer.WriteToFormat(data);
    }


}