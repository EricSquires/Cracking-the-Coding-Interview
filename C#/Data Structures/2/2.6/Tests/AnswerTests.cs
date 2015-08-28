using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2._6;
using LinkedList;

namespace Tests
{
    [TestClass]
    public class AnswerTests
    {
        [TestMethod]
        public void TrueTests()
        {
            var input = new LinkedListNode<int>(1, 2, 3, 2, 1);
            
            Assert.IsTrue(input.IsPalindrome());

            input = new LinkedListNode<int>(1, 2, 3, 3, 2, 1);

            Assert.IsTrue(input.IsPalindrome());
        }

        [TestMethod]
        public void FalseTests()
        {
            var input = new LinkedListNode<int>(1, 2, 3, 4, 5);

            Assert.IsFalse(input.IsPalindrome());

            input = new LinkedListNode<int>(1, 2, 3, 4, 5, 6);

            Assert.IsFalse(input.IsPalindrome());

            input = new LinkedListNode<int>(1, 2, 3, 1, 1);

            Assert.IsFalse(input.IsPalindrome());

            input = new LinkedListNode<int>(1, 2, 3, 4, 2, 1);

            Assert.IsFalse(input.IsPalindrome());
        }
    }
}
