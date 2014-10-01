using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    public class SecretNumber
    {
        // Räknar antal gissningar sen slumpning
        private int _count; 

        // Det hemla numret
        private int _number;

        // Max antal gissningar
        public const int MaxNumberOfGuesses = 7;

        // Initierar nytt hemligt tal
        public void Initialize() 
        {
            // _number tilldelas slumpat heltal.
            Random random = new Random();
            _number = random.Next(1, 101);

            // _count nollställs.
            _count = 0;
        }

        // Metod för gissning
        public bool MakeGuess(int number) 
        {
            bool value;

            // Felhantering av för litet/för stort samt för många gissningar
            if(number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException("är inte i intervallet 1-100!" );
            }
            
            if(_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException("Du har överstigit ditt antal gissningar!");
            }

            // Resultat av gissning
            if(number > _number)
            {
                _count++;
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.", number, (MaxNumberOfGuesses - _count));
                value = false;
            }

                else if(number < _number)
                {
                    _count++;
                    Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar.", number, (MaxNumberOfGuesses - _count));
                    value = false;
                }
                else
                {
                    _count++;
                    Console.WriteLine("RÄTT GISSAT. Du lyckades med {0} försök.", _count);
                    value = true;
                }

            // Presenterar talet efter 7 gissningar
            if (_count == MaxNumberOfGuesses)
            {
                Console.WriteLine("Du har förbrukat ditt antal gissningar!");
                Console.WriteLine("Det hemliga talet är: {0}", _number);
            }
            return value;
        }

        // Konstruktor för Initialize(), ser till att den startas rätt
        public SecretNumber()
        {
            Initialize();
        }
        
    }  
}
