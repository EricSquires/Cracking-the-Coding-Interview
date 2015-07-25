using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            do
            {
                Console.Write("Enter string: ");
                input = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Exiting...");
                }
                else
                {
                    Console.WriteLine($"'{input}': is {(input.IsUnique() ? "" : "NOT ")}unique");
                }
            }
            while(!string.IsNullOrWhiteSpace(input));
        }
    }
}
