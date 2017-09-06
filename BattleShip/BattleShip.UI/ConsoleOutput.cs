using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("*    Get ready to have some fun!    *");
            Console.WriteLine("*       Welcome To BATTLESHIP!      *");
            Console.WriteLine("*                                   *");
            Console.WriteLine("*************************************");
            Console.WriteLine("Press any key to start the game...");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void DrawBoard(Board playerBoard)
        {
            for (int y = 1; y <= 10; y++)
            {
                for (int x = 1; x <= 10; x++)
                {
                    ShotHistory currentState = playerBoard.CheckCoordinate(new Coordinate(x, y));
                    switch (currentState)
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("H");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("M");
                            Console.ResetColor();
                            break;
                    }
                    Console.Write("   |");
                }
                Console.WriteLine("  ");
                Console.WriteLine("---------------------------------------");
                
            }

        }

        internal static void InvalidShot(GameState state)
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
            
            Console.WriteLine($"{activePlayer} what are you shooting at?! Please shoot again.");
        }

        internal static void ShotDuplicate(GameState state)
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
            Console.WriteLine($"{activePlayer} you already shot there. Get it together and try again!");
        }

        internal static void ShipOverlap(string playerName)
        {
            Console.WriteLine($"{playerName} you cannot place a ship there. Your ships are overlapping.");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void NotEnoughSpace(string playerName)
        {
            Console.WriteLine($"{playerName} you cannot place a ship there. There is not enough space.");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void ShipHit(GameState state)
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
            Console.WriteLine($"{activePlayer}, don't panic yet...but your ship has been hit!!");
        }

        internal static void HitandSunk(GameState state)
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
            Console.WriteLine($"{activePlayer}, I've got bad news...your ship has been sunk!");
        }

        internal static void Victory(GameState state)
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
            Console.WriteLine($"{activePlayer}, take a bow...You are victorious!!!!");
        }

        internal static void ShipPlaceOk(string playerName)
        {
            Console.WriteLine($"{playerName} your ship placement is OK.");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void ShotMiss(GameState state)
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
            Console.WriteLine($"{activePlayer} shot missed! Better luck next time!");
        }
        
    }
}
