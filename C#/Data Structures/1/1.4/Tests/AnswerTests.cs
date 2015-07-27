using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._4;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class AnswerTests
    {
        private static readonly TestData[] _TESTS = new[]
        {
            new TestData(null, true, true),
            new TestData(string.Empty, true, true),

            new TestData("a", true, true),
            new TestData("bab", true, true),
            new TestData("cbaabc", true, true),
            new TestData("aabccb", false, true),
            new TestData("dbabd", true, true),
            new TestData("abddb", false, true),
            new TestData("aaaa", true, true),
            new TestData("aaaaa", true, true),

            new TestData("abcd", false, false),
            new TestData("abedca", false, false)
        };

        [TestMethod]
        public void NaiveTests()
        {
            RunTest(new AnswerNaive(), _TESTS);
        }

        private void RunTest(IAnswer answer, IEnumerable<TestData> tests)
        {
            foreach(var test in tests)
            {
                Assert.AreEqual(answer.IsPalindrome(test.Input), test.IsPalindrome, $"IsPalindrome('{test.Input}') expected: {test.IsPalindrome}");
                Assert.AreEqual(answer.IsPalindromePermutation(test.Input), test.IsPalindromePermutation, $"IsPalindromePermutation('{test.Input}') expected: {test.IsPalindromePermutation}");
            }
        }
    }
}
