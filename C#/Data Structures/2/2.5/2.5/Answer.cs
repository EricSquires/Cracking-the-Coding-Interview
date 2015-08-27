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

            while (a != null || b != null)
            {
                var val = remainder;

                if (a != null)
                {
                    val += a.Value;
                }

                if (b != null)
                {
                    val += b.Value;
                }

                remainder = val / numBase;
                val = val % numBase;

                ret.Add(val);

                a = a?.Next;
                b = b?.Next;
            }

            if (remainder > 0)
            {
                ret.Add(remainder);
            }

            return ret;
        }
        
        public static LinkedListNode<int> AddOnesLast(LinkedListNode<int> a, LinkedListNode<int> b, int numBase = _DEFAULT_BASE)
        {
            var recurseRet = AddOnesLastRecursive(a, b, numBase);
            LinkedListNode<int> ret;

            if(recurseRet.Item1 != 0)
            {
                ret = new LinkedListNode<int>(recurseRet.Item1);
                ret.Add(recurseRet.Item2);
            }
            else
            {
                ret = recurseRet.Item2;
            }

            return ret;
        }

        private static Tuple<int, LinkedListNode<int>> AddOnesLastRecursive(LinkedListNode<int> a, LinkedListNode<int> b, int numBase)
        {
            int remainder = 0;
            int value = 0;

            LinkedListNode<int> aNext = null, bNext = null;

            if(a == null && b == null)
            {
                return null;
            }
            else if(b == null || a.Length > b.Length)
            {
                value = a.Value;

                aNext = a.Next;
                bNext = b;
            }
            else if(a == null || b.Length > a.Length)
            {
                value = b.Value;

                aNext = a;
                bNext = b.Next;
            }
            else
            {
                value = a.Value + b.Value;

                remainder = value / numBase;
                value = value % numBase;

                aNext = a.Next;
                bNext = b.Next;
            }
            
            var ret = new LinkedListNode<int>(value);

            var nextRet = AddOnesLastRecursive(aNext, bNext, numBase);

            if (nextRet != null)
            {
                ret.Value += nextRet.Item1;

                remainder += ret.Value / numBase;
                ret.Value = ret.Value % numBase;

                ret.Add(nextRet.Item2);
            }

            return Tuple.Create(remainder, ret);
        }
    }
}
