using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _4;
using System.Linq;

namespace Tests
{
    /// <summary>
    /// Summary description for BuildOrderTests
    /// </summary>
    [TestClass]
    public class BuildOrderTests
    {
        private List<int> _input = new List<int>(Enumerable.Range(0, 100));

        [TestMethod]
        public void NoDependenciesTests()
        {
            var bo = new BuildOrder<int>(_input, new List<Tuple<int, int>>());
            Assert.IsTrue(bo.CanBuild());
        }

        [TestMethod]
        public void CycleTests()
        {
            var dep = new Tuple<int, int>[]
            {
                Tuple.Create(_input[1], _input[0]),
                Tuple.Create(_input[2], _input[1]),
                Tuple.Create(_input[3], _input[2]),
                Tuple.Create(_input[4], _input[3]),
                Tuple.Create(_input[5], _input[4]),
                Tuple.Create(_input[1], _input[5])
            };

            var bo = new BuildOrder<int>(_input, dep);

            Assert.IsFalse(bo.CanBuild());

            dep = new Tuple<int, int>[]
            {
                Tuple.Create(_input[0], _input[1]),
                Tuple.Create(_input[1], _input[0])
            };

            Assert.IsFalse(bo.CanBuild());
        }

        [TestMethod]
        public void BuildTests()
        {
            var dep = new Tuple<int, int>[]
            {
                Tuple.Create(_input[10], _input[0]),
                Tuple.Create(_input[20], _input[10]),
                Tuple.Create(_input[30], _input[20]),
                Tuple.Create(_input[9], _input[8]),
                Tuple.Create(_input[10], _input[9]),
                Tuple.Create(_input[11], _input[10]),
                Tuple.Create(_input[12], _input[11]),
                Tuple.Create(_input[51], _input[50]),
                Tuple.Create(_input[52], _input[50]),
                Tuple.Create(_input[53], _input[50]),
                Tuple.Create(_input[54], _input[50]),
                Tuple.Create(_input[55], _input[50]),
                Tuple.Create(_input[56], _input[50]),
                Tuple.Create(_input[57], _input[50]),
                Tuple.Create(_input[58], _input[50]),
                Tuple.Create(_input[59], _input[50]),
                Tuple.Create(_input[60], _input[50]),
                Tuple.Create(_input[50], _input[60]),
                Tuple.Create(_input[61], _input[60]),
                Tuple.Create(_input[61], _input[50]),
            };

            var bo = new BuildOrder<int>(_input, dep);

            Assert.IsTrue(bo.CanBuild());

            foreach(var p in bo.GetBuildOrder())
            {
                Console.Write(p + " -> ");
            }

            dep = new Tuple<int, int>[]
                {
                    Tuple.Create(1, 0),
                    Tuple.Create(2, 0),
                    Tuple.Create(4, 2),
                    Tuple.Create(3, 1)
                };

            bo = new BuildOrder<int>(new[] { 0, 1, 3, 2, 4 }, dep);

            var expected = new int[] { 0, 1, 2, 4, 3 };

            Assert.IsTrue(VerifyOutput(expected, bo.GetBuildOrder().ToArray()));

            var bookDep = new Tuple<char, char>[]
                {
                    Tuple.Create('d', 'a'),
                    Tuple.Create('b', 'f'),
                    Tuple.Create('d', 'b'),
                    Tuple.Create('a', 'f'),
                    Tuple.Create('c', 'd')
                };

            var bookBo = new BuildOrder<char>(new[] { 'a', 'b', 'c', 'd', 'e', 'f' }, bookDep);
            var bookExpected = new[] { 'f', 'e', 'a', 'b', 'd', 'c' };
            var bookActual = bookBo.GetBuildOrder().ToArray();

            Assert.IsTrue(VerifyOutput(bookExpected, bookActual), $"Expected: {string.Join(", ", bookExpected)}\nActual: {string.Join(", ", bookActual)}");
        }

        private bool VerifyOutput<T>(ICollection<T> expected, ICollection<T> actual) where T : IEquatable<T>
        {
            if(expected.Count != actual.Count)
            {
                return false;
            }

            for(var i = 0; i < expected.Count; i++)
            {
                if(expected.ElementAt(i).Equals(actual.ElementAt(i)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
