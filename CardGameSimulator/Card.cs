using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog2_CardGame
{
    public class Card
    {
        
        public readonly int Value;
        public readonly string Suit;
        public readonly string Rank;

        string[] Ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        public Card(int Value, string Suit)
        {
            this.Value = Value;
            this.Suit = Suit;
            this.Rank = Ranks[Value - 1];

        }

        public override string ToString()
        {
            return $"{this.Rank} of {this.Suit}";
        }
    }
}