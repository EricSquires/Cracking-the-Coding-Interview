using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DS;
using _4;

namespace Tests
{
    [TestClass]
    public class FirstCommonAncestorTests
    {
        /*
                        A
                       / \
                      B   C
                     /\   /\
                    D  E F  G
                   /       / \
                  H       K   L
                 / \         /
                I   J       M
        */
        private BinaryTree<string> _root;
        private System.Collections.Generic.Dictionary<string, BinaryTree<string>> _nodes = new System.Collections.Generic.Dictionary<string, BinaryTree<string>>();

        #region Initialization

        [TestInitialize]
        public void Initialize()
        {
            _nodes.Clear();

            AddNode("A");

            AddNode("A", Child.Left , "B");
            AddNode("B", Child.Left , "D");
            AddNode("B", Child.Right, "E");
            AddNode("D", Child.Left , "H");
            AddNode("H", Child.Left , "I");
            AddNode("H", Child.Right, "J");

            AddNode("A", Child.Right, "C");
            AddNode("C", Child.Left , "F");
            AddNode("C", Child.Right, "G");
            AddNode("G", Child.Left , "K");
            AddNode("G", Child.Right, "L");
            AddNode("L", Child.Left , "M");
        }

        private enum Child { Left, Right }

        private void AddNode(string value)
        {
            AddNode(string.Empty, Child.Left, value);
            _root = _nodes[value];
        }

        private void AddNode(string parent, Child child, string value)
        {
            var node = new BinaryTree<string>(value);

            _nodes[value] = node;

            if(parent == string.Empty) return;

            switch(child)
            {
                case Child.Left:
                    _nodes[parent].Left = node;
                    break;

                case Child.Right:
                    _nodes[parent].Right = node;
                    break;
            }
        }

        #endregion

        [TestMethod]
        public void NoAncestorTests()
        {
            Assert.IsNull(FirstCommonAncestor.FindFCA(_root, _root, new BinaryTree<string>("X")));
        }

        [TestMethod]
        public void SearchNodeIsAncestorTests()
        {
            var searchA = _nodes["A"];
            var searchB = _nodes["B"];

            ValidateResults(searchA, _root, searchA, searchB);

            searchB = _nodes["I"];

            ValidateResults(searchA, _root, searchA, searchB);

            searchB = _nodes["M"];

            ValidateResults(searchA, _root, searchA, searchB);

            searchB = _nodes["E"];

            ValidateResults(searchA, _root, searchA, searchB);

            searchA = _nodes["L"];
            searchB = _nodes["M"];

            ValidateResults(searchA, _root, searchA, searchB);
        }

        [TestMethod]
        public void AncestorIsAncestorTests()
        {
            var expected = _nodes["A"];
            var searchA = _nodes["B"];
            var searchB = _nodes["C"];

            ValidateResults(expected, _root, searchA, searchB);

            searchB = _nodes["F"];

            ValidateResults(expected, _root, searchA, searchB);

            searchB = _nodes["L"];

            ValidateResults(expected, _root, searchA, searchB);

            expected = _nodes["B"];
            searchA = _nodes["E"];
            searchB = _nodes["H"];

            ValidateResults(expected, _root, searchA, searchB);

            searchB = _nodes["I"];

            ValidateResults(expected, _root, searchA, searchB);

            searchB = _nodes["J"];

            ValidateResults(expected, _root, searchA, searchB);

            expected = _nodes["G"];
            searchA = _nodes["K"];
            searchB = _nodes["L"];

            ValidateResults(expected, _root, searchA, searchB);

            searchB = _nodes["M"];

            ValidateResults(expected, _root, searchA, searchB);
        }

        private void ValidateResults<T>(BinaryTree<T> expected, BinaryTree<T> root, BinaryTree<T> a, BinaryTree<T> b)
        {
            var actual = FirstCommonAncestor.FindFCA(root, a, b);
            Assert.AreSame(expected, actual, $"Expected: {expected.Value}, Actual: {actual.Value}");
        }
    }
}
