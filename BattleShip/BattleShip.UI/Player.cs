﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    public class Player
    {

        //private string _name;
        public string Name { get; }

        public Board PlayerBoard { get; }

        public Player(string name, Board playerBoard)
        {
            Name = name;
            PlayerBoard = playerBoard;
        }

    }
}
