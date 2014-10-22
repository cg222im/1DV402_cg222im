using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamer_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            //kapslar in array, tom = 4, 8, 16, 32, 64 element.
            List<int> testScores = new List<int>();

            try
            {
                using (StreamReader reader = new StreamReader("TestScores.csv"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string value in values)
                        {
                            testScores.Add(int.Parse(value));
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            testScores.TrimExcess();
            testScores.Sort();

            Console.WriteLine("Average: " + testScores.Average());

            Console.WriteLine("Even numbers: " + testScores.Where(n => n % 2 == 0).Count());
        }
    }
}
