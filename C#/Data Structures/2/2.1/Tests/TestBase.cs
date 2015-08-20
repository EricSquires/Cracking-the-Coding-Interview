using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2._1.Answers;
using LinkedList;

namespace Tests
{
    [TestClass]
    public class TestBase<T> where T : IDupeRemover, new()
    {
        protected T TestObject { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            TestObject = new T();
        }

        [TestMethod]
        public void NoDupes()
        {
            var input = new LinkedListNode<int>();
            var expected = new LinkedListNode<int>();

            TestObject.RemoveDupes(input);
            Assert.AreEqual(expected, input);

            input = new LinkedListNode<int>(1);
            expected = new LinkedListNode<int>(1);

            TestObject.RemoveDupes(input);
            Assert.AreEqual(expected, input);

            input = new LinkedListNode<int>(1, 2, 3, 4, 5);
            expected = new LinkedListNode<int>(1, 2, 3, 4, 5);

            TestObject.RemoveDupes(input);
            Assert.AreEqual(expected, input);

            input = new LinkedListNode<int>(0, 1, 2, 3, 4, 5);
            expected = new LinkedListNode<int>(0, 1, 2, 3, 4, 5);

            TestObject.RemoveDupes(input);
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void OneDupeAdjacent()
        {
            var input = new LinkedListNode<int>(1, 2, 3, 3, 4, 5);
            var expected = new LinkedListNode<int>(1, 2, 3, 4, 5);

            TestObject.RemoveDupes(input);
            Assert.AreEqual(expected, input);
        }
    }
}
