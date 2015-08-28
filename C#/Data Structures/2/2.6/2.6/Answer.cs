using System;
using LinkedList;

namespace _2._6
{
    public static class Answer
    {
        public static bool IsPalindrome<T>(this LinkedListNode<T> head) where T : IEquatable<T>
        {
            var stack = new System.Collections.Generic.Stack<T>();
            var current = head;

            int midFirst = head.Length / 2;
            int midLast = midFirst + (head.Length % 2 == 0 ? 1 : 2);

            for(var i = 0; i < head.Length; i++, current = current.Next)
            {
                if(i <= midFirst)
                {
                    stack.Push(current.Value);
                }
                else if(i >= midLast)
                {
                    var val = stack.Pop();

                    if(!val.Equals(current.Value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
