using LinkedList;
using System;

namespace _2._3
{
    public static class Answer
    {
        public static void Delete<T>(this LinkedListNode<T> node)
        {
            if(node.Next == null)
            {
                throw new InvalidOperationException("Delete cannot be used on the last element of a list");
            }

            node.Value = node.Next.Value;
            node.Next = node.Next.Next;
        }
    }
}
