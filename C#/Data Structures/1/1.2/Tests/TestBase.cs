using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._2;

namespace Tests
{
    [TestClass]
    public abstract class TestBase<T> where T : IPermutationChecker, new()
    {
        protected T TestObject { get; private set; }

        [TestInitialize]
        public void TestInitialize()
        {
            TestObject = new T();
        }

        [TestMethod]
        public void TrueTest()
        {
            Assert.IsTrue(TestObject.IsPermutation(string.Empty, string.Empty));

            Assert.IsTrue(TestObject.IsPermutation("a", "a"));

            Assert.IsTrue(TestObject.IsPermutation("ab", "ab"));
            Assert.IsTrue(TestObject.IsPermutation("ab", "ba"));

            Assert.IsTrue(TestObject.IsPermutation("abc", "bac"));

            Assert.IsTrue(TestObject.IsPermutation("abcde", "abcde"));
            Assert.IsTrue(TestObject.IsPermutation("abcde", "eabcd"));
            Assert.IsTrue(TestObject.IsPermutation("abcde", "deabc"));
            Assert.IsTrue(TestObject.IsPermutation("abcde", "cdeab"));
            Assert.IsTrue(TestObject.IsPermutation("abcde", "bcdea"));
        }

        [TestMethod]
        public void FalseTest()
        {
            Assert.IsFalse(TestObject.IsPermutation("a", null));
            Assert.IsFalse(TestObject.IsPermutation("a", string.Empty));
            Assert.IsFalse(TestObject.IsPermutation("a", "b"));

            Assert.IsFalse(TestObject.IsPermutation("abc", "abd"));
            Assert.IsFalse(TestObject.IsPermutation("abc", "abcd"));
        }
    }
}
