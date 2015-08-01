using _1._4.Answers;
using PerformanceTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4
{
    class Program : PerformanceProgramBase
    {
        private readonly Random _rand = new Random();

        static void Main(string[] args)
        {
            var obj = new Program();
            obj.Run(args);
        }

        protected override void InteractiveMode(string[] args)
        {
            IPalindromePermutationChecker checker = new PalPermNaive();

            string input;

            do
            {
                Console.Write("Enter string: ");
                input = Console.ReadLine();

                if(!string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine($"'{input}': {checker.IsPalindromePermutation(input)}");
                }
            }
            while(string.IsNullOrWhiteSpace(input));
        }

        protected override void TimingMode(string[] args)
        {
            var testObjs = new IPalindromePermutationChecker[]
                {
                    new PalPermNaive(),
                    new PalPermSort(),
                    new PalPermBitVector()
                };

            foreach(var testObj in testObjs)
            {
                double avgTime = Time(testObj.IsPalindromePermutation, (int _) => GetTestString(true));
                Console.WriteLine($"{testObj.GetType().ToString(),40} permutation    : {avgTime:N5} ms");

                avgTime = Time(testObj.IsPalindromePermutation, (int _) => GetTestString(false));
                Console.WriteLine($"{testObj.GetType().ToString(),40} non-permutation: {avgTime:N5} ms");
            }
        }

        private string GetTestString(bool isPalindrome)
        {
            const int _MIN_LENGTH = 20;
            const int _MAX_LENGTH = 50;

            const int _CHAR_MIN = 'A';
            const int _CHAR_MAX = 'z';

            string ret = string.Empty;

            var len = _rand.Next(_MIN_LENGTH, _MAX_LENGTH);

            if(isPalindrome)
            {
                len = len/2;
            }

            for(var i = 0; i < len; i++)
            {
                ret += (char)_rand.Next(_CHAR_MIN, _CHAR_MAX);
            }
            
            if(isPalindrome)
            {
                string secondHalf = ret;
                if(len % 2 == 1)
                {
                    ret += (char)_rand.Next(_CHAR_MIN, _CHAR_MAX);
                }

                ret += secondHalf;
            }

            return ret;
        }
    }
}
