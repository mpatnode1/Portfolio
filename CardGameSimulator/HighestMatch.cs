using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prog2_CardGame.Utility;
using static System.Console;

namespace Prog2_CardGame
{
    internal class HighestMatch : CardGame, IPlay
    {
        int RoundsHighestMatch = 10;
        public int numberSwapped = 0;
        bool gameEnded = false;
        int dealerHand;


        Dictionary<string, int> dealerHandDict = new Dictionary<string, int>();
        Dictionary<string, int> playerHandDict = new Dictionary<string, int>();

        //changes to current after first round, final at last round
        string handInTextState = "starting";

        public HighestMatch() : base(2, new StandardDeck(RNG))
        {
            Rounds = RoundsHighestMatch;
        }

        public void Instructions()
        {
            Print("Both the Dealer or Player 2 and the Player start the game with a hand of four cards.");
            Print("The player will be able to choose one of their cards each round to swap out");
            Print("The replacing card will be randomly drawn from the drawpile.");
            Print("The player will have a maximum of 10 rounds to finish swapping their hand.");
            Print("The player can also choose to compare hands with the dealer at any round, ending the game.");
            Pause();
            
            Print("");
            Print("Ace = 1 point, Jack = 11 points, Queen = 12 points, and King = 13 points");

            Print("");
            Print("The hand with the highest value of matching cards wins");
            Print("Example Hand:");
            Print("    " + "Ace of Hearts" + "    ");
            Print("    " + "Seven of Hearts" + "    ");
            Print("    " + "Seven of Clubs" + "    ");
            Print("    " + "Five of Spades" + "    ");

            Print("");
            Print("This deck would be worth eight points.");
            Print("");
            Pause();

            Print("But, if the player swapped their Seven of Clubs and received a Nine of Clubs");
            Print("The value of the hand would change to nine points.");
            Pause();
        }

        public void Play()
        {
            dealerHand = CalculateHand(false);
            playerNames[1].Score = dealerHand;

            Print("");
            PrintHand();

            for (int i = 0; i <= RoundsHighestMatch; i++)
            {
                Print("");
                Print("Type a number 1 through 4 to swap a card.");
                Print("Or, if you think you have a winning hand,");
                Print("Type 5 to end the game early and compare hands with the dealer.");
                Print("");

                handInTextState = "current";
                char wantSwapInput;
                bool finishedWantSwapInput = true;
                            char input;

                            bool finishedInput = true;
                            while (finishedInput == true)
                            {
                                input = ReadKey().KeyChar;
                                Print("");
                                switch (input)
                                {
                                    case '1':
                                        numberSwapped = 1;
                                        swapCards();
                                        finishedInput = false;
                                        break;
                                    case '2':
                                        numberSwapped = 2;
                                        swapCards();
                                        finishedInput = false;
                                        break;
                                    case '3':
                                        numberSwapped = 3;
                                        swapCards();
                                        finishedInput = false;
                                        break;
                                    case '4':
                                        numberSwapped = 4;
                                        swapCards();
                                        finishedInput = false;
                                        break;
                                    case '5':
                                        i = RoundsHighestMatch + 1;
                                        endGame();
                                        finishedInput = false;
                                        break;
                                    default:
                                        Print("Please type in a number.");
                                        finishedInput = true;
                                        break;
                                }

                            }
                
            }
            //ends game if player has not already chosen to do so
            if (!gameEnded)
            {
                endGame();
            }

        }

        void endGame()
        {
            
            handInTextState = "final";
            int finalHandScore = CalculateHand(true);
            playerNames[0].Score = finalHandScore;

            Print("");
            PrintHand();
            Print("");
            PrintDealersHand();
            Pause();

            
            if (dealerHand < finalHandScore)
            {
                finalHandScore = WinScore;
                CheckWin();
                Print("Congrats!");
            }
            else if (dealerHand > finalHandScore)
            {
                dealerHand = WinScore;
                CheckWin();
            }
            else
            {
                Print("Player 1 has tied with the dealer.");
                Print("There is no winner!");
            }
            gameEnded = true;
        }
        public void Setup()
        {
            playerNames = GetPlayerNames();

            DrawPile.Shuffle();
            for (int i = 0; i < PlayerHands.Count; i++)
            {
                var temp = PlayerHands[i];
                var draw = DrawPile.Draw(4);
                temp.AddRange(draw);
            }
            

        }

        void swapCards()
        {
            //removes card from hand and puts it to the back of drawpile
            Card cardGettingSwapped = PlayerHands[0].Cards[numberSwapped - 1];
            DrawPile.Add(cardGettingSwapped);
            PlayerHands[0].Cards.RemoveAt(numberSwapped -1);

            //draws card and inserts it into the spot that was removed
            var temp = PlayerHands[0];
            var draw = DrawPile.Draw(1);
            
            temp.InsertRange(numberSwapped - 1, draw);

            PrintHand();
        }

        public void PrintHand()
        {
            Print($"This is your {handInTextState} hand:");
            Print($"1. {PlayerHands[0].Cards[0]}");
            Print($"2. {PlayerHands[0].Cards[1]}");
            Print($"3. {PlayerHands[0].Cards[2]}");
            Print($"4. {PlayerHands[0].Cards[3]}");
        }

        public void PrintDealersHand()
        {
            Print($"The Dealer's hand is:");
            Print($"1. {PlayerHands[1].Cards[0]}");
            Print($"2. {PlayerHands[1].Cards[1]}");
            Print($"3. {PlayerHands[1].Cards[2]}");
            Print($"4. {PlayerHands[1].Cards[3]}");
        }

        /// <summary>
        /// calculates hands, bool is true if playerhand
        /// </summary>
        /// <param name="isPlayerHand"></param>
        /// <returns></returns>
        
        public int CalculateHand(bool isPlayerHand)
        {
            int playerHandIndex;
            Dictionary<string, int> usedDictionary;

            if (isPlayerHand)
            {
                playerHandIndex = 0;
                usedDictionary = playerHandDict;
            }
            else
            {
                playerHandIndex = 1;
                usedDictionary = dealerHandDict;
            }
            foreach (string suit in PlayerHands[playerHandIndex].Suits)
            {
                    usedDictionary.Add(suit, 0);                
            }

            for (int i = 0; i < PlayerHands[1].Cards.Count; i++)
            {
                //check contains key for playerhands[1].cards.card.suit add that to the definition value
                string cardSuit = PlayerHands[playerHandIndex].Cards[i].Suit;
                int cardValue = PlayerHands[playerHandIndex].Cards[i].Value;

                if (usedDictionary.ContainsKey(cardSuit))
                {
                    usedDictionary[cardSuit] += cardValue;
                }
            
            }

            /* debug log
            foreach (KeyValuePair<string, int> ele1 in dealerHandDict)
            {
                Console.WriteLine("{0} and {1}",
                        ele1.Key, ele1.Value);
            }
            */

            int handTotal = usedDictionary.Values.Max();
            return handTotal;
        }
    }
}
