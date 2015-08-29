using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DS;

namespace Tests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void InitializeTests()
        {
            var q = new Queue<int>(10);

            Assert.IsTrue(q.IsEmpty);
        }

        [TestMethod]
        public void EnqueueTests()
        {
            var q = new Queue<int>(10);

            for(var i = 0; i < q.MaxLength; i++)
            {
                q.Enqueue(i);

                Assert.AreEqual(0, q.Peek());
                Assert.AreEqual(i + 1, q.Length);
            }

            Assert.AreEqual(q.MaxLength, q.Length);
        }

        [TestMethod]
        public void DequeueTests()
        {
            var q = new Queue<int>(10);

            for(var i = 0; i < q.MaxLength; i++)
            {
                q.Enqueue(i);
            }

            Assert.AreEqual(q.Length, q.MaxLength);

            for(var i = 0; i < q.MaxLength; i++)
            {
                Assert.AreEqual(i, q.Peek());
                Assert.AreEqual(i, q.Dequeue());
                Assert.AreEqual(q.MaxLength - (i + 1), q.Length);
            }

            Assert.IsTrue(q.IsEmpty);
        }
    }
}
