using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class Queue<T>
    {
        private T[] _values;
        private int _currentIndex = 0;
        
        public int Length { get; private set; } = 0;

        public bool IsEmpty => Length == 0;

        public Queue(int size)
        {
            _values = new T[size];
        }

        /// <summary>
        /// Adds <paramref name="value"/> to the queue. Returns this queue for convenient chaining of Enqueue calls.
        /// </summary>
        public Queue<T> Enqueue(T value)
        {
            if(Length == _values.Length)
            {
                throw new InvalidOperationException("Queue is full");
            }

            _values[Length] = value;
            Length++;
            return this;
        }

        /// <summary>
        /// Returns the next element in the queue and removes it from the queue.
        /// </summary>
        public T Dequeue()
        {
            if(Length == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var ret = Peek();

            Length--;
            _currentIndex = (_currentIndex + 1) % _values.Length;
            return ret;
        }

        /// <summary>
        /// Returns the next element in the queue.
        /// </summary>
        public T Peek()
        {
            return _values[_currentIndex];
        }
    }
}
