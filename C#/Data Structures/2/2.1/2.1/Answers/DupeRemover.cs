using System;
using LinkedList;

namespace _2._1.Answers
{
    public class DupeRemover : IDupeRemover
    {
        public void RemoveDupes<T>(LinkedListNode<T> head)
        {
            var values = new System.Collections.Generic.HashSet<T>();

            do
            {
                if(!values.Add(head.Value))
                {
                    head.Remove();
                }

                head = head.Next;
            }
            while(head != null);
        }
    }
}
