using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public static class CheckBalance
    {
        public static bool IsBalanced<T>(this BinaryTree<T> root)
        {
            return Math.Abs(CountDepth(root.Left) - CountDepth(root.Right)) <= 1;
        }

        private static int CountDepth<T>(BinaryTree<T> root)
        {
            if(root == null) return 0;

            int leftDepth = CountDepth(root.Left);
            int rightDepth = CountDepth(root.Right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}
