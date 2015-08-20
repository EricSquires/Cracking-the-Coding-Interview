using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedListNode<T>
    {
        public T Value { get; set; }

        public LinkedListNode<T> Next { get; private set; }
        public LinkedListNode<T> Last { get; private set; }

        public LinkedListNode(IEnumerable<T> values)
        {
            var currentNode = this;

            foreach(var val in values)
            {
                if(currentNode == this)
                {
                    Value = val;
                }
                else
                {
                    currentNode = Add(val);
                }
            }
        }

        public LinkedListNode(params T[] values) : this((IEnumerable<T>)values) { }

        public LinkedListNode(T value)
        {
            Value = value;
        }

        public LinkedListNode() : this(default(T)) { }

        public LinkedListNode<T> Add(T value)
        {
            return Add(new LinkedListNode<T>(value));
        }

        /// <summary>
        /// Adds the given node in front of this one for faster performance.
        /// </summary>
        /// <returns>The new head node</returns>
        public LinkedListNode<T> Add(LinkedListNode<T> node)
        {
            node.Next = this;
            node.Last = Last;
            Last = node;

            return node;
        }

        public void Remove()
        {
            if(Last != null)
            {
                Last.Next = Next;
            }

            if(Next != null)
            {
                Next.Last = Last;
            }
        }
    }
}
