using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Prog2_CardGame
{
    internal class Utility
    {
        public static void Print(string message) { WriteLine("    " + message + "    "); }
        public static void Pause()
        {
            Print("Press Enter to continue...");
            Console.ReadKey();
        }
    }
}
