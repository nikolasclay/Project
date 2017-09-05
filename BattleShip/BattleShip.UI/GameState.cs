using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;

namespace BattleShip.UI
{
    public class GameState
    {
        public Player Player1 { get; }
        public Player Player2 { get; }

        public bool IsPlayerAsTurn { get; set; }

        public GameState(Player player1, Player player2, bool p1Turn)
        {
            Player1 = player1;
            Player2 = player2;
            IsPlayerAsTurn = p1Turn;
        }
    }
}
