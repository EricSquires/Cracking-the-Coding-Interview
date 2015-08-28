using System;
using LinkedList;

namespace _2._8
{
    public static class Answer
    {
        public static LinkedListNode<T> GetLoopHead<T>(this LinkedListNode<T> head)
        {
            var slowNode = head;
            var fastNode = head;

            while(fastNode != null)
            {
                if(ReferenceEquals(slowNode, fastNode))
                {
                    for(var i = 0; i < head.Length - slowNode.Length; i++, head = head.Next);
                    return head;
                }

                slowNode = slowNode.Next;
                fastNode = fastNode.Next?.Next;
            }

            return null;
        }
    }
}
