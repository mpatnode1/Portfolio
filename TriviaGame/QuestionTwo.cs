using System.Collections;
using System.Net.Sockets;

namespace TriviaGame
{
    class QuestionTwo
    {
        private bool Stop = true;
        public bool CorrectTwo = false;
     
        public QuestionTwo()
        {
           Console.WriteLine("How many colors are in the rainbow?");
           Console.WriteLine("Choose from one of the four options by typing in 1, 2, 3, or 4.");
           Console.WriteLine("Options: 1.) Seven 2.) Five 3.) Three 4.) Eight");
           
           while (Stop == true){
            string AnswerOne = Console.ReadLine();
           switch(AnswerOne)
           {
                case "1":
                Console.WriteLine("You answered 1.) Seven. Great job! That is Correct!");
                CorrectTwo = true;
                Stop = false;
                break;

                case "2":
                Console.WriteLine("You answered 2.) Five. Unfortunately, that is INCORRECT.");
                Stop = false;
                break;

                case "3":
                Console.WriteLine("You answered 3.) Three. Unfortunately, that is INCORRECT.");
                Stop = false;
                break;

                case "4":
                Console.WriteLine("You answered 4.) Eight. Unfortunately, that is INCORRECT.");
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