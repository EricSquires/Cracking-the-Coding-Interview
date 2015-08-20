using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;

namespace Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void Equality()
        {
            var input = new LinkedListNode<int>(0, 1, 2, 3, 4, 5);
            var expected = new LinkedListNode<int>(0, 1, 2, 3, 4, 5);

            Assert.AreEqual(expected, input);
        }
    }
}
