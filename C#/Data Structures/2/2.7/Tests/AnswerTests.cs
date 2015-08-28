using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2._7;
using LinkedList;

namespace Tests
{
    [TestClass]
    public class AnswerTests
    {
        private static readonly Random _RAND = new Random();

        [TestMethod]
        public void IntersectionTests()
        {
            var inputOne = new LinkedListNode<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            for (var currentInt = inputOne; currentInt.Next != null; currentInt = currentInt.Next)
            {
                for (var i = 0; i < 10; i++)
                {
                    var inputTwo = new LinkedListNode<int>(11, 12, 13, 14, 15, 16, 17, 18, 19, 20);

                    var currentRepl = inputTwo;
                    for (var j = 0; j < i; j++, currentRepl = currentRepl.Next) ;

                    if (currentRepl.Last == null)
                    {
                        inputTwo = currentInt;
                    }
                    else
                    {
                        currentRepl.Last.Next = currentInt;
                    }

                    Assert.AreSame(currentInt, Answer.GetIntersection(inputOne, inputTwo));
                }
            }
        }

        [TestMethod]
        public void NonIntersectionTests()
        {
            var inputOne = new LinkedListNode<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var inputTwo = new LinkedListNode<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            Assert.IsNull(Answer.GetIntersection(inputOne, inputTwo));

            inputTwo = new LinkedListNode<int>(11);

            Assert.IsNull(Answer.GetIntersection(inputOne, inputTwo));
        }

        [TestMethod]
        public void IntersectionTestsNoSet()
        {
            var inputOne = new LinkedListNode<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            for (var currentInt = inputOne; currentInt.Next != null; currentInt = currentInt.Next)
            {
                for (var i = 0; i < 10; i++)
                {
                    var inputTwo = new LinkedListNode<int>(11, 12, 13, 14, 15, 16, 17, 18, 19, 20);

                    var currentRepl = inputTwo;
                    for (var j = 0; j < i; j++, currentRepl = currentRepl.Next) ;

                    if (currentRepl.Last == null)
                    {
                        inputTwo = currentInt;
                    }
                    else
                    {
                        currentRepl.Last.Next = currentInt;
                    }

                    Assert.AreSame(currentInt, Answer.GetIntersectionNoSet(inputOne, inputTwo));
                }
            }
        }

        [TestMethod]
        public void NonIntersectionTestsNoSet()
        {
            var inputOne = new LinkedListNode<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var inputTwo = new LinkedListNode<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            Assert.IsNull(Answer.GetIntersectionNoSet(inputOne, inputTwo));

            inputTwo = new LinkedListNode<int>(11);

            Assert.IsNull(Answer.GetIntersectionNoSet(inputOne, inputTwo));
        }
    }
}
