using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3;

namespace Tests
{
    [TestClass]
    public class QueueWithStacksTests
    {
        [TestMethod]
        public void InitializeTests()
        {
            var q = new QueueWithStacks<int>(10);

            Assert.IsTrue(q.IsEmpty);
        }

        [TestMethod]
        public void EnqueueTests()
        {
            var q = new QueueWithStacks<int>(10);

            for(var i = 0; i < q.MaxLength; i++)
            {
                q.Enqueue(i);
                
                Assert.AreEqual(i + 1, q.Length);
            }
        }

        [TestMethod]
        public void DequeueTests()
        {
            var q = new QueueWithStacks<int>(10);

            for(var i = 0; i < q.MaxLength; i++)
            {
                q.Enqueue(i);
            }

            Assert.AreEqual(q.Length, q.MaxLength);

            for(var i = 0; i < q.MaxLength; i++)
            {
                Assert.AreEqual(i, q.Dequeue());
                Assert.AreEqual(q.MaxLength - (i + 1), q.Length);
            }

            Assert.IsTrue(q.IsEmpty);
        }

        [TestMethod]
        public void InterlacedTests()
        {
            var q = new QueueWithStacks<int>(10);

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Assert.AreEqual(1, q.Dequeue());
            Assert.AreEqual(2, q.Dequeue());

            q.Enqueue(4);
            q.Enqueue(5);

            Assert.AreEqual(3, q.Dequeue());

            q.Enqueue(6);

            Assert.AreEqual(4, q.Dequeue());
            Assert.AreEqual(5, q.Dequeue());
            Assert.AreEqual(6, q.Dequeue());

            Assert.IsTrue(q.IsEmpty);

            q.Enqueue(7);

            Assert.AreEqual(7, q.Dequeue());

            q.Enqueue(8);
            q.Enqueue(9);

            Assert.AreEqual(8, q.Dequeue());
            Assert.AreEqual(9, q.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void QueueEmptyTests()
        {
            var q = new QueueWithStacks<int>(10);
            q.Dequeue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void QueueFullTests()
        {
            var q = new QueueWithStacks<int>(1);
            q.Enqueue(1).Enqueue(2);
        }
    }
}
