using _1._6.Answes;
using PerformanceTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._6
{
    class Program : PerformanceProgramBase
    {
        static void Main(string[] args)
        {
            var obj = new Program();
            obj.Run(new string[] { "-i" });
        }

        protected override void InteractiveMode(string[] args)
        {
            ICompressor checker = new CompressorSimple();

            string input;

            do
            {
                Console.Write("Enter string: ");
                input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine($"'{input}': '{checker.Compress(input)}'");
                }
            }
            while (string.IsNullOrWhiteSpace(input));

            Console.ReadKey();
        }

        protected override void TimingMode(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
