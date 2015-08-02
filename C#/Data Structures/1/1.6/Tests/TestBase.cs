using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._6.Answes;

namespace Tests
{
    [TestClass]
    public class TestBase<T> where T : ICompressor, new()
    {
        protected T TestObject { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            TestObject = new T();
        }

        [TestMethod]
        public void Null()
        {
            Assert.AreEqual(TestObject.Compress(null), null);
        }

        [TestMethod]
        public void Empty()
        {
            Assert.AreEqual(TestObject.Compress(string.Empty), string.Empty);
        }

        [TestMethod]
        public void NormalTests()
        {
            Assert.AreEqual(TestObject.Compress("abc"), "abc");
            Assert.AreEqual(TestObject.Compress("aabbcc"), "a2b2c2");
            Assert.AreEqual(TestObject.Compress("aabaabcaac"), "a2ba2bca2c");
            Assert.AreEqual(TestObject.Compress("aabcccccaaa"), "a2bc5a3");
        }
    }
}
