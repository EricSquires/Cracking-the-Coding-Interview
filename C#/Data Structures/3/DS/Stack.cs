using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class Stack<T>
    {
        private T[] _values;
        int _currentIndex = -1;

        public int Length
        {
            get { return _currentIndex + 1; }
        }
        
        public bool IsEmpty => Length == 0;
        
        public int MaxLength => _values.Length;

        public Stack(int size)
        {
            _values = new T[size];
        }

        /// <summary>
        /// Adds <paramref name="value"/> to the stack. Returns this stack for convenient chaining of Push calls.
        /// </summary>
        public Stack<T> Push(T value)
        {
            if(_currentIndex == _values.Length - 1)
            {
                throw new InvalidOperationException("Stack is full");
            }

            _currentIndex++;
            _values[_currentIndex] = value;
            return this;
        }

        /// <summary>
        /// Returns the top element in the stack and removes it from the stack.
        /// </summary>
        public T Pop()
        {
            if(_currentIndex < 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var ret = Peek();
            _currentIndex--;
            return ret;
        }

        /// <summary>
        /// Returns the top element in the stack.
        /// </summary>
        public T Peek()
        {
            return _values[_currentIndex];
        }
    }
}
