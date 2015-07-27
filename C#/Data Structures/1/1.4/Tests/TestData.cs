using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._4;
using System.Collections.Generic;

namespace Tests
{
    internal class TestData
    {
        public string Input { get; }
        public bool IsPalindrome { get; }
        public bool IsPalindromePermutation { get; }

        public TestData(string input, bool isPalindrome, bool isPalindromePermutation)
        {
            Input = input;
            IsPalindrome = isPalindrome;
            IsPalindromePermutation = isPalindromePermutation;
        }
    }
}