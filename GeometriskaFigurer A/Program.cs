using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometriskaFigurer_A
{
    class Program
    {
        static void Main(string[] args)
        {
            //!avslutat => CreateShape()
            //==> ViewDetail() presenterar detaljer
            //==> any key ==> meny igen
            //menyval 0-2 ; if > felmeddelande, any key try again--- hur input med enum när return void ??

            bool exit = false;
            int menuChoice;
            ShapeType shapeType = ShapeType.Undefined;
           
            do
            {
                // Anropar ViewMenu() för meny
                ViewMenu();
                Console.Write("Ditt val: ");
                // Input för menyval samt felhantering
                try
                {
                    menuChoice = int.Parse(Console.ReadLine());
                   
                        // Menyval samt felhantering
                        switch (menuChoice)
                        {
                            case 0:
                                exit = true;
                                Console.WriteLine("\nAvslutar applikationen...\n");
                                continue;
                            case 1:
                                shapeType = ShapeType.Ellipse;
                                break;
                            case 2:
                                shapeType = ShapeType.Rectangle;
                                break;
                            // Felhantering av för små eller stora värden
                            default:
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("FEL! Ange ett flyttal mellan 0 och 2.");
                                Console.ResetColor();
                                continueKey();
                                continue;
                        }
                        // Anger figurens form beroende på menyval
                        Shape shape = CreateShape(shapeType);
                        
                        // Presenterar figurens detaljer
                        ViewShapeDetail(shape);
                        continueKey();
                }
                // Felhantering av felinmatade tecken
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! Ange ett flyttal mellan 0 och 2.");
                    Console.ResetColor();
                    continueKey();
                    continue;
                }
             } while (!exit);
           
        }
  
    
        private static Shape CreateShape(ShapeType shapeType)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔═══════════════════════════════════╗ ");
            if (shapeType == ShapeType.Ellipse)
            {
                Console.WriteLine(" ║              {0}              ║ ", shapeType);
            }
            else if (shapeType == ShapeType.Rectangle)
            {
                Console.WriteLine(" ║             {0}             ║ ", shapeType);
            }
            Console.WriteLine(" ╚═══════════════════════════════════╝ \n");
            Console.ResetColor();

            Shape shape = null;
          
            double length = ReadDoubleGreaterThanZero("Ange längden: ");
            double width = ReadDoubleGreaterThanZero("Ange bredden: ");
           
            // Skapar figur med längd och bredd beroende på shapeType
            if (shapeType == ShapeType.Ellipse)
            {
                shape = new Ellipse(length, width);
            }
            
            else if (shapeType == ShapeType.Rectangle)
            {
                shape = new Rectangle(length, width);
            }

            return shape;
        }

        private static double ReadDoubleGreaterThanZero(string prompt)
        {
            double input;
            Console.Write(prompt);
            // Försök ta emot och validera flyttal
            while (true)
	        {
	            try
                {
                    Console.ResetColor();
                    input = double.Parse(Console.ReadLine()); 

                    if (input > 0)
                    {
                        return input;    
                    }

                    // Om input är för litet -> Felmeddelande
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! Värdet måste vara större än 0!");
                    Console.ResetColor();
                }
                // Felhantering av andra tecken än heltal
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

        // Presenterar menyn
        private static void ViewMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔═══════════════════════════════════╗ ");
            Console.WriteLine(" ║               Meny                ║ ");
            Console.WriteLine(" ╚═══════════════════════════════════╝ ");
            Console.ResetColor();
            Console.WriteLine("\n0. Avsluta\n");
            Console.WriteLine("1. Ellips\n");
            Console.WriteLine("2. Rektangel\n");
            Console.WriteLine("================================\n");
            Console.WriteLine("Ange menyval [0-2]: \n");
            
        }

        // Skickar data för shape objektet till ToString
        private static void ViewShapeDetail(Shape shape)
        {
            Console.WriteLine(shape.ToString());
        }
        public static void continueKey()
        {
            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
