using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;
using _2._2;

namespace Tests
{
    [TestClass]
    public class AnswerTests
    {
        [TestMethod]
        public void LengthLessThanKTests()
        {
            var input = new LinkedListNode<int>(1, 2, 3, 4, 5, 6);

            Assert.IsNull(input.GetKthToLast(6));
        }

        [TestMethod]
        public void StandardTests()
        {
            var input = new LinkedListNode<int>(1, 2, 3, 4, 5, 6);

            Assert.AreEqual(input.GetKthToLast(0).Value, 6);
            Assert.AreEqual(input.GetKthToLast(1).Value, 5);
            Assert.AreEqual(input.GetKthToLast(2).Value, 4);
            Assert.AreEqual(input.GetKthToLast(3).Value, 3);
            Assert.AreEqual(input.GetKthToLast(4).Value, 2);
            Assert.AreEqual(input.GetKthToLast(5).Value, 1);
        }
    }
}
