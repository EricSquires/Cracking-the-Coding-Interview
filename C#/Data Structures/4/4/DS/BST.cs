using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class BST<T> : BinaryTree<T> where T : IComparable<T>
    {
        public BST<T> Parent { get; private set; }

        new public BST<T> Left
        {
            get { return (BST<T>)base.Left; }
            private set { base.Left = value; }
        }

        new public BST<T> Right
        {
            get { return (BST<T>)base.Right; }
            private set { base.Right = value; }
        }

        public BST(T value) : base(value) { }

        public void Insert(T value)
        {
            if(value.CompareTo(Value) < 0)
            {
                if(Left == null)
                {
                    Left = new BST<T>(value) { Parent = this };
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
                    Right = new BST<T>(value) { Parent = this };
                }
                else
                {
                    Right.Insert(value);
                }
            }
        }
    }
}
