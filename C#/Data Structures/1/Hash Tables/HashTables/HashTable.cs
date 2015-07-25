using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    public class HashTable<T> : ICollection<T>
    {
        private const int _DEFAULT_SIZE = 100;

        // Don't want indices changing, so only accept this at initialization.
        // Use the built-in hash function by default
        private readonly Func<T, int> _hashFunc = (T item) => item.GetHashCode();

        // Start with the built-in linked list implementation. We can revisit this and implement it by hand later since this is all for practice.
        private readonly LinkedList<T>[] _data;

        // Just use this for now. Not exactly performant, but this isn't likely to be used all that often in reasonable uses of a hash table.
        public int Count => _data.Sum(l => l == null ? 0 : l.Count);

        public bool IsReadOnly { get; } = false;

        #region Ctors

        /// <summary>
        /// Initialize the <see cref="HashTable{T}"/> with the default size (100)
        /// </summary>
        /// <param name="hashFunc">The hashing function to use for inserting and retrieving data</param>
        public HashTable(Func<T, int> hashFunc) : this(hashFunc, _DEFAULT_SIZE)
        {
        }

        public HashTable(Func<T, int> hashFunc, int size) : this(size)
        {
            _hashFunc = hashFunc;
        }

        /// <summary>
        /// By default, we'll just use the given type's hash function.
        /// </summary>
        public HashTable() : this(_DEFAULT_SIZE)
        {
        }

        public HashTable(int size)
        {
            _data = new LinkedList<T>[size];
        }

        #endregion

        // Good excuse to try out new expression bodied function feature.
        // Just calculate the hash and cap it to the length of the data array.
        private int GetIndex(T item)
        {
            int hash = _hashFunc(item);

            // If the hash is the minimum value, we need to increment by one to avoid an overflow exception in twos complement scenarios
            if(hash == int.MinValue)
            {
                hash++;
            }

            return Math.Abs(hash) % _data.Length;
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if(_data[index] == null)
            {
                _data[index] = new LinkedList<T>();
            }

            _data[index].AddFirst(item);
        }

        public void Clear()
        {
            foreach(var lst in _data)
            {
                lst?.Clear();
            }
        }

        public bool Contains(T item)
        {
            if(item == null)
            {
                return false;
            }

            int index = GetIndex(item);

            return _data[index] != null && _data[index].Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach(var item in this)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            return _data[index]?.Remove(item) ?? false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var lst in _data)
            {
                if (lst == null)
                {
                    continue;
                }

                foreach (var item in lst)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
