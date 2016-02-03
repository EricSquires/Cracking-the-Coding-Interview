using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public class CheckSubtree<T>
    {
        private int _numChildren = 0;

        private CheckSubtree<T> _parent;

        private CheckSubtree<T> _left;
        public CheckSubtree<T> Left
        {
            get { return _left; }
            set
            {
                _left = value;

                if (Left != null)
                {
                    Left._parent = this;
                    _numChildren += Left._numChildren + 1;
                }
            }
        }

        private CheckSubtree<T> _right;
        public CheckSubtree<T> Right
        {
            get { return _right; }
            set
            {
                _right = value;

                if (Right != null)
                {
                    Right._parent = this;
                    _numChildren += Right._numChildren + 1;
                }
            }
        }

        public T Value { get; set; }

        public CheckSubtree(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Checks if the given tree is a subtree of this one
        /// </summary>
        /// <returns>true if <paramref name="other"/> is a subtree of this node, false otherwise</returns>
        public bool IsSubtree(CheckSubtree<T> other)
        {
            return other._numChildren == _numChildren && IsSubtreeCheckValues(other);
        }

        private bool IsSubtreeCheckValues(CheckSubtree<T> other)
        {
            return other.Value.Equals(Value)
                && (Left == null || Left.IsSubtreeCheckValues(other.Left))
                && (Right == null || Right.IsSubtreeCheckValues(other.Right));
        }

        public CheckSubtree<T> Clone()
        {
            var clone = new CheckSubtree<T>(Value);

            clone.Left = Left?.Clone();
            clone.Right = Right?.Clone();
            
            return clone;
        }
    }
}
