using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Prog2_CardGame.Utility;

namespace Prog2_CardGame
{
    public class CardPile
    {
        public string[] Suits = { "Hearts", "Clubs", "Spades", "Diamonds" };

        public List<Card> Cards;
        Random RNG;

        public CardPile(Random RNG) 
        {
            this.RNG = RNG;
            this.Cards = new List<Card>();
        }   
        public Card[] Draw(int drawAmount)
        {
            Card[] temp = new Card[drawAmount];

            for (int i = 0; i < drawAmount; i++)
            {
                //Card temp = Cards[0];
                temp[i] = Cards[0];
                Cards.RemoveAt(0);

            }
            return temp;
        }

        public void Add(Card cardType)
        {
            Cards.Add(cardType);
        }

        public void AddRange(Card[] cards) 
        {
            Cards.AddRange(cards);
        }

        public void InsertRange(int index, Card[] cards)
        {
            Cards.InsertRange(index, cards);
        }

        public override string ToString()
        { 
            return String.Join(", ", Cards);
        }

        //Fisher-Yates Shuffle
        public void Shuffle()
        {
            int n = Cards.Count;
            while (n > 1)
            {
                int k = RNG.Next(n--);
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
            }
        }
    }
}