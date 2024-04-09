using System.Collections;
using System.Net.Sockets;

namespace TriviaGame
{
    class QuestionThree
    {
        private bool Stop = true;
        public bool CorrectThree = false;
     
        public QuestionThree()
        {
           Console.WriteLine("What is Cynophobia the fear of?");
           Console.WriteLine("Choose from one of the four options by typing in 1, 2, 3, or 4.");
           Console.WriteLine("Options: 1.) Signs 2.) Dogs 3.) Thunder 4.) Men");
           
           while (Stop == true){
            string AnswerOne = Console.ReadLine();
           switch(AnswerOne)
           {
                case "1":
                Console.WriteLine("You answered 1.) Signs. Unfortunately, that is INCORRECT.");
                Stop = false;
                break;

                case "2":
                Console.WriteLine("You answered 2.) Dogs. Great job! That is Correct!");
                CorrectThree = true;
                Stop = false;
                break;

                case "3":
                Console.WriteLine("You answered 3.) Thunder. Unfortunately, that is INCORRECT.");
                Stop = false;
                break;

                case "4":
                Console.WriteLine("You answered 4.) Men. Unfortunately, that is INCORRECT.");
                Stop = false;
                break;

                default:
                Console.WriteLine("I'm sorry I'm not sure what you mean. Try typing a number 1, 2, 3, or 4 to answer.");
                break;
           }
           
           }
        }
    }
}