/*
Meghan Patnode
 */

using System;

namespace SubstitutionCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "This is my Substitution Cipher Coder and Decoder";
            Console.WriteLine("This code encodes and decodes potato.");

            var startCipher = new Cipher("qfhrywasvlmiczujexkbdgnopt");
            string EncodeResult = startCipher.Encode("potato");
            string DecodeResult = startCipher.Decode("jubqbu");
            
            Console.WriteLine(EncodeResult);
            Console.WriteLine(DecodeResult);

            Console.ReadKey();

        }
    }
}