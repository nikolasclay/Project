using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Requests;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    class GameWorkFlow
    {
        internal static void GoPlay(GameState state)
        {

            Player attackingPlayer = null;
            Player defendingPlayer = null;

            Player activePlayer = null;

            bool isVictory = false;
            while (!isVictory)
            {
                if (state.IsPlayerAsTurn)
                {
                    attackingPlayer = state.Player1;
                    defendingPlayer = state.Player2;
                }
                else
                {
                    attackingPlayer = state.Player2;
                    defendingPlayer = state.Player1;
                }

                if (state.IsPlayerAsTurn)
                {
                    activePlayer = state.Player1;
                }
                else
                {
                    activePlayer = state.Player2;
                }

                var ShotCoord = ConsoleInput.FireCoord(state);
                ConsoleOutput.DrawBoard(defendingPlayer.PlayerBoard);
                

                FireShotResponse response = defendingPlayer.PlayerBoard.FireShot(ShotCoord);

                switch (response.ShotStatus)
                {
                    case ShotStatus.Hit:
                        ConsoleOutput.ShipHit(state);
                        state.IsPlayerAsTurn = !state.IsPlayerAsTurn;
                        break;
                    case ShotStatus.Miss:
                        ConsoleOutput.ShotMiss(state);
                        state.IsPlayerAsTurn = !state.IsPlayerAsTurn;
                        break;
                    case ShotStatus.Duplicate:
                        ConsoleOutput.ShotDuplicate(state);
                        state.IsPlayerAsTurn = true;
                        break;
                    case ShotStatus.Invalid:
                        ConsoleOutput.InvalidShot(state);
                        state.IsPlayerAsTurn = true;
                        break;
                    case ShotStatus.HitAndSunk:
                        ConsoleOutput.HitandSunk(state);
                        state.IsPlayerAsTurn = !state.IsPlayerAsTurn;
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
