using System;
using LinkedList;

namespace _2._8
{
    public static class Answer
    {
        public static LinkedListNode<T> GetLoopHead<T>(LinkedListNode<T> head)
        {
            var slowNode = head;
            var fastNode = head;
            bool isFirst = true;

            while(fastNode != null)
            {
                if(!isFirst && ReferenceEquals(slowNode, fastNode))
                {
                    var l = head.Length;
                    for(var i = 0; i < l; i++, head = head.Next);
                    return head;
                }

                slowNode = slowNode.Next;
                fastNode = fastNode.Next?.Next;
                isFirst = false;
            }

            return null;
        }
    }
}
