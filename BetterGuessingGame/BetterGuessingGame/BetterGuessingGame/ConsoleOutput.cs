using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGuessingGame
{
    public class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("*************************************");
            Console.WriteLine("* Welcome to a Better Guessing Game *");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.WriteLine("Press any key to start the game!");
            Console.ReadKey();
        }

        public static void DisplayGuessMessage(GuessResult result)
        {
            switch (result)
            {
                case GuessResult.Invalid:
                    DisplayInvalid();
                    break;

                case GuessResult.Lower:
                    DisplayLower();
                    break;

                case GuessResult.Higher:
                    DisplayHigher();
                    break;

                case GuessResult.Victory:
                    DisplayVictory();
                    break;
                default:
                    Console.WriteLine("The number you entered was invalid. Try entering a number between 1 and 20");
                    break;
            }
        }

        private static void DisplayVictory()
        {
            Console.WriteLine("Victory, you entered the correct guess!!!");
            Console.WriteLine("Press any key to continue...");
            //Console.ReadLine();
            Console.ReadKey();
            
        }
        private static void DisplayHigher()
        {
            Console.WriteLine("The guess you entered was too high!");
            Console.ReadKey();
        }

        private static void DisplayLower()
        {
            Console.WriteLine("Your guess was too low!");
            Console.ReadKey();
        }

        private static void DisplayInvalid()
        {
            Console.WriteLine("Your guess was invalid!");
            Console.ReadKey();
        }
    }
}
