using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class BinaryTree<T>
    {
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }

        public T Value { get; }

        public BinaryTree(T value)
        {
            Value = value;
        }
    }
}
