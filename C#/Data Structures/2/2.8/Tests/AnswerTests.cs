using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2._8;
using LinkedList;

namespace Tests
{
    [TestClass]
    public class AnswerTests
    {
        [TestMethod]
        public void TrueTests()
        {
            for(var i = 0; i < 10; i++)
            {
                var input = new LinkedListNode<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

                var loopStart = input;
                for(var j = 0; j < i; j++, loopStart = loopStart.Next);

                var last = loopStart;
                while(last.Next != null)
                {
                    last = last.Next;
                }

                last.Next = loopStart;

                Assert.AreSame(loopStart, Answer.GetLoopHead(input), $"Failed when loopStart = {loopStart.Value}");
            }
        }

        [TestMethod]
        public void FalseTests()
        {
            var input = new LinkedListNode<int>(1);

            Assert.IsNull(Answer.GetLoopHead(input));

            input = new LinkedListNode<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            Assert.IsNull(Answer.GetLoopHead(input));
        }
    }
}
