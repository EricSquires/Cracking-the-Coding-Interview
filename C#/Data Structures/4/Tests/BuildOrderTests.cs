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
        }
    }
}
