using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class BST<T> : BinaryTree<T> where T : IComparable<T>
    {
        new public BST<T> Left { get; private set; }
        new public BST<T> Right { get; private set; }

        public BST(T value) : base(value) { }

        public void Insert(T value)
        {
            if(value.CompareTo(Value) < 0)
            {
                if(Left == null)
                {
                    Left = new BST<T>(value);
                }
                else
                {
                    Left.Insert(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new BST<T>(value);
                }
                else
                {
                    Right.Insert(value);
                }
            }
        }
    }
}
