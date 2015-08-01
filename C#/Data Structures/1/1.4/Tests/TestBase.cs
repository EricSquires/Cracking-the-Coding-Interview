using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._4;
using System.Collections.Generic;
using _1._4.Answers;

namespace Tests
{
    [TestClass]
    public abstract class TestBase<T> where T : IPalindromePermutationChecker, new()
    {
        protected T TestObject { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            TestObject = new T();
        }

        [TestMethod]
        public void Palindromes()
        {
            Assert.IsTrue(TestObject.IsPalindromePermutation(null));
            Assert.IsTrue(TestObject.IsPalindromePermutation(string.Empty));
            Assert.IsTrue(TestObject.IsPalindromePermutation("a"));
            Assert.IsTrue(TestObject.IsPalindromePermutation("bab"));
            Assert.IsTrue(TestObject.IsPalindromePermutation("cbaabc"));
            Assert.IsTrue(TestObject.IsPalindromePermutation("aabccb"));
            Assert.IsTrue(TestObject.IsPalindromePermutation("dbabd"));
            Assert.IsTrue(TestObject.IsPalindromePermutation("abddb"));
            Assert.IsTrue(TestObject.IsPalindromePermutation("aaaa"));
            Assert.IsTrue(TestObject.IsPalindromePermutation("aaaaa"));
        }

        [TestMethod]
        public void NonPalindromes()
        {
            Assert.IsFalse(TestObject.IsPalindromePermutation("abcd"));
            Assert.IsFalse(TestObject.IsPalindromePermutation("abedca"));
        }
    }
}
