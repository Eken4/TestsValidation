namespace CalculatriceEmprunt
{

    public class CSVWriter : IWriter

    {
        private StreamWriter _writer;

        public CSVWriter(string filepath)
        {

            try
            {
                _writer = new StreamWriter(filepath);

            }
            catch(IOException e)
            {
                throw new IOException("Chemin d'accès invalide", e);
            }

        }

        public void WriteToFormat(string[] data)
        {
            // Create a StreamWriter to write to the file
            using (_writer)
            {
                foreach (string line in data)
                {
                    // Join elements of the line with commas
                    string lineText = string.Join(",", line);
                    _writer.WriteLine(lineText);
                }
            }

            Console.WriteLine("Fichier CSV généré");

        }
    }
}
