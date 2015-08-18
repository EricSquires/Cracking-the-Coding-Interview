﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._7.Answers;
using _1._7.DataStructures;

namespace Tests
{
    [TestClass]
    public class TestBase<T> where T : IRotator, new()
    {
        private static readonly Matrix<Pixel>[][] _TEST_DATA_ONE =
            {
                new[] { new Matrix<Pixel>(new Pixel(1,2,3,4)), new Matrix<Pixel>(new Pixel(1,2,3,4)) }
            };
        private static readonly Matrix<Pixel>[][] _TEST_DATA_TWO =
            {
                new[] { new Matrix<Pixel>(new Pixel(1,1,1,1), new Pixel(1,1,2,2), new Pixel(2,2,1,1), new Pixel(2,2,2,2)), new Matrix<Pixel>(new Pixel(1,2,3,4)) }
            };

        protected T TestObject { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            TestObject = new T();
        }

        [TestMethod]
        public void RotateOne()
        {
            Assert.AreEqual(TestObject.RotateCW(new Matrix<Pixel>(new Pixel(1, 2, 3, 4))), new Matrix<Pixel>(new Pixel(1, 2, 3, 4)));
            Assert.AreEqual(TestObject.RotateCCW(new Matrix<Pixel>(new Pixel(1, 2, 3, 4))), new Matrix<Pixel>(new Pixel(1, 2, 3, 4)));
        }

        [TestMethod]
        public void RotateTwo()
        {
            var input = new Matrix<Pixel>(
                new Pixel(1, 1, 1, 1), new Pixel(1, 1, 2, 2),
                new Pixel(2, 2, 1, 1), new Pixel(2, 2, 2, 2));

            var outputCW = new Matrix<Pixel>(
                new Pixel(2, 2, 1, 1), new Pixel(1, 1, 1, 1),
                new Pixel(2, 2, 2, 2), new Pixel(1, 1, 2, 2));

            var outputCCW = new Matrix<Pixel>(
                new Pixel(1, 1, 2, 2), new Pixel(2, 2, 2, 2),
                new Pixel(1, 1, 1, 1), new Pixel(2, 2, 1, 1));

            Assert.AreEqual(TestObject.RotateCW(input), outputCW);
            Assert.AreEqual(TestObject.RotateCW(input), outputCCW);
        }

        [TestMethod]
        public void RotateThree()
        {
            var input = new Matrix<Pixel>(
                new Pixel(1, 1, 1, 1), new Pixel(1, 1, 2, 2), new Pixel(1, 1, 3, 3),
                new Pixel(2, 2, 1, 1), new Pixel(2, 2, 2, 2), new Pixel(2, 2, 3, 3),
                new Pixel(3, 3, 1, 1), new Pixel(3, 3, 2, 2), new Pixel(3, 3, 3, 3));

            var outputCW = new Matrix<Pixel>(
                new Pixel(3, 3, 1, 1), new Pixel(2, 2, 1, 1), new Pixel(1, 1, 1, 1),
                new Pixel(3, 3, 2, 2), new Pixel(2, 2, 2, 2), new Pixel(1, 1, 2, 2),
                new Pixel(3, 3, 3, 3), new Pixel(2, 2, 3, 3), new Pixel(1, 1, 3, 3));

            var outputCCW = new Matrix<Pixel>(
                new Pixel(1, 1, 3, 3), new Pixel(2, 2, 3, 3), new Pixel(3, 3, 3, 3),
                new Pixel(1, 1, 2, 2), new Pixel(2, 2, 2, 2), new Pixel(3, 3, 2, 2),
                new Pixel(1, 1, 1, 1), new Pixel(2, 2, 1, 1), new Pixel(3, 3, 1, 1));

            Assert.AreEqual(TestObject.RotateCW(input), outputCW);
            Assert.AreEqual(TestObject.RotateCW(input), outputCCW);
        }
    }
}
