using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._1.Solutions;

namespace Tests
{
    [TestClass]
    public class BitVectorTests
    {
        private BitVector _testObject;

        [TestInitialize]
        public void Initialize()
        {
            _testObject = new BitVector();
        }

        [TestMethod]
        public void Add()
        {
            Assert.IsTrue(_testObject.Add(' '));
            Assert.IsTrue(_testObject.Add('a'));
            Assert.IsTrue(_testObject.Add('A'));
            Assert.IsTrue(_testObject.Add('z'));
            Assert.IsTrue(_testObject.Add('Z'));
        }

        [TestMethod]
        public void AddRepeat()
        {
            Assert.IsTrue(_testObject.Add(' '));
            Assert.IsTrue(_testObject.Add('a'));
            Assert.IsTrue(_testObject.Add('A'));
            Assert.IsTrue(_testObject.Add('z'));
            Assert.IsTrue(_testObject.Add('Z'));

            Assert.IsFalse(_testObject.Add(' '));
            Assert.IsFalse(_testObject.Add('a'));
            Assert.IsFalse(_testObject.Add('A'));
            Assert.IsFalse(_testObject.Add('z'));
            Assert.IsFalse(_testObject.Add('Z'));
        }
    }
}
