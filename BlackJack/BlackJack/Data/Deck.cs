using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Deck
    {
        private Card[] _deck;
        private int _currentCard;
        private const int Number_of_Cards = 52;
        private Random rgn;

        public Deck()
        {
            string[] faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            string[] suits = { "Hearts", "Diamonds", "Spades", "Clubs" };
            _deck = new Card[Number_of_Cards];
            _currentCard = 0;
            rgn = new Random();
            for(int count = 0; count < _deck.Length; count++)
            {
                _deck[count] = new Card(faces[count % 11], suits[count / 13]);
            }
        }
        public void Shuffle()
        {
            _currentCard = 0;
            for(int first = 0; first < _deck.Length; first++)
            {
                int second = rgn.Next(Number_of_Cards);
                Card temp = _deck[first];
                _deck[first] = _deck[second];
                _deck[second] = temp;
            }
        }
        public Card DealCard()
        {
            if(_currentCard < _deck.Length)
            {
                return _deck[_currentCard++];
            }
            else
            {
                return null;
            }
                
        }
    }
}
