using Factorizor.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    public class ConsoleUI
    {
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("****************************");
            Console.WriteLine("*        Factorizor        *");
            Console.WriteLine("****************************");
            Console.WriteLine();
            Console.WriteLine();

            int number = GetNumberFromUser();
            Console.Clear();
            List<int> result = FactorFinder.FindFactor(number);
            ConsoleOutput.DisplayFactors(number, result);
            ConsoleOutput.DisplayPrime(number, result);
            ConsoleOutput.DisplayPerfect(number, result);

            Console.ReadLine();
            Console.Clear();
            Console.ReadKey();
            
        }

        public static int GetNumberFromUser()
        {
            bool success = false;
            int number = -1;
            string name = GetUserName();
            while (!success)
            {
                Console.WriteLine($"{name}, please enter your number: ");
                var result = Console.ReadLine();
                success = int.TryParse(result, out number);
            }
            return number;
        }

        public static string GetUserName()
        {
            bool success = false;
            string input = String.Empty;
            while (!success)
            {
                Console.WriteLine("Please enter your name: ");
                input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    success = true;
                }
            }
            return input;
        }
    }
}
