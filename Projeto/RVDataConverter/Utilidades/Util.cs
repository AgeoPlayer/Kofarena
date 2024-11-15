using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVDataConverter.Utilidades
{
    public static class Util
    {
        public static void LogError(string message)
        {
            Console.WriteLine($"Erro: {message}");
        }

        public static void LogInfo(string message)
        {
            Console.WriteLine($"Info: {message}");
        }
    }
}
