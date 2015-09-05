using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public static class GetNext
    {
        public static BST<T> Next<T>(this BST<T> node) where T : IComparable<T>
        {
            if(node == null) return null;

            return node.Right.Next() ?? node.Parent.Next() ?? node;
        }
    }
}
