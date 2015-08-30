using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3;

namespace Tests
{
    [TestClass]
    public class StackMinTests
    {
        [TestMethod]
        public void SortedTests()
        {
            var s = new StackMin<int>();

            for(var i = 10; i >= 0; i--)
            {
                s.Push(i);
                Assert.AreEqual(i, s.Minimum);
            }
        }

        [TestMethod]
        public void RandomTests()
        {
            const int _NUM_ITERATIONS = 100;
            const int _MIN_INSERTS = 10;
            const int _MAX_INSERTS = 100;

            var rand = new Random();

            for(var i = 0; i < _NUM_ITERATIONS; i++)
            {
                var s = new StackMin<int>();
                int min = int.MaxValue;

                for(var j = 0; j < rand.Next(_MIN_INSERTS, _MAX_INSERTS); j++)
                {
                    var num = rand.Next(int.MinValue, int.MaxValue);

                    if(num < min)
                    {
                        min = num;
                    }

                    s.Push(num);

                    Assert.AreEqual(min, s.Minimum);
                }
            }
        }
    }
}
