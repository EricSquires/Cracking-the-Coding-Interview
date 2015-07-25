using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1, input2;

            do
            {
                Console.Write("Enter string 1: ");
                input1 = Console.ReadLine().Trim();

                Console.Write("Enter string 2: ");
                input2 = Console.ReadLine().Trim();

                if(string.IsNullOrWhiteSpace(input1) && string.IsNullOrWhiteSpace(input2))
                {
                    Console.WriteLine("Exiting...");
                }
                else
                {
                    Console.WriteLine($"\"{input1}\".IsPermutation(\"{input2}\"): {input1.IsPermutation(input2)}");
                }
            }
            while(!string.IsNullOrWhiteSpace(input1) || !string.IsNullOrWhiteSpace(input2));
        }
    }
}
