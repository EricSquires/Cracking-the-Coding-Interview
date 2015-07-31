using _1._2.Answers;
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
        private readonly IPermutationChecker _checker = new PermutationNaive();

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
                    new PermutationNaive(),
                    new PermutationSort()
                };

            foreach(var obj in testObjs)
            {
                double avgTime = Time((Tuple<string, string> param) => obj.IsPermutation(param.Item1, param.Item2), (int _) => GetParam(true));
                Console.WriteLine($"{obj.GetType().ToString(),40} permutation    : {avgTime:N5} ms");

                avgTime = Time((Tuple<string, string> param) => obj.IsPermutation(param.Item1, param.Item2), (int _) => GetParam(false));
                Console.WriteLine($"{obj.GetType().ToString(),40} non-permutation: {avgTime:N5} ms");
            }

            Console.ReadKey();
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
                do
                {
                    input2 = GenerateTestString();
                }
                while(_checker.IsPermutation(input1, input2));
            }

            return new Tuple<string, string>(input1, input2);
        }

        private string GenerateTestString()
        {
            const int _STRING_MIN = 10;
            const int _STRING_MAX = 50;

            const int _CHAR_MIN = 'A';
            const int _CHAR_MAX = 'z';

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
            return new string(Shuffle(txt.ToArray()));
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
    }
}
