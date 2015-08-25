using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;
using _2._3;

namespace Tests
{
    [TestClass]
    public class AnswerTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LastElementTests()
        {
            var input = new LinkedListNode<int>(1, 2, 3, 4, 5, 6);

            for(; input.Next != null; input = input.Next);

            input.Delete();
        }

        [TestMethod]
        public void MidElementTests()
        {
            var input = new LinkedListNode<int>(1, 2, 3, 4, 5, 6);
            Get(input, 1).Delete();
            Assert.AreEqual(new LinkedListNode<int>(1, 3, 4, 5, 6), input);

            input = new LinkedListNode<int>(1, 2, 3, 4, 5, 6);
            Get(input, 2).Delete();
            Assert.AreEqual(new LinkedListNode<int>(1, 2, 4, 5, 6), input);

            input = new LinkedListNode<int>(1, 2, 3, 4, 5, 6);
            Get(input, 3).Delete();
            Assert.AreEqual(new LinkedListNode<int>(1, 2, 3, 5, 6), input);

            input = new LinkedListNode<int>(1, 2, 3, 4, 5, 6);
            Get(input, 4).Delete();
            Assert.AreEqual(new LinkedListNode<int>(1, 2, 3, 4, 6), input);
        }

        private LinkedListNode<T> Get<T>(LinkedListNode<T> head, int index)
        {
            var ret = head;

            for(var i = 0; i < index; i++, ret = ret.Next);

            return ret;
        }
    }
}
