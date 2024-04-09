using System.Collections;
using System.Net.Sockets;

namespace TriviaGame
{
    class QuestionOne
    {
        private bool Stop = true;
        public bool CorrectOne = false;
     
        public QuestionOne()
        {
           Console.WriteLine("What is the capitol of the US State Florida?");
           Console.WriteLine("Choose from one of the four options by typing in 1, 2, 3, or 4.");
           Console.WriteLine("Options: 1.) Malibu 2.) Orlando 3.) Tallahasee 4.) Tampa");
           
           while (Stop == true){
            string AnswerOne = Console.ReadLine();
           switch(AnswerOne)
           {
                case "1":
                Console.WriteLine("You answered 1.) Malibu. Unfortunately, that is INCORRECT.");
                Stop = false;
                break;

                case "2":
                Console.WriteLine("You answered 2.) Orlando. Unfortunately, that is INCORRECT.");
                Stop = false;
                break;

                case "3":
                Console.WriteLine("You answered 3.) Tallahasee. Great job! That is Correct!");
                CorrectOne = true;
                Stop = false;
                break;

                case "4":
                Console.WriteLine("You answered 4.) Tampa. Unfortunately, that is INCORRECT.");
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