using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VäxelPengar_A
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarerar variabler.
            double totalSumma;
            int erhålletBelopp;
            int avrundadSumma;
            int växelTillbaka;
            double öresAvrundning;

            // Input med felhantering för "fel" tecken i konsolfönstret.
            while (true)
            {
                try
                {
                    // Input, Totalsumma med ören.
                    Console.Write("Ange totalbelopp att betala : ");
                    totalSumma = double.Parse(Console.ReadLine());

                    // Felhantering av för litet/negativt belopp. Endast en loop?
                    if (totalSumma <= 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nIngenting är gratis! \n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Ange belopp att betala : ");
                        totalSumma = double.Parse(Console.ReadLine());
                    }

                    // Input, erhållet belopp i heltal.
                    Console.Write("Ange erhållna kontanter : ");
                    erhålletBelopp = int.Parse(Console.ReadLine());

                    // Felhantering av för lite/negativa kontanter.
                    if (erhålletBelopp <= 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nFör lite kontanter, snåljop! \n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Totalbelopp : {0}", totalSumma);
                        Console.Write("Ange erhållna kontanter : ");
                        erhålletBelopp = int.Parse(Console.ReadLine());
                    }

                    // Öresavrundning
                    avrundadSumma = (int)Math.Round(totalSumma);
                    öresAvrundning = avrundadSumma - (double)totalSumma;

                    // Felhantering för lite kontanter
                    if ((avrundadSumma - erhålletBelopp) > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nErhållet belopp är för litet. Köpet kunde inte genomföras.");
                        Console.BackgroundColor = ConsoleColor.Black;
                        System.Environment.Exit(0);
                    }

                    // Felhantering 
                    break;
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Fel format! Ange siffror samt , istället för . \n");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Ett oväntat fel har inträffat! \n");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

            }



            // "Grafiskt" ramverk för kvitto.
            Console.WriteLine("\nKVITTO");
            Console.WriteLine("----------------------------------");

            // Totalsumma avrundas till närmaste hela krontal.
            Console.WriteLine("{0, -15}:{1, 17:c2}.", "Totalt", totalSumma);

            // Öresavrundning.
       
            Console.WriteLine("Öresavrundning : {0, 16:c2}.", öresAvrundning);

            // Totalbelopp skrivs ut
            Console.WriteLine("Att betala :     {0, 16:c2}.", avrundadSumma);

            // Felhantering av för liten summa.
            if (avrundadSumma < 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras.");
                Console.BackgroundColor = ConsoleColor.Black;
                return;
            }

            // Kontanter
            Console.WriteLine("Kontant : {0, 23:c2}.", erhålletBelopp);

            // Växel tillbaka
            växelTillbaka = erhålletBelopp - avrundadSumma;
            Console.WriteLine("\nDin växel tillbaka är: {0, 10:c0}.", växelTillbaka);

            // Felhantering av först stort belopp.
         

            // Kvittot "stängs"
            Console.WriteLine("----------------------------------");

            // Valörer...
            if ((växelTillbaka / 500) > 0)
            {
                Console.WriteLine("\n500-lappar: {0, 5}", (växelTillbaka / 500));
            }
            if (((växelTillbaka % 500) / 100) > 0)
            {
                Console.WriteLine("100-lappar: {0, 5}", ((växelTillbaka % 500) / 100));
            }
            if (((växelTillbaka % 100) / 50) > 0) 
            {
                Console.WriteLine("50-lappar: {0, 6}", ((växelTillbaka % 100) / 50));
            }
            if (((växelTillbaka % 50) / 20) > 0) 
            {
                Console.WriteLine("20-lappar: {0, 6}", ((växelTillbaka % 50) / 20));
            }
            if ((((växelTillbaka % 50) % 20) / 10) > 0) 
            {
                Console.WriteLine("10-kronor: {0, 6}", (((växelTillbaka % 50) % 20) / 10));
            }
            if (((växelTillbaka % 10) / 5) > 0)
            {
                Console.WriteLine("5-kronor: {0, 7}", ((växelTillbaka % 10) / 5));
            }
            if (((växelTillbaka % 5) / 1) > 0)
            {
                Console.WriteLine("1-kronor: {0, 7}\n", ((växelTillbaka % 5) / 1));
            }


            // Tidigare uträkning av valörer.
            //Console.WriteLine("\n500-lappar: {0, 5}", (växelTillbaka / 500));
            //Console.WriteLine("100-lappar: {0, 5}", ((växelTillbaka % 500) / 100));
            //Console.WriteLine("50-lappar: {0, 5}", (((växelTillbaka % 500) % 100) / 50));
            //Console.WriteLine("20-lappar: {0, 5}", ((((växelTillbaka % 500) % 100) % 50) / 20));
            //Console.WriteLine("10-kronor: {0, 5}", (((((växelTillbaka % 500) % 100) % 50) % 20) / 10));
            //Console.WriteLine("5-kronor: {0, 5}", ((((((växelTillbaka % 500) % 100) % 50) % 20) % 10) / 5));
            //Console.WriteLine("1-kronor: {0, 5}\n", (((((((växelTillbaka % 500) % 100) % 50) % 20) % 10) % 5) / 1));

            // Avslutar samt håller fönstret uppe när det är färdigt.
            Console.WriteLine("----------------------------------\n");
            Console.WriteLine("Tack för ditt köp, välkommen åter!\n");
            Console.WriteLine("Tryck på Retur för att avsluta.");
            Console.ReadLine();

        }
    }
}
