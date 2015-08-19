using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using _1_5.Answers;

namespace Tests
{
    [TestClass]
    public abstract class TestBase<T> where T : IOneAwayChecker, new()
    {
        protected T TestObject { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            TestObject = new T();
        }

        [TestMethod]
        public void OneAwayTests()
        {
            Assert.IsTrue(TestObject.IsOneAway("pale", "ple"));
            Assert.IsTrue(TestObject.IsOneAway("ple", "pale"));
            Assert.IsTrue(TestObject.IsOneAway("pales", "pale"));
            Assert.IsTrue(TestObject.IsOneAway("pale", "pales"));
            Assert.IsTrue(TestObject.IsOneAway("pale", "bale"));
            Assert.IsTrue(TestObject.IsOneAway("bale", "pale"));
        }

        [TestMethod]
        public void MoreAwayTests()
        {
            Assert.IsFalse(TestObject.IsOneAway("pale", "pke"));
            Assert.IsFalse(TestObject.IsOneAway("pale", "bake"));
            Assert.IsFalse(TestObject.IsOneAway("bake", "pale"));
            Assert.IsFalse(TestObject.IsOneAway("pe", "pale"));
            Assert.IsFalse(TestObject.IsOneAway("pale", "pe"));
        }

        [TestMethod]
        public void ZeroAwayTests()
        {
            Assert.IsTrue(TestObject.IsOneAway("pale", "pale"));
        }
    }
}
