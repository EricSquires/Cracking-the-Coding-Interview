using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DS;
using _4;

namespace Tests
{
    [TestClass]
    public class CheckBalanceTests
    {
        [TestMethod]
        public void BalancedTests()
        {
            var input = new BST<int>(5);

            input.Insert(3);
            input.Insert(1);
            input.Insert(4);
            input.Insert(2);

            input.Insert(7);
            input.Insert(6);
            input.Insert(8);
            input.Insert(9);

            Assert.IsTrue(input.IsBalanced());

            input = new BST<int>(5);

            input.Insert(3);
            input.Insert(1);
            input.Insert(4);
            input.Insert(2);

            input.Insert(7);
            input.Insert(6);
            input.Insert(8);

            Assert.IsTrue(input.IsBalanced());
        }

        [TestMethod]
        public void NotBalancedTests()
        {
            var input = new BST<int>(10);

            input.Insert(3);
            input.Insert(1);
            input.Insert(4);
            input.Insert(2);

            input.Insert(7);
            input.Insert(6);
            input.Insert(8);
            input.Insert(9);

            Assert.IsFalse(input.IsBalanced());

            input = new BST<int>(0);

            input.Insert(3);
            input.Insert(1);
            input.Insert(4);
            input.Insert(2);

            input.Insert(7);
            input.Insert(6);
            input.Insert(8);
            input.Insert(9);

            Assert.IsFalse(input.IsBalanced());

            input = new BST<int>(2);

            input.Insert(3);
            input.Insert(1);
            input.Insert(4);
            input.Insert(2);

            input.Insert(7);
            input.Insert(6);
            input.Insert(8);
            input.Insert(9);

            Assert.IsFalse(input.IsBalanced());

            input = new BST<int>(7);

            input.Insert(3);
            input.Insert(1);
            input.Insert(4);
            input.Insert(2);

            input.Insert(7);
            input.Insert(6);

            Assert.IsFalse(input.IsBalanced());
        }
    }
}
