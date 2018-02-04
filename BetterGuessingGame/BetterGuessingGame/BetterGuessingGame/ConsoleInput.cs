using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGuessingGame
{
    public class ConsoleInput
    {
        public static void Start()
        {
            System.Console.Clear();
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("* Welcome to Guessing Game *");
            System.Console.WriteLine("****************************");
            System.Console.WriteLine();
            System.Console.WriteLine();

            GameManager manager = new GameManager();
            manager.Start();
        }

        public static int GetGuessFromUser()
        {
            //System.Console.WriteLine("Please enter your name");
            //string name = System.Console.ReadLine();
            int result;

            while (true)
            {
                System.Console.WriteLine("Please enter a number between 1 and 20");
                if (int.TryParse(System.Console.ReadLine(), out result))
                {
                    return result;
                }
                else
                {
                    System.Console.WriteLine(result + " is not a valid number");
                    System.Console.WriteLine("Press any key to continue...");
                    System.Console.ReadKey();
                }                              
            }
        }
    }
}
