using BLL;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Gameflow
    {
        GameManager _manager;

        public void PlayGame()
        {
            ConsoleInput.GetPlayerName();

            Deck deck1 = new Deck();
            deck1.Shuffle();
            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine("{0, -19}", deck1.DealCard());
                if ((i + 1) % 4 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
            

        }
    }
}
