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
            Assert.IsTrue(string.Empty.IsPermutation(string.Empty));

            Assert.IsTrue("a".IsPermutation("a"));

            Assert.IsTrue("ab".IsPermutation("ab"));
            Assert.IsTrue("ab".IsPermutation("ba"));

            Assert.IsTrue("abcde".IsPermutation("abcde"));
            Assert.IsTrue("abcde".IsPermutation("eabcd"));
            Assert.IsTrue("abcde".IsPermutation("deabc"));
            Assert.IsTrue("abcde".IsPermutation("cdeab"));
            Assert.IsTrue("abcde".IsPermutation("bcdea"));
        }

        [TestMethod]
        public void FalseTest()
        {
            Assert.IsFalse("a".IsPermutation(null));
            Assert.IsFalse("a".IsPermutation(string.Empty));
            Assert.IsFalse("a".IsPermutation("b"));

            Assert.IsFalse("abc".IsPermutation("bac"));
            Assert.IsFalse("abc".IsPermutation("abcd"));
        }
    }
}
