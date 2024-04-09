using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prog2_CardGame.Utility;
using static System.Console;

namespace Prog2_CardGame
{
    internal class SameOrDifferent : CardGame, IPlay
    {
        int WinScoreSameOr = 5;
        int RoundsSameOr = 10;
        public SameOrDifferent() : base(1, new TwoSuitDeck(RNG))
        {
            WinScore = WinScoreSameOr;
            Rounds = RoundsSameOr;
        }

        public void Instructions()
        {
            Print("A card will be drawn at the start of the round.");
            Print("The player will then guess whether the next card drawn will be the same suit or different as the starting card.");
            Print("Type 1 to guess same and 2 for different.");
            Print("The NEXT card will then be drawn, if the guess is correct, the player will earn a point.");
            Print("Earn five points in 10 rounds to win.");
            Pause();
        }

        public void Setup()
        {
            playerNames = GetPlayerNames();
            DrawPile.Shuffle();
        }
        public void Play()
        {
            for (int i = 0; i < Rounds; i++)
            {
                Print("");

                PrintScore();
                Print($"Round {i + 1}");

                Print("The First Card Drawn Is:");
                Print("");

                var currentCard = DrawPile.Draw(1)[0];
                Print(currentCard.ToString());
                Print("");

                Print("Will the next card be same or different.");
                Print("Type 1 for same or 2 for different.");
                Print("");
                char input;
                bool guess = true;
                bool finishedInput = true;
                while (finishedInput == true)
                {
                    input = ReadKey().KeyChar;
                    switch (input)
                    {
                        case '1':
                            Print("1. Same");
                            guess = true;
                            finishedInput = false;
                            break;
                        case '2':
                            Print("2. Different");
                            guess = false;
                            finishedInput = false;
                            break;
                        default:
                            Print("Please type in a number.");
                            finishedInput = true;
                            break;
                    }
                }
                var nextCard = DrawPile.Draw(1)[0];
                Print("");
                Print("The next card drawn is:");
                Print(nextCard.ToString());
                if ((currentCard.Suit == nextCard.Suit) == guess)
                {
                    Print("");
                    Print("You answered correctly! +1 Point");
                    Print("");
                    playerNames[0].AddPoint();
                }
                else
                {
                    Print("");
                    Print("You answered incorrectly.");
                    Print("");
                }

                if (CheckWin() != null)
                {
                    Pause();
                    Print("You Win!");
                    Print("Thanks for playing!");
                    Print("");
                    return;
                }
            }
            Pause();
            Print("You Lose!");
            Print("Try again next time.");
                
            
        }
    }
}

