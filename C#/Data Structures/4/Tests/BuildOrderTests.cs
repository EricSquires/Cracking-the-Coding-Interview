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
    }
}
