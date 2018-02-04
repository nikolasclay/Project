using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GameManager
    {
        private int _answer;

        private bool IsGuessValid(int guess)
        {
            if(guess >= 1 && guess <= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CreateRandomNumber()
        {
            Random rng = new Random();
            _answer = rng.Next(1, 21);
        }

        public GuessResult ProcessGuess(int guess)
        {
            if (!IsGuessValid(guess))
            {
                return GuessResult.Invalid;
            }
            if(guess < _answer)
            {
                return GuessResult.Lower;
            }
            else if(guess > _answer)
            {
                return GuessResult.Higher;
            }
            else
            {
                return GuessResult.Victory;
            }
        }
        public void Start()
        {
            CreateRandomNumber();
        }
        public void Start(int answer)
        {
            _answer = answer;
        }
    }
}
