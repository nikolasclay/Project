using Factorizor.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    public class ConsoleOutput
    {
        internal static void DisplayFactors(int number, List<int>factors)
        {
            //var number = ConsoleUI.GetNumberFromUser();
            //List<int> factors = FactorFinder.FindFactor(number);
            Console.WriteLine("The factors of " + number + " are: ");
            foreach(var factor in factors)
            {
                Console.WriteLine($"{factor}");
            }
        }
        internal static void DisplayPrime(int number, List<int>factors)
        {
            if(factors.Count <= 2)
            {
                Console.WriteLine($"{number} is a prime number.");
            }
            else
            {
                Console.WriteLine($"{number} is not a prime number.");
            }
        }
        internal static void DisplayPerfect(int number, List<int> factors)
        {
            PerfectChecker checker = new PerfectChecker();
            var success = checker.IsPerfect(number, factors);

            if(success == true)
            {
                Console.WriteLine($"{number} is a perfect number");
            }
            else
            {
                Console.WriteLine($"{number} is not a perfect number.");
            }
        }
    }
}
