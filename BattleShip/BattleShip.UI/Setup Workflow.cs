using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;


namespace BattleShip.UI
{
    class Setup_Workflow
    {
        public GameState Start()
        {
            ConsoleOutput.DisplayTitle();


            //Get player names
            string p1 = ConsoleInput.GetUserName(1);
            string p2 = ConsoleInput.GetUserName(2);

            Board Player1Board = BuildBoard(p1);
            Board Player2Board = BuildBoard(p2);

            Player Player1 = new Player(p1, Player1Board);
            Player Player2 = new Player(p2, Player2Board);


            //decide who goes first

            bool IsPlayerAsTurn = DecideWhoGoesFirst();
            GameState state = new GameState(Player1, Player2, IsPlayerAsTurn);

            return state;

        }

        bool DecideWhoGoesFirst()
        {

            return RNG.CoinFlip();

        }     
        private Board BuildBoard(string playerName)
        {
            Board board = new Board();

            for (ShipType s = ShipType.Destroyer; s <= ShipType.Carrier; s++)
            {
                PlaceShipRequest request = new PlaceShipRequest();
                request.Coordinate = ConsoleInput.GetCoord(playerName, s);
                request.Direction = ConsoleInput.GetDir(playerName, s);
                request.ShipType = s;

                var result = board.PlaceShip(request);
                    if(result == ShipPlacement.Overlap)
                    {
                        ConsoleOutput.ShipOverlap(playerName);
                    }
                    if(result == ShipPlacement.NotEnoughSpace)
                    {
                        ConsoleOutput.NotEnoughSpace(playerName);    
                    }
                    if(result == ShipPlacement.Ok)
                    {
                        ConsoleOutput.ShipPlaceOk(playerName);
                    }

            }
            return board;

        }
    }

}
