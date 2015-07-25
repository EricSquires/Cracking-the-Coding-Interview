using _1._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AnswerTests
    {
        [TestMethod]
        public void Empty()
        {
            Assert.IsTrue(string.Empty.IsUnique());
        }

        [TestMethod]
        public void Null()
        {
            string s = null;
            Assert.IsTrue(s.IsUnique());
        }

        [TestMethod]
        public void Unique()
        {
            Assert.IsTrue("a".IsUnique());
            Assert.IsTrue("aA".IsUnique());
            Assert.IsTrue("ab".IsUnique());
            Assert.IsTrue("`'/.,][{}<>\"".IsUnique());
        }

        [TestMethod]
        public void NotUnique()
        {
            Assert.IsFalse("aa".IsUnique());
            Assert.IsFalse("aAa".IsUnique());
            Assert.IsFalse("aAa".IsUnique());
            Assert.IsFalse("\"aBcDeFs\"R".IsUnique());
            Assert.IsFalse("abcddefgbz".IsUnique());
            Assert.IsFalse("  ".IsUnique());
        }
    }
}
