using LinkedList;
using System;

namespace _2._7
{
    public static class Answer
    {
        public static LinkedListNode<T> GetIntersection<T>(LinkedListNode<T> a, LinkedListNode<T> b)
        {
            var set = new System.Collections.Generic.HashSet<LinkedListNode<T>>(new ReferenceComparer<LinkedListNode<T>>());

            for(var current = a; current.Next != null; current = current.Next)
            {
                set.Add(current);
            }

            for(var current = b; current.Next != null; current = current.Next)
            {
                if(!set.Add(current))
                {
                    return current;
                }
            }

            return null;
        }

        private class ReferenceComparer<T> : System.Collections.Generic.IEqualityComparer<T>
        {
            public bool Equals(T x, T y)
            {
                return ReferenceEquals(x, y);
            }

            public int GetHashCode(T obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
