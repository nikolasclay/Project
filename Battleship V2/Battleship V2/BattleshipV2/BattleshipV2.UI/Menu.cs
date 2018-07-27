using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipV2.UI
{
    class Menu
    {
        //create method to display game menu and instruct user to start game
        public static void DisplayMenu()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("*  Welcome to Battleship!!  *");
            Console.WriteLine("*****************************");

            Console.WriteLine("Press any key to start the game");
            Console.ReadKey();
            Console.Clear();
            ConsoleOutput.DrawBoard();
        }
        
    }
}
