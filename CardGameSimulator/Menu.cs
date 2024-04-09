using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Prog2_CardGame.Utility;
using static System.Console;

namespace Prog2_CardGame
{
    public class Menu
    {
        private int playerCount;
        public Menu()
        {
            Print("Welcome to a Super Awesome Card Game!");
            Pause();
            MenuOptions();
            
        }

        public void MenuOptions()
        {
            Print("");
            IPlay GameChoice = MenuInput();
            
            Print("Do you want to hear instructions?");
            Print("Type for Yes type 1 and No type 2");
            char instructInput;
            bool instructBreak = true;
            while (instructBreak == true)
            {
                instructInput = ReadKey().KeyChar;
                Print("");
                switch (instructInput)
                {
                    case '1':
                        GameChoice.Instructions();
                        instructBreak = false;
                        break;
                    case '2':
                        instructBreak = false;
                        break;
                    default:
                        Print("Please type in a number.");
                        break;
                }

            }
            GameChoice.Setup();
            GameChoice.Play();

            Print("");
            Print("Would you like to play another game?");

            char playAgainInput;
            bool playAgainBreak = true;

            Print("");
            Print("Type 1 for Yes and 2 for No.");

            while (playAgainBreak == true)
            {
                playAgainInput = ReadKey().KeyChar;
                Print("");
                switch (playAgainInput)
                {
                    case '1':
                        Print("");
                        MenuOptions();
                        playAgainBreak = false;
                        break;
                    case '2':
                        Print("");
                        Print("Thanks for playing!");
                        playAgainBreak = false;
                        break;
                    default:
                        Print("Please type in a number.");
                        break;
                }



            }
        }

            public IPlay MenuInput()
            {
                char input;
                Print("Type a number to select which card game you would like to play, or view credits.");
                Print("1. Same Or Different");
                Print("2. Higher Or Lower");
                Print("3. Highest Match");
                Print("4. View Credits");

                while (true)
                {
                    input = ReadKey().KeyChar;
                    Print("");
                    switch (input)
                    {
                        case '1':
                            return new SameOrDifferent();
                        case '2':
                            return new HigherOrLower();
                        case '3':
                            return new HighestMatch();
                        case '4':
                            Print("Code made by Meghan Patnode");
                            Pause();
                            break;
                        default:
                            Print("Please type in a number.");
                            break;
                    }

                }



            }
            //welcome player to system
            //pick a game
            // 1. Apples and Oranges
            //ReadKey();
            //if 1 set string game = "ApplesAndOranges"
            //switch to game.cs




            public void Quit()
            {
                throw new System.NotImplementedException();
            }
        }
    }
