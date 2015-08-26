using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;
using _2._4;

namespace Tests
{
    [TestClass]
    public class PartitionTests
    {
        [TestMethod]
        public void AllLowTests()
        {
            var input = new LinkedListNode<int>(1, 2, 3, 4, 5, 6);

            Assert.IsTrue(IsPartitioned(input.Partition(7), 7));
        }

        [TestMethod]
        public void AllHighTests()
        {
            var input = new LinkedListNode<int>(1, 2, 3, 4, 5, 6);

            Assert.IsTrue(IsPartitioned(input.Partition(0), 0));
        }

        [TestMethod]
        public void MidPartitionTests()
        {
            var input = new LinkedListNode<int>(3, 5, 8, 5, 10, 2, 1);

            Assert.IsTrue(IsPartitioned(input.Partition(5), 5));
        }

        private bool IsPartitioned<T>(LinkedListNode<T> head, T partitionValue) where T : IComparable
        {
            bool isHigh = head.Value.CompareTo(partitionValue) >= 0;

            for(var current = head; current != null; current = current.Next)
            {
                if (current.Value.CompareTo(partitionValue) >= 0)
                {
                    isHigh = true;
                }
                else if (isHigh)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
