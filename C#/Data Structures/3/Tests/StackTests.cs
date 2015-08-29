using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DS;

namespace Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void InitializeTests()
        {
            var s = new Stack<int>(10);

            Assert.IsTrue(s.IsEmpty);
            Assert.AreEqual(0, s.Length);
            Assert.AreEqual(10, s.MaxLength);
        }

        [TestMethod]
        public void PushTests()
        {
            var s = new Stack<int>(10);

            for (var i = 0; i < s.MaxLength; i++)
            {
                s.Push(i);

                Assert.AreEqual(i, s.Peek());
                Assert.AreEqual(i + 1, s.Length);
            }

            Assert.AreEqual(s.MaxLength, s.Length);
        }

        [TestMethod]
        public void PopTests()
        {
            var s = new Stack<int>(10);

            for (var i = 0; i < s.MaxLength; i++)
            {
                s.Push(i);
            }

            Assert.AreEqual(s.Length, s.MaxLength);

            for (var i = s.MaxLength - 1; i >= 0; i--)
            {
                Assert.AreEqual(i, s.Peek());
                Assert.AreEqual(i, s.Pop());
                Assert.AreEqual(i, s.Length);
            }

            Assert.IsTrue(s.IsEmpty);
        }
    }
}
