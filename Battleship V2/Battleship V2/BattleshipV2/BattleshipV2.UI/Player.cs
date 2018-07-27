using BattleshipV2.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipV2.UI
{
    //Each player will be queryed for their name and a board will be drawn
    public class Player
    {
        //Name is made a field
        public string Name { get; }

        //You will need to call the player's board depending on who's turn it is
        public Board PlayerBoard { get; }

        //assign the name to the constructor by passing in string name and Board object. Set the parameters to the public fields created above.
        public Player(string name, Board playerBoard)
        {
            Name = name;
            PlayerBoard = playerBoard;
        }
    }
}
