using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipV2.BLL.Requests;
using BattleshipV2.BLL.Ships;

namespace BattleshipV2.UI
{
    public class ConsoleInput
    {
        public static string GetName(int playerNumber)
        {
            Console.WriteLine($"Player {playerNumber}, please enter your name?");
            return Console.ReadLine();
        }

        internal static Coordinates GetCoordinates()
        {
            throw new NotImplementedException();
        }

        internal static ShipDirection GetDirection()
        {
            throw new NotImplementedException();
        }

        internal static ShipType GetShip()
        {
            throw new NotImplementedException();
        }

        internal static Coordinates FireCoordinates(GameState state)
        {
            bool isValid = false;
            Coordinates toReturn = null;
            while (!isValid)
            {
                var activePlayer = "";
                if (state.IsATurn)
                {
                    activePlayer = state.Player1.Name;
                }
                else
                {
                    activePlayer = state.Player2.Name;
                }
                Console.WriteLine($"{activePlayer}, please enter the coordinates for your shot; ");
                var response = Console.ReadLine();
                Console.Clear();
                isValid = CoordinateTryParse(response, out toReturn);

                
            }
        }

        private static bool CoordinateTryParse(string response, out Coordinates toReturn)
        {
            throw new NotImplementedException();
        }
    }
}
