using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodtyckligLonerevision_A
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lokal variabel
            int numberOfSalaries;

            do
            {
                // Anropar ReadInt metoden för antal löner
                numberOfSalaries = ReadInt("Ange antal löner: ");

                // Om antalet löner är fler än 1...
                if (numberOfSalaries >= 2)
                {
                    // ...anropar ProcessSalaries metoden
                    ProcessSalaries(numberOfSalaries);
                }

                // Färre än 2 = FEL (gör om/quit)
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! För litet antal! Ange minst två löner. \n");
                    Console.ResetColor();
                }
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTryck på 'Escape' för att stänga programmet,");
                Console.WriteLine("alternativt valfri tangent för att köra på nytt.\n");
                Console.ResetColor();

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        static void ProcessSalaries(int numberOfSalaries)
        {
            // Lokala variabler
            int median;
            int mean;
            int spread;

            // Skapar och läser in storlek på array
            int[] array = new int[numberOfSalaries];
            Console.WriteLine("\nAnge löner i heltal: ");
            Console.WriteLine("--------------------------\n");

            // Läser in löner i array och skriver ut indata
            for (int i = 0; i < numberOfSalaries; i++)
            {
                Console.Write("Lön nummer {0} : ", 1 + i);
                array[i] = ReadInt("");
            }

            // Gör en kopia av array för datahantering
            int[] processedSalaries = new int[array.Length];
            array.CopyTo(processedSalaries, 0);

            // Sorterar array
            Array.Sort(processedSalaries);

            // Beräknar och skriver ut median
            int mid = (numberOfSalaries / 2);
            // Om medianen ligger mellan två tal
            median = (numberOfSalaries % 2 != 0) ? (int)processedSalaries[mid] : (((int)processedSalaries[mid] + (int)processedSalaries[mid - 1]) / 2);
            Console.WriteLine("--------------------------");
            Console.WriteLine("\nMedianlön: {0, 14:c0}", median);

            // Beräknar summan av kardemmuman
            int sum = 0;
            for (int i = 0; i < processedSalaries.Length; i++)
            {
                sum += processedSalaries[i];
            }

            // Beräknar och skriver ut medelvärde
            mean = (sum / processedSalaries.Length);
            Console.WriteLine("Medellön: {0, 15:c0}", mean);

            // Beräknar och skriver ut spridning
            int maxValue = processedSalaries.Max();
            int minValue = processedSalaries.Min();
            spread = (maxValue - minValue);
            Console.WriteLine("Lönespridning: {0, 10:c0}", spread);
            Console.WriteLine("--------------------------");

            // Skriver ut array i sin helhet
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0, 8} ", array[i]);
                if ((i % 3) == 2)
                {
                    Console.WriteLine();
                } 
            }
            Console.WriteLine("\n");
        }

        static int ReadInt(string prompt)
        {
            // Lokal variabel för hantering av data
            int input;

            // Inmatning samt felhantering av data
            while (true)
            {
                try
                {
                    // Läser in och returnerar data som matas in
                    Console.Write(prompt);
                    input = int.Parse(Console.ReadLine());
                    return input;
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! Kan inte tolkas som ett heltal!");
                    Console.Write("Var vänlig slå in heltal. \n");
                    Console.ResetColor();
                } 
            }
        }
    }
}