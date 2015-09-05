using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public static class DepthsLists
    {
        public static LinkedList<LinkedList<BinaryTree<T>>> GetDepthLists<T>(this BinaryTree<T> root)
        {
            var ret = new LinkedList<LinkedList<BinaryTree<T>>>();
            ret.AddLast(new LinkedList<BinaryTree<T>>(new[] { root }));

            bool hasChildren = root.Left != null || root.Right != null;
            while(hasChildren)
            {
                var currentDepth = new LinkedList<BinaryTree<T>>();
                hasChildren = false;

                foreach(var child in ret.Last.Value)
                {
                    if(child.Left != null)
                    {
                        currentDepth.AddLast(child.Left);
                        hasChildren = true;
                    }

                    if(child.Right != null)
                    {
                        currentDepth.AddLast(child.Right);
                        hasChildren = true;
                    }
                }

                ret.AddLast(currentDepth);
            }

            return ret;
        }
    }
}
