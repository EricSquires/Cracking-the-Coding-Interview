using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _4;

namespace Tests
{
    [TestClass]
    public class RouteBetweenTests
    {
        [TestMethod]
        public void NoRouteTests()
        {
            var source = new RouteBetween<int>(1);
            var dest = new RouteBetween<int>(1);

            Assert.IsFalse(source.HasRoute(dest));

            var a = new RouteBetween<int>(1);
            var b = new RouteBetween<int>(1);
            var c = new RouteBetween<int>(1);

            source.ConnectTo(a);
            source.ConnectTo(b);
            source.ConnectTo(c);

            Assert.IsFalse(source.HasRoute(dest));
        }

        [TestMethod]
        public void HasRouteTest1()
        {
            var source = new RouteBetween<int>(1);
            var dest = new RouteBetween<int>(1);

            var a = new RouteBetween<int>(1);
            var b = new RouteBetween<int>(1);
            var c = new RouteBetween<int>(1);
            var d = new RouteBetween<int>(1);
            var e = new RouteBetween<int>(1);
            var f = new RouteBetween<int>(1);
            var g = new RouteBetween<int>(1);

            /*
                d - e - f
                |       |
                S - a - b - c - D
                        |
                        g
            */

            d.ConnectTo(source);
            d.ConnectTo(e);

            e.ConnectTo(f);

            f.ConnectTo(b);

            source.ConnectTo(a);

            a.ConnectTo(b);

            b.ConnectTo(c);
            b.ConnectTo(g);

            c.ConnectTo(dest);

            Assert.IsTrue(source.HasRoute(dest));
        }

        [TestMethod]
        public void HasRouteTest2()
        {
            var source = new RouteBetween<int>(1);
            var dest = new RouteBetween<int>(1);

            var a = new RouteBetween<int>(1);
            var b = new RouteBetween<int>(1);
            var c = new RouteBetween<int>(1);
            var d = new RouteBetween<int>(1);
            var e = new RouteBetween<int>(1);
            var f = new RouteBetween<int>(1);
            var g = new RouteBetween<int>(1);

            /*
                                f
                                |
                S - a - b - c - D - d - e
                                |
                                g
            */

            source.ConnectTo(a);

            a.ConnectTo(b);

            b.ConnectTo(c);

            c.ConnectTo(dest);

            dest.ConnectTo(f);
            dest.ConnectTo(g);
            dest.ConnectTo(d);

            d.ConnectTo(e);

            Assert.IsTrue(source.HasRoute(dest));
        }

        [TestMethod]
        public void HasRouteTest3()
        {
            var source = new RouteBetween<int>(1);
            var dest = new RouteBetween<int>(1);

            var a = new RouteBetween<int>(1);
            var b = new RouteBetween<int>(1);
            var c = new RouteBetween<int>(1);
            var d = new RouteBetween<int>(1);
            var e = new RouteBetween<int>(1);
            var f = new RouteBetween<int>(1);
            var g = new RouteBetween<int>(1);

            /*
                                f - g
                                |   |
                S - a - b - c - D - d - e
            */

            source.ConnectTo(a);

            a.ConnectTo(b);

            b.ConnectTo(c);

            c.ConnectTo(dest);

            dest.ConnectTo(f);
            dest.ConnectTo(d);

            f.ConnectTo(g);

            g.ConnectTo(d);

            d.ConnectTo(e);

            Assert.IsTrue(source.HasRoute(dest));
        }
    }
}
