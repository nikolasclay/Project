using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{

    public class ConsoleInput
    {
        public static string GetUserName(int playerNumber)
        {
            Console.WriteLine($"Player {playerNumber} please enter your name: ");
            return Console.ReadLine();
        }
        internal static Coordinate GetCoord(string playerName, ShipType s)
        {
            int x = 1;
            int yPart = 'a';
            bool isValid = false;
            while (!isValid)
            {
                Console.Clear();
                Console.Write($"{playerName} please enter your coordinates to place your {s}: ");
                string userInput = Console.ReadLine();

                if (userInput.Length < 2)
                {
                    Console.WriteLine($"The coordinates you just entered were not valid");
                }
                else if (yPart >= 'a' && yPart <= 'j')
                {
                    string xPart = userInput.Substring(1);
                    yPart = userInput[0];

                    if (int.TryParse(xPart, out x))
                    {
                        if (x >= 1 && x <= 10)
                        {
                            isValid = true;
                        }
                    }
                }
            }
            int y = (yPart - 'a' + 1);
            Coordinate GoodCoord = new Coordinate(y, x);
            return GoodCoord;
        }

        internal static Coordinate FireCoord(GameState state)
        {

            bool isValid = false;
            Coordinate toReturn = null;
            while (!isValid)

            {
                var activePlayer = "";
                if (state.IsPlayerAsTurn)
                {
                    activePlayer = state.Player1.Name;
                }
                else
                {
                    activePlayer = state.Player2.Name;
                }

                Console.Write($"{activePlayer} please enter your coordinates to fire your shot: ");
                string userInput = Console.ReadLine();
                Console.Clear();
                isValid = CoordinateTryParse(userInput, out toReturn);
                if (!isValid)
                {
                    Console.WriteLine($"{activePlayer} the coordinates you just entered were not valid");
                }

            }

            return toReturn;
        }

        public static bool CoordinateTryParse(string userInput, out Coordinate toReturn)
        {
            toReturn = null;
            if(userInput.Length > 1)
            {
                int x = -1;
                int yPart = 'a';
                string xPart = userInput.Substring(1);

                yPart = userInput[0];

                if (yPart >= 'a' && yPart <= 'j')
                {
                    if (int.TryParse(xPart, out x))
                    {
                        if (x >= 1 && x <= 10)
                        {
                            int y = (yPart - 'a' + 1);
                            toReturn = new Coordinate(y, x);
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        internal static ShipDirection GetDir(string playerName, ShipType s)

        {

            Console.WriteLine($"{playerName} please enter your {s} direction. Enter '0' for 'Down', '1' for 'Up', '2' for 'Left' and '3' for 'Right': ");
            string input = Console.ReadLine();
            ShipDirection ShipGood = new ShipDirection();
            if (input == "")
            {
                Console.WriteLine("You must enter a value here.");
            }
            else
            {
               
                switch (input)
                {
                    case "0":
                        ShipGood = ShipDirection.Down;
                        break;
                    case "1":
                        ShipGood = ShipDirection.Up;
                        break;
                    case "2":
                        ShipGood = ShipDirection.Left;
                        break;
                    case "3":
                        ShipGood = ShipDirection.Right;
                        break;
                }
                
            }
            return ShipGood;


        }

    }
}

