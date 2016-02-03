using Microsoft.VisualStudio.TestTools.UnitTesting;
using _4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class CheckSubtreeTests
    {
        [TestMethod()]
        public void IsSubtreeTest()
        {
            var a = new CheckSubtree<int>(1);
            var b = a.Clone();

            Assert.IsTrue(a.IsSubtree(b));
        }
    }
}