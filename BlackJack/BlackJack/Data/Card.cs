using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Card
    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }
        public int Value { get; }
        private string _face;
        private string _suit;
        private int _value;

        public Card(string cardFace, string cardSuit)
        {
            _face = cardFace;
            _suit = cardSuit;
        }
        public Card(int cardValue)
        {
            _value = cardValue;
        }

        //provides my version of the ToString function.
        public override string ToString()
        {
            return _face + " of " + _suit; ;
        }

    }
}
