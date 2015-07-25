using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    public abstract class HashTable<T> : ICollection<T>
    {
        // Don't want indices changing, so only accept this at initialization
        private readonly Func<T, int> _hashFunc;

        // Start with the built-in linked list implementation. We can revisit this and implement it by hand later since this is all for practice.
        private readonly LinkedList<T>[] _data;

        // Just use this for now. Not exactly performant, but this isn't likely to be used all that often in reasonable uses of a hash table.
        public int Count => _data.Sum(l => l == null ? 0 : l.Count);

        public bool IsReadOnly { get; } = false;

        #region Ctors

        public HashTable(Func<T, int> hashFunc, int size)
        {
            _hashFunc = hashFunc;
            _data = new LinkedList<T>[size];
        }

        /// <summary>
        /// Initialize the <see cref="HashTable{T}"/> with the default size (100)
        /// </summary>
        /// <param name="hashFunc">The hashing function to use for inserting and retrieving data</param>
        public HashTable(Func<T, int> hashFunc) : this(hashFunc, 100)
        {
        }

        /// <summary>
        /// By default, we'll just use the given type's hash function.
        /// </summary>
        public HashTable() : this((T item) => item.GetHashCode())
        {
        }

        #endregion

        // Good excuse to try out new expression bodied function feature.
        // Just calculate the hash and cap it to the length of the data array.
        private int GetIndex(T item) => _hashFunc(item) % _data.Length;

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
