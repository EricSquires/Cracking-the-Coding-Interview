using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2._5;
using LinkedList;

namespace Tests
{
    [TestClass]
    public class OnesLastTests
    {
        [TestMethod]
        public void EvenAdds()
        {
            var a = new LinkedListNode<int>(6, 1, 7);
            var b = new LinkedListNode<int>(2, 9, 5);
            var expected = new LinkedListNode<int>(9, 1, 2);

            Assert.AreEqual(expected, Answer.AddOnesLast(a, b));

            a = new LinkedListNode<int>(1);
            b = new LinkedListNode<int>(1);
            expected = new LinkedListNode<int>(2);

            Assert.AreEqual(expected, Answer.AddOnesLast(a, b));

            a = new LinkedListNode<int>(5);
            b = new LinkedListNode<int>(5);
            expected = new LinkedListNode<int>(1, 0);

            Assert.AreEqual(expected, Answer.AddOnesLast(a, b));

            a = new LinkedListNode<int>(0);
            b = new LinkedListNode<int>(1);
            expected = new LinkedListNode<int>(1);

            Assert.AreEqual(expected, Answer.AddOnesLast(a, b));
        }

        [TestMethod]
        public void EvenAddsBinary()
        {
            var a = new LinkedListNode<int>(1);
            var b = new LinkedListNode<int>(1);
            var expected = new LinkedListNode<int>(1, 0);

            Assert.AreEqual(expected, Answer.AddOnesLast(a, b, 2));

            a = new LinkedListNode<int>(0);
            b = new LinkedListNode<int>(1);
            expected = new LinkedListNode<int>(1);

            Assert.AreEqual(expected, Answer.AddOnesLast(a, b, 2));
        }

        [TestMethod]
        public void UnevenAdds()
        {
            var a = new LinkedListNode<int>(9, 9, 7);
            var b = new LinkedListNode<int>(4);
            var expected = new LinkedListNode<int>(1, 0, 0, 1);

            Assert.AreEqual(expected, Answer.AddOnesLast(a, b));
            
            a = new LinkedListNode<int>(5, 4, 8, 4, 1);
            b = new LinkedListNode<int>(8, 4, 1);
            expected = new LinkedListNode<int>(5, 5, 6, 8, 2);

            Assert.AreEqual(expected, Answer.AddOnesLast(a, b));
        }

        [TestMethod]
        public void UnevenAddsBinary()
        {
            var a = new LinkedListNode<int>(1, 0);
            var b = new LinkedListNode<int>(1);
            var expected = new LinkedListNode<int>(1, 1);

            Assert.AreEqual(expected, Answer.AddOnesLast(a, b, 2));

            a = new LinkedListNode<int>(1, 0, 1);
            b = new LinkedListNode<int>(1, 1);
            expected = new LinkedListNode<int>(1, 0, 0, 0);

            Assert.AreEqual(expected, Answer.AddOnesLast(a, b, 2));

            a = new LinkedListNode<int>(1, 0, 0, 0, 1);
            b = new LinkedListNode<int>(1, 0, 0, 1, 1);
            expected = new LinkedListNode<int>(1, 0, 0, 1, 0, 0);

            Assert.AreEqual(expected, Answer.AddOnesLast(a, b, 2));
        }
    }
}
