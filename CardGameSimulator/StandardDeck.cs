using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prog2_CardGame
{
    public class StandardDeck : CardPile
    {
        int deckSize = 52;
        

        public StandardDeck(Random RNG) : base(RNG) 
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
