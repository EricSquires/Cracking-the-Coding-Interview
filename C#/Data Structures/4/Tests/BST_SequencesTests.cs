using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _4;
using DS;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BST_SequencesTests
    {
        [TestMethod]
        public void BookTest()
        {
            var bst = new BST<int>(2);
            bst.Insert(1);
            bst.Insert(3);

            var actual = BST_Sequences.GetSequences(bst).ToArray();

            Assert.AreEqual(2, actual.Length);

            Assert.IsTrue(VerifyOutput(new[] { 2, 1, 3 }, actual));
            Assert.IsTrue(VerifyOutput(new[] { 2, 3, 1 }, actual));
        }

        [TestMethod]
        public void InOrderTests()
        {
            var bst = new BST<int>(0);
            bst.Insert(1);
            bst.Insert(2);
            bst.Insert(3);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(6);
            bst.Insert(7);
            bst.Insert(8);
            bst.Insert(9);

            var actual = BST_Sequences.GetSequences(bst).ToArray();

            Assert.AreEqual(1, actual.Length);

            Assert.IsTrue(VerifyOutput(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, actual));

            bst = new BST<int>(9);
            bst.Insert(8);
            bst.Insert(7);
            bst.Insert(6);
            bst.Insert(5);
            bst.Insert(4);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(1);
            bst.Insert(0);

            actual = BST_Sequences.GetSequences(bst).ToArray();

            Assert.AreEqual(1, actual.Length);

            Assert.IsTrue(VerifyOutput(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, actual));
        }

        [TestMethod]
        public void NormalTests()
        {
            var bst = new BST<int>(3);
            bst.Insert(2);
            bst.Insert(2);
            bst.Insert(7);
            bst.Insert(5);

            var actual = BST_Sequences.GetSequences(bst).ToArray();

            Assert.AreEqual(6, actual.Length, GetTestMessage(actual));

            Assert.IsTrue(VerifyOutput(new[] { 3, 2, 7, 2, 5 }, actual));
            Assert.IsTrue(VerifyOutput(new[] { 3, 2, 7, 5, 2 }, actual));
            Assert.IsTrue(VerifyOutput(new[] { 3, 7, 2, 5, 2 }, actual));
            Assert.IsTrue(VerifyOutput(new[] { 3, 7, 2, 2, 5 }, actual));
            Assert.IsTrue(VerifyOutput(new[] { 3, 2, 2, 7, 5 }, actual));
            Assert.IsTrue(VerifyOutput(new[] { 3, 7, 5, 2, 2 }, actual));
        }

        [TestMethod]
        public void GetPermutationsSimpleTests()
        {
            var actual = BST_Sequences.GetPermutations(new[] { 1 }, new[] { 4 }).ToArray();

            Assert.AreEqual(2, actual.Length, GetTestMessage(actual));

            Assert.IsTrue(VerifyOutput(new[] { 1, 4 }, actual), GetTestMessage(actual));
            Assert.IsTrue(VerifyOutput(new[] { 4, 1 }, actual), GetTestMessage(actual));
        }

        [TestMethod]
        public void GetPermutationsTests()
        {
            var actual = BST_Sequences.GetPermutations(new[] { 1, 2 }, new[] { 4, 5 }).ToArray();

            Assert.AreEqual(6, actual.Length, GetTestMessage(actual));

            Assert.IsTrue(VerifyOutput(new[] { 1, 2, 4, 5 }, actual), GetTestMessage(actual));
            Assert.IsTrue(VerifyOutput(new[] { 1, 4, 2, 5 }, actual), GetTestMessage(actual));
            Assert.IsTrue(VerifyOutput(new[] { 1, 4, 5, 2 }, actual), GetTestMessage(actual));
            Assert.IsTrue(VerifyOutput(new[] { 4, 1, 2, 5 }, actual), GetTestMessage(actual));
            Assert.IsTrue(VerifyOutput(new[] { 4, 1, 5, 2 }, actual), GetTestMessage(actual));
            Assert.IsTrue(VerifyOutput(new[] { 4, 5, 1, 2 }, actual), GetTestMessage(actual));
        }

        private string GetTestMessage<T>(IEnumerable<IEnumerable<T>> actual)
        {
            return Environment.NewLine + string.Join(Environment.NewLine, actual.Select(s => string.Join(", ", s)));
        }

        private bool VerifyOutput(IList<int> expected, IEnumerable<IEnumerable<int>> actual)
        {
            foreach(var a in actual)
            {
                if(VerifyOutputItem(expected, a))
                {
                    return true;
                }
            }

            return false;
        }

        private bool VerifyOutputItem(IList<int> expected, IEnumerable<int> actual)
        {
            var i = 0;
            foreach (var a in actual)
            {
                if (expected[i] != a)
                {
                    return false;
                }

                i++;
            }

            return true;
        }
    }
}
