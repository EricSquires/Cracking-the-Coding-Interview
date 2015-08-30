using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    public class StackMin<T> where T : IComparable<T>
    {
        private class StackMinNode
        {
            public StackMinNode Next { get; set; }
            public T Value { get; set; }
            public StackMinNode Min { get; set; }

            public StackMinNode(T value)
            {
                Value = value;
            }
        }

        private StackMinNode _head;

        public T Minimum => _head.Min.Value;

        public StackMin<T> Push(T value)
        {
            if(_head == null)
            {
                _head = new StackMinNode(value);
                _head.Min = _head;
            }
            else
            {
                var newHead = new StackMinNode(value);
                
                if(newHead.Value.CompareTo(_head.Min.Value) <= 0)
                {
                    newHead.Min = newHead;
                }
                else
                {
                    newHead.Min = _head.Min;
                }

                newHead.Next = _head;
                _head = newHead;
            }

            return this;
        }

        public T Pop()
        {
            var ret = _head.Value;
            _head = _head.Next;
            return ret;
        }
    }
}
