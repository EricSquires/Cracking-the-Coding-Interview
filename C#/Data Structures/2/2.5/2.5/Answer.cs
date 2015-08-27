using System;
using LinkedList;

namespace _2._5
{
    public static class Answer
    {
        private const int _DEFAULT_BASE = 10;

        public static LinkedListNode<int> AddOnesFirst(LinkedListNode<int> a, LinkedListNode<int> b, int numBase = _DEFAULT_BASE)
        {
            var ret = new LinkedListNode<int>();
            int remainder = 0;

            while(a != null || b != null)
            {
                var val = remainder;

                if(a != null)
                {
                    val += a.Value;
                }

                if(b != null)
                {
                    val += b.Value;
                }

                remainder = val / numBase;
                val = val % numBase;

                ret.Add(val);

                a = a?.Next;
                b = b?.Next;
            }

            if(remainder > 0)
            {
                ret.Add(remainder);
            }

            return ret;
        }
    }
}
