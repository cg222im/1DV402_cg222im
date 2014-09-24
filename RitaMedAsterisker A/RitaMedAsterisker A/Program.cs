using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitaMedAsterisker_A
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 25;
            int columns = 39;
            int rowCount;
            int columnCount;
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Skriver ut rad
            for (rowCount = 0; rowCount <= (rows - 1); rowCount++)
            {
                // Skriver ut kolumner (asterisker)
                for (columnCount = 0; columnCount <= (columns - 1); columnCount++)
                {                 
                    Console.Write("* ");
                }
                
                // Ny rad
                Console.WriteLine();

                // Indenterar varannan rad
                if (rowCount % 2 == 0)
                {
                    Console.Write(" ");  
                }

                // Byter färg på nästkommande rad
                int rowColor = (rowCount % 3);
                switch (rowColor)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                } 
            }
            // Återställer färg på konsol
            Console.ResetColor();
        }
    }
}