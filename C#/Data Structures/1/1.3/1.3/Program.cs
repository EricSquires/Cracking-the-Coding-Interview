using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnswer answer = new AnswerSelfImplemented();

            string input;

            do
            {
                Console.Write("Enter string: ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Exiting...");
                }
                else
                {
                    Console.WriteLine($"URLify('{input}'): {answer.URLify(input)}");
                }
            }
            while (!string.IsNullOrWhiteSpace(input));
        }
    }
}
