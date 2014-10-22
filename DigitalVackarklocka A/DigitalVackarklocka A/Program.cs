using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVackarklocka_A
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Test av standardkonstruktorn: sträng repr. värdet skrivs ut = "0.00 (0.00)"
            ViewTestHeader("1. Test av standardkonstruktorn: '0.00 (0.00)' skrivs ut.\n");
            AlarmClock ac1 = new AlarmClock();
            Console.WriteLine(ac1.ToString()); 
            continueKey();

            //2. Test av konstruktorn med två parametrar: args 9, 42 vid nytt objekt = "9:42 (0:00)"
            ViewTestHeader("2. Test av konstruktorn med två parametrar: '9:42 (0:00)'\n");
            AlarmClock ac2 = new AlarmClock(9, 42);
            Console.WriteLine(ac2.ToString());
            continueKey();
            
            //3. Test av konstruktorn med fyra parametrar: args 13, 24, 7, 35 vid nytt objekt= "13:24 (7:35)"
            ViewTestHeader("3. Test av konstruktorn med fyra parametrar: '13:24 (7.35)'\n");
            AlarmClock ac3 = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(ac3.ToString());
            continueKey();
          
            //4. Test av metoden TickTock() : ställ befintligt AlarmClock-objekt till 23:58, ++ 13 min = lista med 13 tider + klockgrafik
            ViewTestHeader("4. Ställer befintligt AlarmClock-objekt till 23:58 och låter gå 13 minuter.\n");
            ac3.Minute = 58;        // en minut för lite?
            ac3.Hour = 23;
            Run(ac3, 13);
            continueKey();

            //5. Ställer befintligt AlarmClock-objekt till 6:12 och alarm till 6:15 och låter gå 6 minuter = skriv ut och indikera alarm + klockgrafik
            ViewTestHeader("5. Ställer befintligt AlarmClock-objekt till 6:12, 6:15 och låter gå 6 minuter.\n");
            ac3.Hour = 6;
            ac3.Minute = 12;
            ac3.AlarmHour = 6;
            ac3.AlarmMinute = 15;
            Run(ac3, 6);
            continueKey();
           
            //6. Test av egenskaperna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden = skriv ut
            ViewTestHeader("6. Test av egenskaperna så att undantag kastas vid felaktiga värden.\n");

            try { if (ac3.Hour < 23 && ac3.Hour > 0) { ac3.Hour = 60; } }
            catch { ViewErrorMessage("Timmen är inte i intervallen 0-23."); }

            try { if (ac3.Minute < 59 && ac3.Minute > 0) { ac3.Minute = 67; } }
            catch { ViewErrorMessage("Minuten är inte i intervallet 0-59."); }

            try { if (ac3.AlarmHour < 23 && ac3.AlarmHour > 0) { ac3.AlarmHour = 55; } }
            catch { ViewErrorMessage("Alarmtimmen är inte i intervallen 0-23."); }

            try { if (ac3.AlarmMinute < 59 && ac3.AlarmMinute > 0) { ac3.AlarmMinute = 67; } }
            catch { ViewErrorMessage("Alarmminuten är inte i intervallet 0-59."); }
            continueKey();

            //7. Test av konstruktorer så att undantag kastas då tid och alarmtid tilldelas felaktiga värden = skriv ut             
            ViewTestHeader("7. Test av konstruktorerna så att undantag kastas vid felaktiga värden.\n");

            try { AlarmClock ac4 = new AlarmClock(57, 0, 1, 0); }
            catch { ViewErrorMessage("Timmen är inte i intervallen 0-23."); } 
  
            try { AlarmClock ac5 = new AlarmClock(1, 67, 1, 0); }
            catch { ViewErrorMessage("Minuten är inte i intervallet 0-59."); } 

            try { AlarmClock ac6 = new AlarmClock(1, 0, 57, 0); }
            catch { ViewErrorMessage("Alarmtimmen är inte i intervallen 0-23."); } 

            try { AlarmClock ac7 = new AlarmClock(1, 0, 1, 67); }
            catch { ViewErrorMessage("Alarmminuten är inte i intervallet 0-59."); } 
        }
        private static void Run(AlarmClock ac, int minutes)
        {   
            for (int i = 0; i < minutes; i++)
            {
                if (ac.TickTock() == true)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.Write(ac.ToString());
                    Console.WriteLine(" beep beep beep! beep beep beep!");  
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(ac.ToString());
                } 
            }
            
        }
        private static void ViewErrorMessage(string message) 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void ViewTestHeader(string header) 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(header);
            Console.ResetColor();
        }

        // Press any key to continue
        private static void continueKey()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
