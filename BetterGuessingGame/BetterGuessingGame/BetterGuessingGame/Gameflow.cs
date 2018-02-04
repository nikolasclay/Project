using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGuessingGame
{
    public class Gameflow
    {
        GameManager _manager;

        public void PlayGame()
        {
            CreateGameManager();
            ConsoleOutput.DisplayTitle();

            GuessResult result;
            int guess;

            do
            {
                guess = ConsoleInput.GetGuessFromUser();
                result = _manager.ProcessGuess(guess);

                ConsoleOutput.DisplayGuessMessage(result);

            } while (result != GuessResult.Victory);
        }

        private void CreateGameManager()
        {
            _manager = new GameManager();
            _manager.Start();
        }
    }
}
