using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public static class ValidateBST
    {
        public static bool IsBST<T>(this BinaryTree<T> root) where T : IComparable<T>
        {
            if(root == null) return true;

            bool isSorted = true;

            if(root.Left != null)
            {
                isSorted = isSorted && root.Left.Value.CompareTo(root.Value) <= 0;
            }

            if(root.Right != null)
            {
                isSorted = isSorted && root.Right.Value.CompareTo(root.Value) >= 0;
            }
            
            return isSorted && root.Left.IsBST() && root.Right.IsBST();
        }
    }
}
