using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog2_CardGame
{
    public class TwoSuitDeck : CardPile
    {
        int deckSize = 26;
        string[] Suits = { "Hearts", "Spades" };

        public TwoSuitDeck(Random RNG) : base(RNG) 
        {
            
            for (int i = 0; i < deckSize / Suits.Length; i++)
            {
                for (int j = 0; j < Suits.Length; j++)
                {
                    Cards.Add(new Card(i + 1, Suits[j]));
                }
            }
            
        }

    }
}
