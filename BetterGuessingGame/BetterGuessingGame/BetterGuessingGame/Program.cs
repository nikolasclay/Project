using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Gameflow game = new Gameflow();
            game.PlayGame();
        }
    }
}
