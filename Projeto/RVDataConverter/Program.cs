using System;

namespace RVDataConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Por favor, forneça o caminho do arquivo .rvdata2.");
                return;
            }

            string filePath = args[0];
            Converter converter = new Converter();
            converter.ConvertToJson(filePath);
        }
    }
}