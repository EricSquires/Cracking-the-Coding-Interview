using LinkedList;
using System;

namespace _2._4
{
    public static class Answer
    {
        public static LinkedListNode<T> Partition<T>(this LinkedListNode<T> head, T partitionValue) where T : IComparable
        {
            var high = new LinkedListNode<T>();
            var low = new LinkedListNode<T>();
            LinkedListNode<T> lowTail = null;

            for(var current = head; current != null; current = current.Next)
            {
                if(current.Value.CompareTo(partitionValue) < 0)
                {
                    lowTail = low.Add(current.Value);
                }
                else
                {
                    high.Add(current.Value);
                }
            }

            if(lowTail != null)
            {
                lowTail.Next = high;
                high.Last = lowTail;
                return low;
            }
            else
            {
                return high;
            }
        }
    }
}
