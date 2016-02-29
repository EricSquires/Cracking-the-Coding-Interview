using Microsoft.VisualStudio.TestTools.UnitTesting;
using _4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class CheckSubtreeTests
    {
        private static readonly Random _RAND = new Random();
        private const int _VAL_MAX = 1000000000;

        [TestMethod()]
        public void IsSubtreeTest()
        {
            var a = new CheckSubtree<int>(1);
            var b = a.Clone();

            Assert.IsTrue(a.IsSubtree(b));

            a.Left = new CheckSubtree<int>(2);
            b = new CheckSubtree<int>(2);

            Assert.IsTrue(a.IsSubtree(b));
            
            for (var i = 0; i < 1000; i++)
            {
                a = GenerateRandomTree(10);
                b = GetRandomSubtree(a);

                Assert.IsTrue(a.IsSubtree(b));
            }
        }

        private CheckSubtree<T> GetRandomSubtree<T>(CheckSubtree<T> root)
        {
            var prob = 1.0 / root.NumChildren;
            var queue = new Queue<CheckSubtree<T>>();

            queue.Enqueue(root);
            CheckSubtree<T> current = null;

            while(queue.Count > 0)
            {
                current = queue.Dequeue();

                if(_RAND.Next() <= prob)
                {
                    return current;
                }

                if(current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if(current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }

            return current;
        }

        private CheckSubtree<int> GenerateRandomTree(int numNodes)
        {
            if(numNodes <= 0)
            {
                return null;
            }

            var root = new CheckSubtree<int>(_RAND.Next());

            var leaves = new List<CheckSubtree<int>>();
            leaves.Add(root);

            for(var i = 1; i < numNodes; i++)
            {
                var index = _RAND.Next(leaves.Count);
                var parent = leaves[index];
                var node = new CheckSubtree<int>(_RAND.Next(_VAL_MAX));

                if(parent.Left == null)
                {
                    if(parent.Right == null)
                    {
                        if(_RAND.NextDouble() <= 0.5)
                        {
                            parent.Left = node;
                        }
                        else
                        {
                            parent.Right = node;
                        }
                    }
                    else
                    {
                        parent.Left = node;
                        leaves.RemoveAt(index);
                    }
                }
                else
                {
                    parent.Right = node;
                    leaves.RemoveAt(index);
                }

                leaves.Add(node);
            }

            return root;
        }
    }
}