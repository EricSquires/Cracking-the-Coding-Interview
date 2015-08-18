using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._7.DataStructures;

namespace Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void ConstructorTests()
        {
            var m = new Matrix<Pixel>(
                new Pixel(1, 1, 1, 1), new Pixel(1, 1, 2, 2),
                new Pixel(2, 2, 1, 1), new Pixel(2, 2, 2, 2));

            for(var i = 0; i < m.Width; i++)
            {
                var x = (byte)(i + 1);

                for (var j = 0; j < m.Height; j++)
                {
                    var y = (byte)(j + 1);
                    var p = new Pixel(x, x, y, y);

                    Assert.AreEqual(m[i, j], p,
                        $"{m[i, j]} <> {p}\n{m}");
                }
            }
        }
    }
}
