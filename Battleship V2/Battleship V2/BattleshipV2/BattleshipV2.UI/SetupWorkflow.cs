using BattleshipV2.BLL;
using BattleshipV2.BLL.GameLogic;
using BattleshipV2.BLL.Requests;
using BattleshipV2.BLL.Responses;
using BattleshipV2.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipV2.UI
{
    public class SetupWorkflow
    {
        public GameState Start()
        {
            Menu.DisplayMenu();

            //Prompt player's for names
            string p1 = ConsoleInput.GetName(1);
            string p2 = ConsoleInput.GetName(2);

            //Build player boards
            Board PlayerBoard1 = BuildBoard(p1);
            Board PlayerBoard2 = BuildBoard(p2);

            //Create two player instances
            Player Player1 = new Player(p1, PlayerBoard1);
            Player Player2 = new Player(p2, PlayerBoard2);

            //decide who goes first
            bool WhoseTurn = WhoGoesFirst();


            /*Now that we have the player's names, have drawn the board, and determined who goes first
             * we have all the elements we need to create a state object (remember state object has three parameters:
             * player1 name, player2 name, and who's turn it is.
             */
            GameState state = new GameState(Player1, Player2, WhoseTurn);
            return state;
        }
        private Board BuildBoard(string playerName)
        {
            //create new board instance

            Board board = new Board();

            //loop through the list of ships from smallest to largest and prompt the user for placement

            for (ShipType s = ShipType.Destroyer; s <= ShipType.Carrier; s++)
            {
                bool isValidPlacement = false;
                do
                {
                    PlacementRequest request = new PlacementRequest();

                    //Get coordinates from user and store in request.coordinate package
                    request.Coordinate = ConsoleInput.GetCoordinates();

                    //request ship direction from user
                    request.Direction = ConsoleInput.GetDirection();

                    //send all ship types in the request package 
                    request.SelectedShip = s;

                    //pass the request package to the PlaceShip() method in the Board class
                    var result = board.PlaceShip(request);

                    //Add conditions that will trigger messages if placement rules are broken

                    if (result == ShipPlacement.Overlap)
                    {
                        ConsoleOutput.OverLapMsg(playerName);
                    }
                    else if (result == ShipPlacement.NotEnoughSpace)
                    {
                        ConsoleOutput.NotEnoughSpaceMsg(playerName);
                    }
                    else
                    {
                        ConsoleOutput.OK(playerName);
                        isValidPlacement = true;
                    }
                } while (!isValidPlacement);
            }
            return board;
        }
        //Use random number generator to determine who should go first
        bool WhoGoesFirst()
        {
            return RNG.CoinFlip();
        }

    }
}
