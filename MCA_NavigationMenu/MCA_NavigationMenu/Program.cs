using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MCA_NavigationMenu
{
    class Program
    {
        private static string filePath = @"..\..\..\FileCSV\Navigation.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("MCA - Pre-Interview Task");
            Console.WriteLine("Navigation Menu");
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.DarkGreen;
            
            var navigation = new ReaderService(filePath);
            

            Console.ResetColor();
            Console.ReadLine();
        }

    }
}
