using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prog2_CardGame.Utility;
using static System.Console;

namespace Prog2_CardGame
{
    internal class HigherOrLower : CardGame, IPlay
    {
        int WinScoreHigher = 5;
        int RoundHigher = 10;
        public HigherOrLower() : base(1, new StandardDeck(RNG))
        {
            WinScore = WinScoreHigher;
            Rounds = RoundHigher;
        }
        public void Instructions()
        {
            Print("A card will be drawn at the start of the round.");
            Print("The player will then guess whether the NEXT card drawn will be of higher or lower value as the starting card.");
            Print("Type 1 to guess Higher and 2 for Lower.");
            Print("The next card will then be drawn, if the guess is correct, the player will earn a point.");
            Print("Earn five points in 10 rounds to win.");
            Print("Aces are low, and Jack, Queen, and King are high.");
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
                Pause();

                Print("The First Card Drawn Is:");
                Print("");

                var currentCard = DrawPile.Draw(1)[0];
                Print(currentCard.ToString());
                Print("");

                Print("Will the next card be higher or lower?");
                Print("Type 1 for higher or 2 for lower.");
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
                            Print("1. Higher");
                            guess = true;
                            finishedInput = false;
                            break;
                        case '2':
                            Print("2. Lower");
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
                if (currentCard.Value > nextCard.Value)
                {
                    if (guess == false)
                    {
                        Print("");
                        Print("The value was lower.");
                        Print("You answered correctly! +1 Point");
                        Print("");
                        playerNames[0].AddPoint();
                    }
                    else
                    {
                        Print("");
                        Print("The value was higher.");
                        Print("You answered incorrectly.");
                        Print("");
                    }
                }
                else if (currentCard.Value < nextCard.Value)
                {
                    if (guess == true)
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
                }
                else
                {
                    Print("");
                    Print("Cards are of same value.");
                    Print("Round will reset.");
                    i -= 1;
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

