using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTables;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class HashTableTests
    {
        private static readonly Func<string, int> _SIMPLE_STRING_HASH = (string item) => char.ToLower(item[0]) - 'a';

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

        [TestMethod]
        public void StringInsert()
        {
            var t = new HashTable<string>();

            t.Add("b");
            t.Add("A");
            t.Add("Aa");

            Assert.AreEqual(t.Count, 3);

            Assert.IsTrue(t.Contains("b"));
            Assert.IsTrue(t.Contains("A"));
            Assert.IsTrue(t.Contains("Aa"));

            Assert.IsFalse(t.Contains("B"));
            Assert.IsFalse(t.Contains("a"));
            Assert.IsFalse(t.Contains("AA"));
        }

        [TestMethod]
        public void EmptyString()
        {
            var t = new HashTable<string>();

            t.Add(string.Empty);

            Assert.AreEqual(t.Count, 1);

            Assert.IsTrue(t.Contains(string.Empty));

            Assert.IsFalse(t.Contains(" "));
            Assert.IsFalse(t.Contains(null));
        }

        [TestMethod]
        public void IntInsert()
        {
            var t = new HashTable<int>();

            t.Add(0);
            t.Add(int.MaxValue);
            t.Add(int.MinValue);

            Assert.IsTrue(t.Contains(0));
            Assert.IsTrue(t.Contains(int.MaxValue));
            Assert.IsTrue(t.Contains(int.MinValue));

            Assert.IsFalse(t.Contains(1));
            Assert.IsFalse(t.Contains(-1));
            Assert.IsFalse(t.Contains(int.MinValue + 1));
            Assert.IsFalse(t.Contains(int.MaxValue - 1));
        }

        [TestMethod]
        public void CopyTo()
        {
            var t = new HashTable<string>(_SIMPLE_STRING_HASH, 26);

            t.Add("b");
            t.Add("A");
            t.Add("BB");

            var arr = new string[t.Count];
            t.CopyTo(arr, 0);

            Assert.AreEqual(arr[0], "A");
            Assert.AreEqual(arr[1], "BB");
            Assert.AreEqual(arr[2], "b");
        }
    }
}
