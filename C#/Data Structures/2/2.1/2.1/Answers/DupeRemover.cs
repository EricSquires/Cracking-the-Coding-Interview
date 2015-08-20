using System;
using LinkedList;

namespace _2._1.Answers
{
    public class DupeRemover : IDupeRemover
    {
        public void RemoveDupes<T>(LinkedListNode<T> head)
        {
            var values = new System.Collections.Generic.HashSet<T>();
            var current = head;

            do
            {
                if(!values.Add(current.Value))
                {
                    current.Remove();
                }

                current = current.Next;
            }
            while(current != null);

            current = head.Last;

            while(current != null)
            {
                if (!values.Add(current.Value))
                {
                    current.Remove();
                }

                current = current.Last;
            }
        }
    }
}
