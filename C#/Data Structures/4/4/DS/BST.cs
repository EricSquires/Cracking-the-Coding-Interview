using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class BST<T> where T : IComparable<T>
    {
        public BST<T> Left { get; private set; }
        public BST<T> Right { get; private set; }

        public T Value { get; }

        public BST(T value)
        {
            Value = value;
        }

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
