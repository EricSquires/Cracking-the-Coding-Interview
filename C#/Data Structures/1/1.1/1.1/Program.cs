using _1._1.Solutions;
using PerformanceTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    class Program : PerformanceProgramBase
    {
        private static readonly char[] _CHARACTERS = new char[]
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', ']', '{', '}', '\\', '|', ';', ':', '\'', '"', ',', '<', '.', '>', '/', '?'
            };

        private const int _TEST_STR_LEN = 60;

        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            var obj = new Program();
            obj.Run(args);
        }

        protected override void TimingMode(string[] args)
        {
            var testObjects = new IUniqueTester[]
                {
                    new UniqueNaive(),
                    new UniqueSet(),
                    new UniqueBitVector()
                };

            foreach(var testObj in testObjects)
            {
                double avgExec = Time(testObj.IsUnique, (int _) => GetTestString(_TEST_STR_LEN, true));
                Console.WriteLine($"{testObj.GetType().ToString(),40} unique     : {avgExec:N5} ms");

                avgExec = Time(testObj.IsUnique, (int _) => GetTestString(_TEST_STR_LEN, false));
                Console.WriteLine($"{testObj.GetType().ToString(),40} non-unique : {avgExec:N5} ms");
            }

            Console.ReadKey();
        }

        private static string GetTestString(int length, bool isUnique)
        {
            char[] array = Shuffle(_CHARACTERS).Take(length).ToArray();

            if(!isUnique)
            {
                // Generate a couple random indices to ensure the string isn't unique
                int ind1, ind2;
                var rnd = new Random();

                ind1 = rnd.Next(array.Length);

                do
                {
                    ind2 = rnd.Next(array.Length);
                }
                while(ind2 == ind1);

                array[ind1] = array[ind2];
            }

            return new string(array);
        }
        
        public static T[] Shuffle<T>(T[] array)
        {
            var rnd = new Random();

            int n = array.Length;
            while (n > 1)
            {
                int k = rnd.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }

            return array;
        }

        protected override void InteractiveMode(string[] args)
        {
            IUniqueTester tester = new UniqueSet();
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
                    Console.WriteLine($"'{input}': is {(tester.IsUnique(input) ? "" : "NOT ")}unique");
                }
            }
            while (!string.IsNullOrWhiteSpace(input));
        }
    }
}
