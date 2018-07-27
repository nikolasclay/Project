using BattleshipV2.BLL.GameLogic;
using System;

namespace BattleshipV2.UI
{
    internal class ConsoleOutput
    {
        internal static void DrawBoard(Board playerBoard)
        {
            throw new NotImplementedException();
        }

        internal static void OverLapMsg(string playerName)
        {
            Console.WriteLine($"{playerName}, your ships are overlapping!");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void NotEnoughSpaceMsg(string playerName)
        {
            Console.WriteLine($"{playerName}, there is not enough space to make that move!");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void OK(string playerName)
        {
            Console.WriteLine($"{playerName}, your ship has been placed on the board.");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void ShipHit(GameState state)
        {
            throw new NotImplementedException();
        }

        internal static void ShipMissed(GameState state)
        {
            throw new NotImplementedException();
        }

        internal static void DuplicateShot(GameState state)
        {
            throw new NotImplementedException();
        }

        internal static void InvalidShot(GameState state)
        {
            throw new NotImplementedException();
        }

        internal static void ShipSunk(GameState state)
        {
            throw new NotImplementedException();
        }

        internal static void Victory(GameState state)
        {
            throw new NotImplementedException();
        }
    }
}