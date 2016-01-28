using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    /// <summary>
    /// A super general binary tree class that essentially defines the bare minimum for a class to be considered a binary tree.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the BinaryTree</typeparam>
    public class BinaryTree<T>
    {
        /// <summary>
        /// The left child of this node
        /// </summary>
        public BinaryTree<T> Left { get; set; }

        /// <summary>
        /// The right child of this node
        /// </summary>
        public BinaryTree<T> Right { get; set; }

        /// <summary>
        /// The value stored in the current node
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Initializes the node with the given value. The value is required as we're not allowing uninitialized nodes for simplicity sake.
        /// </summary>
        /// <param name="value">The value stored in the node</param>
        public BinaryTree(T value)
        {
            Value = value;
        }
    }
}
