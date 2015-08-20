using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._7.Answers;
using _1._7.DataStructures;

namespace Tests
{
    [TestClass]
    public class RotatorInPlaceTests
    {
        private bool ImagesEqual(byte[,][] a, byte[,][] b)
        {
            for(var i = 0; i < a.GetLength(0); i++)
            {
                for(var j = 0; j < a.GetLength(1); j++)
                {
                    for(var k = 0; k < a[i,j].Length; k++)
                    {
                        if(a[i,j][k] != b[i,j][k])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        [TestMethod]
        public void RotateOne()
        {
            var image = new byte[,][]
                {
                    { new byte[] { 1, 2, 3, 4 } }
                };
            var expected = new byte[,][]
                {
                    { new byte[] { 1, 2, 3, 4 } }
                };

            RotatorInPlace.RotateCW(image);
            Assert.IsTrue(ImagesEqual(expected, image));

            image = new byte[,][]
                {
                    { new byte[] { 1, 2, 3, 4 } }
                };
            expected = new byte[,][]
                {
                { new byte[] { 1, 2, 3, 4 } }
                };

            RotatorInPlace.RotateCCW(image);
            Assert.IsTrue(ImagesEqual(expected, image));
        }

        [TestMethod]
        public void RotateTwo()
        {
            var image = new byte[,][]
                {
                    { new byte[] { 1, 1, 1, 1 }, new byte[] { 1, 1, 2, 2, } },
                    { new byte[] { 2, 2, 1, 1 }, new byte[] { 2, 2, 2, 2, } }
                };
            var expected = new byte[,][]
                {
                    { new byte[] { 2, 2, 1, 1 }, new byte[] { 1, 1, 1, 1, } },
                    { new byte[] { 2, 2, 2, 2 }, new byte[] { 1, 1, 2, 2, } }
                };

            RotatorInPlace.RotateCW(image);
            Assert.IsTrue(ImagesEqual(expected, image));

            image = new byte[,][]
                {
                    { new byte[] { 1, 1, 1, 1 }, new byte[] { 1, 1, 2, 2, } },
                    { new byte[] { 2, 2, 1, 1 }, new byte[] { 2, 2, 2, 2, } }
                };
            expected = new byte[,][]
                {
                    { new byte[] { 1, 1, 2, 2 }, new byte[] { 2, 2, 2, 2, } },
                    { new byte[] { 1, 1, 1, 1 }, new byte[] { 2, 2, 1, 1, } }
                };

            RotatorInPlace.RotateCW(image);
            Assert.IsTrue(ImagesEqual(expected, image));
        }

        [TestMethod]
        public void RotateThree()
        {
            var image = new byte[,][]
                {
                    { new byte[] { 1, 1, 1, 1 }, new byte[] { 1, 1, 2, 2, }, new byte[] { 1, 1, 3, 3 } },
                    { new byte[] { 2, 2, 1, 1 }, new byte[] { 2, 2, 2, 2, }, new byte[] { 2, 2, 3, 3 } },
                    { new byte[] { 3, 3, 1, 1 }, new byte[] { 3, 3, 2, 2, }, new byte[] { 3, 3, 3, 3 } }
                };
            var expected = new byte[,][]
                {
                    { new byte[] { 3, 3, 1, 1 }, new byte[] { 2, 2, 1, 1, }, new byte[] { 1, 1, 1, 1 } },
                    { new byte[] { 3, 3, 2, 2 }, new byte[] { 2, 2, 2, 2, }, new byte[] { 1, 1, 2, 2 } },
                    { new byte[] { 3, 3, 3, 3 }, new byte[] { 2, 2, 3, 3, }, new byte[] { 1, 1, 3, 3 } }
                };

            RotatorInPlace.RotateCW(image);
            Assert.IsTrue(ImagesEqual(expected, image));

            image = new byte[,][]
                {
                    { new byte[] { 1, 1, 1, 1 }, new byte[] { 1, 1, 2, 2, }, new byte[] { 1, 1, 3, 3 } },
                    { new byte[] { 2, 2, 1, 1 }, new byte[] { 2, 2, 2, 2, }, new byte[] { 2, 2, 3, 3 } },
                    { new byte[] { 3, 3, 1, 1 }, new byte[] { 3, 3, 2, 2, }, new byte[] { 3, 3, 3, 3 } }
                };
            expected = new byte[,][]
                {
                    { new byte[] { 1, 1, 3, 3 }, new byte[] { 2, 2, 3, 3, }, new byte[] { 3, 3, 3, 3 } },
                    { new byte[] { 1, 1, 2, 2 }, new byte[] { 2, 2, 2, 2, }, new byte[] { 3, 3, 2, 2 } },
                    { new byte[] { 1, 1, 1, 1 }, new byte[] { 2, 2, 1, 1, }, new byte[] { 3, 3, 1, 1 } }
                };

            RotatorInPlace.RotateCW(image);
            Assert.IsTrue(ImagesEqual(expected, image));
        }
    }
}
