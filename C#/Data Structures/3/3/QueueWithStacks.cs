using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;

namespace _3
{
    public class QueueWithStacks<T>
    {
        private readonly Stack<T> _values;
        private readonly Stack<T> _popValues;

        public bool IsEmpty => _values.IsEmpty && _popValues.IsEmpty;

        public int Length => Math.Max(_values.Length, _popValues.Length);

        public int MaxLength => _values.MaxLength;

        public QueueWithStacks(int size)
        {
            _values = new Stack<T>(size);
            _popValues = new Stack<T>(size);
        }

        public QueueWithStacks<T> Enqueue(T value)
        {
            if(_values.IsEmpty)
            {
                MoveTo(_popValues, _values);
            }

            _values.Push(value);
            return this;
        }

        public T Dequeue()
        {
            if(_popValues.IsEmpty)
            {
                MoveTo(_values, _popValues);
            }

            return _popValues.Pop();
        }

        private static void MoveTo<TMove>(Stack<TMove> from, Stack<TMove> to)
        {
            // Clear out the destination stack
            while(!to.IsEmpty)
            {
                to.Pop();
            }

            while(!from.IsEmpty)
            {
                to.Push(from.Pop());
            }
        }
    }
}
