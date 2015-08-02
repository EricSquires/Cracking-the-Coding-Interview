using _1_5.Answers;
using PerformanceTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_5
{
    class Program : PerformanceProgramBase
    {
        private readonly Random _rand = new Random();

        private readonly char[] _chars = new char[]
            {
                    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };

        static void Main(string[] args)
        {
            var obj = new Program();
            obj.Run(args);
        }

        protected override void InteractiveMode(string[] args)
        {
            IOneAwayChecker checker = new OneAwaySimple();

            string input;

            do
            {
                Console.Write("Enter string: ");
                input = Console.ReadLine();

                //if(!string.IsNullOrWhiteSpace(input))
                //{
                //    Console.WriteLine($"'{input}': {checker.IsPalindromePermutation(input)}");
                //}
            }
            while (string.IsNullOrWhiteSpace(input));
        }

        protected override void TimingMode(string[] args)
        {
            var testObjs = new IOneAwayChecker[]
                {
                    new OneAwaySimple()
                };

            foreach (var testObj in testObjs)
            {
                double avgTime = Time((Tuple<string, string> param) => testObj.IsOneAway(param.Item1, param.Item2), (int _) => GetTestData(false));
                Console.WriteLine($"{testObj.GetType().ToString(),40} not one off : {avgTime:N5} ms");

                avgTime = Time((Tuple<string, string> param) => testObj.IsOneAway(param.Item1, param.Item2), (int _) => GetTestData(true));
                Console.WriteLine($"{testObj.GetType().ToString(),40} one off     : {avgTime:N5} ms");
            }
        }

        private Tuple<string, string> GetTestData(bool isOneOff)
        {
            string input1 = GetTestString();

            string input2;
            if (isOneOff)
            {
                input2 = GetOneOff(input1);
            }
            else
            {
                input2 = GetTestString();
            }

            return new Tuple<string, string>(input1, input2);
        }

        private string GetTestString()
        {
            const int _MIN_LEN = 10;
            const int _MAX_LEN = 30;

            string ret = string.Empty;

            for (var i = 0; i < _rand.Next(_MIN_LEN, _MAX_LEN); i++)
            {
                ret += GetChar();
            }

            return ret.ToString();
        }

        private string GetOneOff(string txt)
        {
            var ret = new StringBuilder(txt);

            int editIndex = _rand.Next(ret.Length);
            switch (_rand.Next(3))
            {
                case 0:
                    ret.Remove(editIndex, 1);
                    break;

                case 1:
                    ret.Insert(editIndex, GetChar());
                    break;

                case 2:
                    ret[editIndex] = GetChar();
                    break;
            }

            return ret.ToString();
        }

        private char GetChar()
        {
            return _chars[_rand.Next(_chars.Length)];
        }
    }
}
