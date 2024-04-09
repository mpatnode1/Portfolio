using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static Prog2_CardGame.Utility;

namespace Prog2_CardGame
{
    public class CardGame
    {
        protected int playerCount;
        private string gameRule;
        protected List<CardPile> PlayerHands = new List<CardPile>();
        protected CardPile DrawPile = new CardPile(RNG);

        protected int WinScore;
        protected int Rounds;

        protected Player[] playerNames;

        protected static Random RNG = new Random();

        public CardGame(int playerCount, CardPile StartingPile)
        {
            playerNames = new Player[playerCount];

            DrawPile = StartingPile;
            
            for (int i = 0; i < playerCount + 1; i++) 
            {
                PlayerHands.Add(new CardPile(RNG));
            }
                
        }

        public Player[] GetPlayerNames()
        {
            Player[] temp = new Player[playerNames.Length];

            Console.WriteLine(playerNames.Length);

            for (int i = 0; i < playerNames.Length; i++)
            {
                Player player = new Player();
                player.Name = "Steven";

                Print($"What is Player {i + 1}'s name?");
                Print("Type in below:");

                player.Name = ReadLine();
                temp[i] = player;

                Print("Welcome " + player.Name);
            }

            return temp;
        }


        /// <summary>
        /// Print all current players scores.
        /// </summary>
        protected void PrintScore()
        {
            foreach (Player player in playerNames)
            {
                Print($"{player.Name}'s Score: {player.Score}");

            }
        }

        protected Player? CheckWin()
        {
            foreach (Player player in playerNames)
            {
                if (player.Score == WinScore)
                {
                    Print($"{player.Name} has won");
                    return player;
                }

            }
            return null;
        }
        private void listRules()
        {
            throw new System.NotImplementedException();
        }

        public void Turn()
        {
            throw new System.NotImplementedException();
        }

        public void MainMenu()
        {
            throw new System.NotImplementedException();
        }

        
    }
}
/*
          * Debug Deck
          * 
          * Console.WriteLine(deck);
         Console.WriteLine("HAMBURGER");
         var temp = PlayerHands[0];
         var draw = deck.Draw(3);
         temp.AddRange(draw);
         Console.WriteLine("HAMBURGER");
         Console.WriteLine(PlayerHands[0]);
         Console.WriteLine("HAMBURGER");
         Console.WriteLine(deck); */