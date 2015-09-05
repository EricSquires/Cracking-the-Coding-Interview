using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _4;
using DS;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class DepthsListsTests
    {
        [TestMethod]
        public void SingleNodeTests()
        {
            var input = new BinaryTree<int>(1);

            VerifyOutput(input, input.GetDepthLists());
        }

        [TestMethod]
        public void BSTTests()
        {
            var input = new BST<int>(5);

            input.Insert(2);
            input.Insert(3);
            input.Insert(1);
            input.Insert(4);

            input.Insert(7);
            input.Insert(6);
            input.Insert(9);
            input.Insert(8);

            VerifyOutput(input, input.GetDepthLists());

            input = new BST<int>(1);

            input.Insert(2);
            input.Insert(3);
            input.Insert(4);
            input.Insert(5);
            input.Insert(6);
            input.Insert(7);
            input.Insert(8);
            input.Insert(9);
            input.Insert(10);

            VerifyOutput(input, input.GetDepthLists());

            input = new BST<int>(10);

            input.Insert(5);
            input.Insert(3);
            input.Insert(4);
            input.Insert(5);
            input.Insert(6);
            input.Insert(9);
            input.Insert(8);
            input.Insert(10);
            input.Insert(20);

            VerifyOutput(input, input.GetDepthLists());
        }

        private void VerifyOutput<T>(BinaryTree<T> input, LinkedList<LinkedList<BinaryTree<T>>> output)
        {
            var expected = GetExpectedOutput(input);

            foreach(var expectedValue in expected)
            {
                if(output.Count == 0)
                {
                    Assert.Fail();
                }

                Console.Write(output.First.Value.First.Value.Value);
                Assert.AreSame(expectedValue, output.First.Value.First.Value);

                output.First.Value.RemoveFirst();

                if(output.First.Value.Count == 0)
                {
                    output.RemoveFirst();
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(" -> ");
                }
            }

            if(output.Count > 0 && !(output.Count == 1 && output.First.Value.Count == 0))
            {
                Assert.Fail();
            }
        }

        private IEnumerable<BinaryTree<T>> GetExpectedOutput<T>(BinaryTree<T> input)
        {
            if(input == null)
            {
                yield return null;
            }

            var queue = new Queue<BinaryTree<T>>();
            queue.Enqueue(input);

            do
            {
                var current = queue.Dequeue();
                yield return current;

                if(current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if(current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }
            while(queue.Count > 0);
        }
    }
}
