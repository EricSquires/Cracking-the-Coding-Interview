using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2._5;
using LinkedList;

namespace Tests
{
    [TestClass]
    public class OnesFirstTests
    {
        [TestMethod]
        public void EvenAdds()
        {
            var a = new LinkedListNode<int>(7, 1, 6);
            var b = new LinkedListNode<int>(5, 9, 2);
            var expected = new LinkedListNode<int>(2, 1, 9);

            Assert.AreEqual(expected, Answer.AddOnesFirst(a, b));

            a = new LinkedListNode<int>(1);
            b = new LinkedListNode<int>(1);
            expected = new LinkedListNode<int>(2);

            Assert.AreEqual(expected, Answer.AddOnesFirst(a, b));

            a = new LinkedListNode<int>(5);
            b = new LinkedListNode<int>(5);
            expected = new LinkedListNode<int>(0, 1);

            Assert.AreEqual(expected, Answer.AddOnesFirst(a, b));

            a = new LinkedListNode<int>(0);
            b = new LinkedListNode<int>(1);
            expected = new LinkedListNode<int>(1);

            Assert.AreEqual(expected, Answer.AddOnesFirst(a, b));
        }

        [TestMethod]
        public void EvenAddsBinary()
        {
            var a = new LinkedListNode<int>(1);
            var b = new LinkedListNode<int>(1);
            var expected = new LinkedListNode<int>(0, 1);

            Assert.AreEqual(expected, Answer.AddOnesFirst(a, b, 2));

            a = new LinkedListNode<int>(0);
            b = new LinkedListNode<int>(1);
            expected = new LinkedListNode<int>(1);

            Assert.AreEqual(expected, Answer.AddOnesFirst(a, b, 2));
        }

        [TestMethod]
        public void UnevenAdds()
        {
            var a = new LinkedListNode<int>(7, 9, 9);
            var b = new LinkedListNode<int>(4);
            var expected = new LinkedListNode<int>(1, 0, 0, 1);

            Assert.AreEqual(expected, Answer.AddOnesFirst(a, b));
            
            a = new LinkedListNode<int>(1, 4, 8, 4, 5);
            b = new LinkedListNode<int>(1, 4, 8);
            expected = new LinkedListNode<int>(2, 8, 6, 5, 5);

            Assert.AreEqual(expected, Answer.AddOnesFirst(a, b));
        }

        [TestMethod]
        public void UnevenAddsBinary()
        {
            var a = new LinkedListNode<int>(0, 1);
            var b = new LinkedListNode<int>(1);
            var expected = new LinkedListNode<int>(1, 1);

            Assert.AreEqual(expected, Answer.AddOnesFirst(a, b, 2));

            a = new LinkedListNode<int>(1, 0, 1);
            b = new LinkedListNode<int>(1, 1);
            expected = new LinkedListNode<int>(0, 0, 0, 1);

            Assert.AreEqual(expected, Answer.AddOnesFirst(a, b, 2));

            a = new LinkedListNode<int>(1, 0, 0, 0, 1);
            b = new LinkedListNode<int>(1, 0, 1, 0, 1);
            expected = new LinkedListNode<int>(0, 1, 1, 0, 0, 1);

            Assert.AreEqual(expected, Answer.AddOnesFirst(a, b, 2));
        }
    }
}
