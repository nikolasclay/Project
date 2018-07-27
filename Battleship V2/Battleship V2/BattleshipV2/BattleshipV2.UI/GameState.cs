using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipV2.UI
{
    public class GameState
    {
        //Create two player instances
        public Player Player1 { get; }
        public Player Player2 { get; }

        //Determine who goes first

        public bool IsATurn { get; set; }

        public GameState(Player player1, Player player2, bool isATurn)
        {
            Player1 = player1;
            Player2 = player2;
            IsATurn = isATurn;

        }
    }
}
