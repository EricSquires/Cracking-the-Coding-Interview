using LinkedList;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2
{
    public static class Answer
    {
        public static LinkedListNode<T> GetKthToLast<T>(this LinkedListNode<T> head, int k)
        {
            LinkedListNode<T> current = head;
            
            // Iterate until i = k. At that point, head is the answer.
            for(var i = 1; current != null && i < k; i++, current = current.Next);

            // The list contains fewer than k elements, return null since there's no answer.
            if(current == null)
            {
                return null;
            }

            LinkedListNode<T> ret = head;

            // We're at the kth element, so head is the current answer. Simply iterate to the end of the list, incrementing ret
            // at the same time. Whatever ret ends up being is the answer.
            for(; current != null; ret = ret.Next, current = current.Next);

            return ret;
        }
    }
}
