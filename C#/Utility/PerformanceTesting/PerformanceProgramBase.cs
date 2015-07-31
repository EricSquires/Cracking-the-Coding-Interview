using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTesting
{
    public abstract class PerformanceProgramBase
    {
        private const int _DEFAULT_NUM_TESTS = 100000;

        protected abstract void TimingMode(string[] args);
        protected abstract void InteractiveMode(string[] args);

        public void Run(string[] args)
        {
            if (args.Length > 0 && args[0] == "-i")
            {
                InteractiveMode(args);
            }
            else
            {
                TimingMode(args);
            }
        }

        /// <summary>
        /// Standard method for simple performance testing  of answers for CTCI.
        /// </summary>
        /// <typeparam name="TParam">The type of parameter required by the function to be tested</typeparam>
        /// <param name="testFunc">The function to test</param>
        /// <param name="getParamFunc">The function to get the parameter for each test.
        ///                            The current iteration will be provided as an argument to the function.</param>
        /// <param name="numTests">The number of tests to run. Any value &lt;= 0 will be replaced with <see cref="_DEFAULT_NUM_TESTS"/></param>
        /// <returns>The average number of miliseconds per execution.</returns>
        protected double Time<TParam, TResult>(
            Func<TParam, TResult> testFunc,
            Func<int, TParam> getParamFunc,
            int numTests = 0)
        {
            if(numTests <= 0)
            {
                numTests = _DEFAULT_NUM_TESTS;
            }

            // Execute once to incur any initial JIT overhead.
            testFunc(getParamFunc(0));

            var watch = new Stopwatch();

            for (var i = 0; i < numTests; i++)
            {
                TParam input = getParamFunc(i);

                watch.Start();
                TResult res = testFunc(input);
                watch.Stop();
            }

            return (double)watch.ElapsedMilliseconds / numTests;
        }
    }
}
