using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class ConsoleInput
    {
        public static string GetPlayerName()
        {
            string input = "";
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Please enter your name: ");
                if (!string.IsNullOrEmpty(Console.ReadLine()))
                {
                    input = Console.ReadLine();
                    isValid = true;
                }
            }
            return input;
        }
    }
}
