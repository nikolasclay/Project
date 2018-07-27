using BattleshipV2.BLL.Responses;
using BattleshipV2.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipV2.UI
{
    public class GameWorkflow
    {
        internal static void Play(GameState state)
        {
            Player attackingPlayer = null;
            Player defendingPlayer = null;

            Player activePlayer = null;
            bool isVictory = false;
            while (!isVictory)
            {
                if (state.IsATurn)
                {
                    attackingPlayer = state.Player1;
                    defendingPlayer = state.Player2;
                }
                else
                {
                    attackingPlayer = state.Player2;
                    defendingPlayer = state.Player1;
                }
                if (state.IsATurn)
                {
                    activePlayer = state.Player1;
                }
                else
                {
                    activePlayer = state.Player2;
                }

                //Attacking player fires first shot
                var shotCoordinate = ConsoleInput.FireCoordinates(state);
                ConsoleOutput.DrawBoard(defendingPlayer.PlayerBoard);

                //Coordinates should receive a FireShotResponse
                FireShotResponse response = defendingPlayer.PlayerBoard.FireShot(shotCoordinate);

                switch (response.Status)
                {
                    case ShotStatus.Hit:
                        ConsoleOutput.ShipHit(state);
                        state.IsATurn = !state.IsATurn;
                        break;
                    case ShotStatus.Miss:
                        ConsoleOutput.ShipMissed(state);
                        state.IsATurn = !state.IsATurn;
                        break;
                    case ShotStatus.Duplicate:
                        ConsoleOutput.DuplicateShot(state);
                        state.IsATurn = true;
                        break;
                    case ShotStatus.Invalid:
                        ConsoleOutput.InvalidShot(state);
                        state.IsATurn = true;
                        break;
                    case ShotStatus.HitAndSunk:
                        ConsoleOutput.ShipSunk(state);
                        state.IsATurn = !state.IsATurn;
                        break;
                    case ShotStatus.Victory:
                        ConsoleOutput.Victory(state);
                        isVictory = true;
                        break;

                }
            }
        }
    }
}
