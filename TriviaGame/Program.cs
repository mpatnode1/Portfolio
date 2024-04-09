using System;
using static System.Console;

//Name: Meghan Patnode

/* Minimum three custom classes, each with properties and methods (e.g., Game, Player, and TriviaItem)
Credits in comments (in Program.cs)
The project compiles and runs with no errors
Your name(s) and a title in the window's title bar.
Application title and your name(s) printed to the console window.
Instructions printed to the screen
*/

namespace TriviaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Super Awesome Trivia Game!";
            new Game();
            Console.ReadKey();
        }
    }
}