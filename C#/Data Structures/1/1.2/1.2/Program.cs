using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2
{
    class Program : PerformanceTesting.PerformanceProgramBase
    {
        private readonly Random _rand = new Random();

        static void Main(string[] args)
        {
            var obj = new Program();
            obj.Run(args);
        }

        protected override void InteractiveMode(string[] args)
        {
            IPermutationChecker testObj = new PermutationNaive();
            string input1, input2;

            do
            {
                Console.Write("Enter string 1: ");
                input1 = Console.ReadLine().Trim();

                Console.Write("Enter string 2: ");
                input2 = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(input1) && string.IsNullOrWhiteSpace(input2))
                {
                    Console.WriteLine("Exiting...");
                }
                else
                {
                    Console.WriteLine($"\"{input1}\".IsPermutation(\"{input2}\"): {testObj.IsPermutation(input1, input2)}");
                }
            }
            while (!string.IsNullOrWhiteSpace(input1) || !string.IsNullOrWhiteSpace(input2));
        }

        protected override void TimingMode(string[] args)
        {
            IPermutationChecker[] testObjs =
                {
                    new PermutationNaive()
                };

            foreach(var obj in testObjs)
            {
                Time((Tuple<string, string> param) => obj.IsPermutation(param.Item1, param.Item2), (int _) => GetParam(true));
                Time((Tuple<string, string> param) => obj.IsPermutation(param.Item1, param.Item2), (int _) => GetParam(false));
            }
        }

        private Tuple<string, string> GetParam(bool permute)
        {
            string input1, input2;

            input1 = GenerateTestString();

            if(permute)
            {
                input2 = Permute(input1);
            }
            else
            {
                input2 = GenerateTestString();
            }

            return new Tuple<string, string>(input1, input2);
        }

        private string GenerateTestString()
        {
            const int _STRING_MIN = 10;
            const int _STRING_MAX = 50;

            const int _CHAR_MIN = 'a';
            const int _CHAR_MAX = 'Z';

            string ret = string.Empty;

            int len = _rand.Next(_STRING_MIN, _STRING_MAX + 1);
            for(var i = 0; i < len; i++)
            {
                ret += (char)_rand.Next(_CHAR_MIN, _CHAR_MAX + 1);
            }

            return ret;
        }

        private string Permute(string txt)
        {
            int idx = _rand.Next(txt.Length);
            return txt.Substring(0, idx) + txt.Substring(idx, txt.Length - idx);
        }
    }
}
