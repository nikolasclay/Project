using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumberFromUser();

            Calculator.PrintFactors(number);
            Calculator.IsPerfectNumber(number);
            Calculator.IsPrimeNumber(number);

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompt the user for an integer.  Make sure they enter a valid integer!
        /// 
        /// See the String Input lesson for TryParse() examples
        /// </summary>
        /// <returns>the user input as an integer</returns>
        static int GetNumberFromUser()
        {
            int toReturn = int.MinValue;
            bool success = false;

            while (!success)
            {
                Console.WriteLine("Please enter a number.");
                success = int.TryParse(Console.ReadLine(), out toReturn);
            }
            return toReturn;
        }
    }

    class Calculator
    {
        /// <summary>
        /// Given a number, print the factors per the specification
        /// </summary>
        public static void PrintFactors(int number)
        {
            Console.WriteLine("The factors " + number + " of are:");
            for (int x = 1; x < number; x++)
            {
                if (number % x == 0)
                {
                    Console.WriteLine(x);
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Given a number, print if it is perfect or not
        /// </summary>
        public static void IsPerfectNumber(int number)
        {
            int sum = 0;
            for (int x = 1; x < number; x++)
            {
                if(number % x == 0)
                {
                    sum += x;
                }
            }
            if(sum == number)
            {
                Console.WriteLine(number + " is a perfect number.");
            }
            else
            {
                Console.WriteLine(number + " is not a perfect number.");
            }
        }

        /// <summary>
        /// Given a number, print if it is prime or not
        /// </summary>
        public static void IsPrimeNumber(int number)
        {
            int count = 0;
            for (int x = 1; x <= number; x++)
                {
                    if (number % x == 0)
                    {
                        count++;
                    }
                }
            if (count <= 2)
            {
                Console.WriteLine(number + " is a prime number.");
            }
            else
            {
                Console.WriteLine(number + " is not a prime number.");
            }

        }
        }
    }
          
