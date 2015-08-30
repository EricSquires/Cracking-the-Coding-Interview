using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    public class SetOfStacks<T>
    {
        private readonly List<DS.Stack<T>> _stacks = new List<DS.Stack<T>>();
        private int _currentStack = -1;

        public int NumStacks => _stacks.Count(s => !s.IsEmpty);

        public int Length => _stacks.Sum(s => s.Length);

        public int MaxStackSize { get; }

        public SetOfStacks(int maxStackSize)
        {
            MaxStackSize = maxStackSize;
        }

        public SetOfStacks<T> Push(T value)
        {
            if(_currentStack < 0 || _stacks[_currentStack].Length == MaxStackSize)
            {
                _currentStack++;

                if(_stacks.Count == _currentStack)
                {
                    _stacks.Add(new DS.Stack<T>(MaxStackSize));
                }
            }

            _stacks.Last().Push(value);
            return this;
        }

        public T Pop()
        {
            if(_currentStack < 0)
            {
                throw new InvalidOperationException();
            }

            if (_stacks[_currentStack].IsEmpty)
            {
                _currentStack--;
            }

            try
            {
                return PopAt(_currentStack);
            }
            catch(IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }

        public T PopAt(int index)
        {
            if (index < 0 || index > _currentStack)
            {
                throw new IndexOutOfRangeException();
            }

            return _stacks[index].Pop();
        }
    }
}
