using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    class Program
    {
        private static readonly char[] _CHARACTERS = new char[]
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', ']', '{', '}', '\\', '|', ';', ':', '\'', '"', ',', '<', '.', '>', '/', '?'
            };

        private const int _NUM_TESTS = 100000;
        private const int _TEST_STR_LEN = 60;

        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            if(args.Length > 0 && args[0] == "-i")
            {
                InteractiveMode();
            }
            else
            {
                TimingMode();
            }
        }

        private static void TimingMode()
        {
            var testObjects = new IUniqueTester[]
                {
                    new UniqueNaive(),
                    new UniqueSet()
                };

            foreach(var testObj in testObjects)
            {
                TimeExecution(testObj);
            }

            Console.ReadKey();
        }

        private static void TimeExecution(IUniqueTester testObject)
        {
            // Run through a couple times just to try to get the JIT performance hit out of the way
            testObject.IsUnique(GetTestString(2, true));
            testObject.IsUnique(GetTestString(2, false));

            var watch = new Stopwatch();

            for(var i = 0; i < _NUM_TESTS; i++)
            {
                string txt = GetTestString(_TEST_STR_LEN, true);
                watch.Start();
                bool res = testObject.IsUnique(txt);
                watch.Stop();

                if (!res)
                {
                    Console.WriteLine($"ERROR: expected unique '{txt}'");
                }
            }

            Console.WriteLine($"{testObject.GetType().ToString(),40} unique     : {((double)watch.ElapsedMilliseconds / _NUM_TESTS),10} ms");
            
            watch.Reset();

            for (var i = 0; i < _NUM_TESTS; i++)
            {
                string txt = GetTestString(_TEST_STR_LEN, false);
                watch.Start();
                bool res = testObject.IsUnique(txt);
                watch.Stop();

                if (res)
                {
                    Console.WriteLine($"ERROR: expected not unique '{txt}'");
                }
            }

            Console.WriteLine($"{testObject.GetType().ToString(),40} non-unique : {(double)watch.ElapsedMilliseconds / _NUM_TESTS,10} ms");
        }

        private static string GetTestString(int length, bool isUnique)
        {
            char[] array = Shuffle(_CHARACTERS).Take(length).ToArray();

            if(!isUnique)
            {
                array[array.Length - 1] = array[0];
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

        private static void InteractiveMode()
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
