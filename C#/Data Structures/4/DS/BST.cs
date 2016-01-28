using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    /// <summary>
    /// A binary search tree implementation of <see cref="BinaryTree{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the tree. This must implement <see cref="IComparable{T}"/> so that the BST can function.</typeparam>
    public class BST<T> : BinaryTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// The parent of the current node
        /// </summary>
        public BST<T> Parent { get; private set; }

        /// <summary>
        /// The left child of this node
        /// </summary>
        new public BST<T> Left
        {
            get { return (BST<T>)base.Left; }
            private set { base.Left = value; }
        }

        /// <summary>
        /// The right child of this node
        /// </summary>
        new public BST<T> Right
        {
            get { return (BST<T>)base.Right; }
            private set { base.Right = value; }
        }

        /// <summary>
        /// Initializes the node with the given value. The value is required as we're not allowing uninitialized nodes for simplicity sake.
        /// </summary>
        /// <param name="value">The value stored in the node</param>
        public BST(T value) : base(value) { }

        /// <summary>
        /// Insert a new value into the BST wherever it's meant to go.
        /// </summary>
        /// <param name="value">The new value to be inserted</param>
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
