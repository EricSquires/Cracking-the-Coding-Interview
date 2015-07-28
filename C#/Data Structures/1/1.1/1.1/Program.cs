using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            IUniqueTester tester = new UniqueNaive();
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
                    Console.WriteLine($"'{input}': is {(tester.IsUnique(input) ? "" : "NOT ")}unique");
                }
            }
            while(!string.IsNullOrWhiteSpace(input));
        }
    }
}
