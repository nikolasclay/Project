using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipV2.BLL
{
    public class RNG
    {
        //create new Random object in order to access properties
        static Random _generator = new Random();


        //Use coin flip to determine who goes first
        public static bool CoinFlip()
        {
            return _generator.NextDouble() < 0.5;
        }
    }
}
