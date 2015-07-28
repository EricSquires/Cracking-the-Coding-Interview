using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._1;

namespace Tests
{
    [TestClass]
    public class TestBase<T> where T : IUniqueTester, new()
    {
        protected static readonly string[] _UNIQUE_INPUT = new string[]
            {
                "a",
                "aA",
                "ab",
                "`'/.,][{}<>\""
            };

        protected static readonly string[] _NOT_UNIQUE_INPUT = new string[]
            {
                "aa",
                "aAa",
                "aAa",
                "\"aBcDeFs\"R",
                "abcddefgbz",
                "  "
            };

        protected T TestObject { get; private set; }

        [TestInitialize]
        public void TestInitialize()
        {
            TestObject = new T();
        }

        [TestMethod]
        public void Empty()
        {
            Assert.IsTrue(TestObject.IsUnique(string.Empty));
        }

        [TestMethod]
        public void Null()
        {
            Assert.IsTrue(TestObject.IsUnique(null));
        }

        [TestMethod]
        public void Unique()
        {
            foreach(var input in _UNIQUE_INPUT)
            {
                Assert.IsTrue(TestObject.IsUnique(input));
            }
        }

        [TestMethod]
        public void NotUnique()
        {
            foreach (var input in _NOT_UNIQUE_INPUT)
            {
                Assert.IsFalse(TestObject.IsUnique(input));
            }
        }
    }
}
