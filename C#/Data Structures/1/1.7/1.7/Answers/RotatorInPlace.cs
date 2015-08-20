using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._7.Answers
{
    public static class RotatorInPlace
    {
        /// <summary>
        /// Rotates the given image (represented as a multidimensional array) clockwise.
        /// </summary>
        /// <param name="input">An image to be rotated</param>
        public static void RotateCW(byte[,][] image)
        {
            var width = image.GetLength(0);

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    Swap(image, j, i, i, width - (j + 1));
                }
            }
        }
        public static void RotateCCW(byte[,][] image)
        {
            var width = image.GetLength(0);

            for (var i = 0; i < width; i++)
            {
                for (var j = width - 1; j >= 0; j--)
                {
                    Swap(image, i, width - (j + 1), j, i);
                }
            }
        }

        private static void Swap(byte[,][] image, int x1, int y1, int x2, int y2)
        {
            if(x1 == x2 && y1 == y2)
            {
                return;
            }

            for(var i = 0; i < image[x1, y1].Length; i++)
            {
                image[x1, y1][i] = (byte)(image[x1, y1][i] ^ image[x2, y2][i]);
                image[x2, y2][i] = (byte)(image[x1, y1][i] ^ image[x2, y2][i]);
                image[x1, y1][i] = (byte)(image[x1, y1][i] ^ image[x2, y2][i]);
            }
        }
    }
}
