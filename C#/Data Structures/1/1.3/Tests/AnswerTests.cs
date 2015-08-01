using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._3;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class AnswerTests
    {
        private static readonly Tuple<string, string>[] _INPUT_OUTPUT =
            {
                new Tuple<string, string>("http://www.microsoft.com", "http://www.microsoft.com"),
                new Tuple<string, string>("http://www.test.com/some url", "http://www.test.com/some%20url"),
                new Tuple<string, string>("http://www.test.com/double  space", "http://www.test.com/double%20%20space"),
                new Tuple<string, string>("http://www.test.com/multiple spaces/across folders", "http://www.test.com/multiple%20spaces/across%20folders"),
                new Tuple<string, string>("non url", "non%20url"),
                new Tuple<string, string>("nonurl", "nonurl"),
            };

        [TestMethod]
        public void AnswerRealWorldTests()
        {
            RunTests(new URLRealWorld(), _INPUT_OUTPUT);
        }

        [TestMethod]
        public void AnswerSelfImplementedTests()
        {
            RunTests(new URLSelfImplemented(), _INPUT_OUTPUT);
        }

        private void RunTests(IURLifier answer, IEnumerable<Tuple<string, string>> inputOutput)
        {
            foreach(var vals in inputOutput)
            {
                Assert.AreEqual(answer.URLify(vals.Item1), vals.Item2);
            }
        }
    }
}
