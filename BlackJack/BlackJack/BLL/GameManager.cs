using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GameManager
    {
        private int _wager;

        public PlayerAction ProcessAction(string action)
        {
            if (action == "Stand")
            {
                return PlayerAction.Stand;
            }
            else if (action == "Hit")
            {
                return PlayerAction.Hit;
            }
            else if (action == "Double")
            {
                return PlayerAction.Double;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        //public void Start()
        //{
        //    Deck deck1 = new Deck();
        //    deck1.Shuffle();
        //    for (int i = 0; i < 52; i++)
        //    {
        //        Console.WriteLine("{0, -19}", deck1.DealCard());
        //        if ((i + 1) % 4 == 0)
        //        {
        //            Console.WriteLine();
        //        }
        //    }
        //    Console.ReadLine();
        //}
    }
}
