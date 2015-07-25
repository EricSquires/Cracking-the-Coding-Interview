using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTables;

namespace Tests
{
    [TestClass]
    public class HashTableTests
    {
        private static readonly Func<string, int> _SIMPLE_STRING_HASH = (string item) => item[0];
        #region Ctors

        [TestMethod]
        public void StringConstructors()
        {
            new HashTable<string>();
            new HashTable<string>(_SIMPLE_STRING_HASH);
            new HashTable<string>(_SIMPLE_STRING_HASH, 10);
        }

        [TestMethod]
        public void IntConstructors()
        {
            new HashTable<int>();
            new HashTable<int>(10);
        }

        #endregion
    }
}
