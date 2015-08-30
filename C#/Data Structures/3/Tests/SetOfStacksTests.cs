using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3;

namespace Tests
{
    [TestClass]
    public class SetOfStacksTests
    {
        [TestMethod]
        public void InitializeTests()
        {
            var s = new SetOfStacks<int>(10);
            
            Assert.AreEqual(0, s.Length);
            Assert.AreEqual(0, s.NumStacks);
            Assert.AreEqual(10, s.MaxStackSize);
        }

        [TestMethod]
        public void PushTests()
        {
            var s = new SetOfStacks<int>(3);

            for (var i = 0; i < 10; i++)
            {
                s.Push(i);
                
                Assert.AreEqual(i + 1, s.Length);
                Assert.AreEqual(i / 3 + 1, s.NumStacks);
            }
        }

        [TestMethod]
        public void PopTests()
        {
            var s = new SetOfStacks<int>(3);

            for (var i = 0; i < 10; i++)
            {
                s.Push(i);
            }

            for (var i = s.Length - 1; i >= 0; i--)
            {
                Assert.AreEqual(i / 3 + 1, s.NumStacks);
                Assert.AreEqual(i, s.Pop());
                Assert.AreEqual(i, s.Length);
                Assert.AreEqual(Math.Ceiling(i / 3.0), s.NumStacks);
            }

            Assert.AreEqual(0, s.Length);
            Assert.AreEqual(0, s.NumStacks);
        }

        [TestMethod]
        public void PopAtTests()
        {
            var s = new SetOfStacks<int>(3);

            for (var i = 0; i < 10; i++)
            {
                s.Push(i);
            }

            Assert.AreEqual(2, s.PopAt(0));
            Assert.AreEqual(5, s.PopAt(1));
            Assert.AreEqual(8, s.PopAt(2));
            Assert.AreEqual(9, s.PopAt(3));

            Assert.AreEqual(7, s.Pop());
            Assert.AreEqual(6, s.Pop());
            Assert.AreEqual(4, s.Pop());
            Assert.AreEqual(3, s.Pop());
            Assert.AreEqual(1, s.Pop());
            Assert.AreEqual(0, s.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetOfStacksEmptyTests()
        {
            var s = new SetOfStacks<int>(10);
            s.Pop();
        }
    }
}
