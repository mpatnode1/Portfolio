using static System.Console;
using System;

namespace TriviaGame
{
    class Game
    {
        public int Score = 0;
        Player player;

        QuestionOne questionOne;
        QuestionTwo questionTwo;
        QuestionThree questionThree;

        public Game()
        {

            player = new Player();  

            Console.WriteLine("Welcome to the Super Awesome Trivia Game!");
            Console.WriteLine("Before we get started, what's your name?");

            player.Name = Console.ReadLine();

            Console.WriteLine($"Nice to meet you, {player.Name}");
            Console.WriteLine("You will get three trivia questions. Answer each one by typing 1, 2, 3, or 4, into the console. Get all three questions right to win!");
            Console.WriteLine("Press Enter to begin.");

            Console.ReadKey();
            questionOne = new QuestionOne();
            questionTwo = new QuestionTwo();
            questionThree = new QuestionThree();
            //new QuestionTwo();
        
            Console.WriteLine("That's all the questions! Time to see how you did...");
            Console.WriteLine("Press Enter to continue.");
            
            if (questionOne.CorrectOne == true & questionTwo.CorrectTwo == true & questionThree.CorrectThree == true)
            {
                Console.WriteLine("Congrats you won! You are the trivia MASTER!");
            }
            else
            {
                Console.WriteLine("Better luck next time! Try again to get all three questions right and win.");
            }

        }
    }
}