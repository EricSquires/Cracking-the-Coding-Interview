using PerformanceTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3
{
    class Program : PerformanceProgramBase
    {
        private const int _MIN_TEST_STR_LEN = 10;
        private const int _MAX_TEST_STR_LEN = 30;

        private readonly Random _rand = new Random();

        static void Main(string[] args)
        {
            var obj = new Program();
            obj.Run(args);
        }

        protected override void InteractiveMode(string[] args)
        {
            IURLifier answer = new URLSelfImplemented();

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

        protected override void TimingMode(string[] args)
        {
            var testObjs = new IURLifier[]
                {
                    new URLRealWorld(),
                    new URLSelfImplemented()
                };

            foreach(var testObj in testObjs)
            {
                double avgTime = Time(testObj.URLify, (int _) => GetTestString());
                Console.WriteLine($"{testObj.GetType().ToString(),40} : {avgTime:N5} ms");
            }

            Console.ReadKey();
        }

        private string GetTestString()
        {
            const int _MIN_CHAR = 'a';
            const int _MAX_CHAR = 'z';

            var ret = new StringBuilder();

            int len = _rand.Next(_MIN_TEST_STR_LEN, _MAX_TEST_STR_LEN);
            for(var i = 0; i < len; i++)
            {
                ret.Append((char)_rand.Next(_MIN_CHAR, _MAX_CHAR));
            }

            int numSpaces = _rand.Next(5);
            var spaces = new bool[ret.Length];
            for(var i = 0; i < numSpaces; i++)
            {
                int idx;
                
                do
                {
                    idx = _rand.Next(ret.Length);
                }
                while(spaces[idx]);

                spaces[idx] = true;
                ret[idx] = ' ';
            }

            return ret.ToString();
        }
    }
}
