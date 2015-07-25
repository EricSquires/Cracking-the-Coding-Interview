using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._2;

namespace Tests
{
    [TestClass]
    public class AnswerTests
    {
        [TestMethod]
        public void TrueTest()
        {
            Assert.IsTrue("abcde".IsPermutation(""));
        }
    }
}
