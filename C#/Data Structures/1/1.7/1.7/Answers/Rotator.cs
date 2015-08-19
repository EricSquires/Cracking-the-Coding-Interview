using _1._7.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._7.Answers
{
    public class Rotator
    {
        /// <summary>
        /// Rotates the given <see cref="Matrix{T}"/> clockwise.
        /// </summary>
        /// <param name="input">A <see cref="Matrix{T}"/> to be rotated</param>
        /// <returns>The <paramref name="input"/> <see cref="Matrix{T}"/> rotated clockwise.</returns>
        public Matrix<Pixel> RotateCW(Matrix<Pixel> input)
        {
            var output = new Matrix<Pixel>(input.Width);

            for (var i = 0; i < input.Width; i++)
            {
                for (var j = 0; j < input.Width; j++)
                {
                    output[j, i] = input[i, input.Width - (j + 1)];
                }
            }

            return output;
        }

        /// <summary>
        /// Rotates the given <see cref="Matrix{T}"/> counter-clockwise.
        /// </summary>
        /// <param name="input">A <see cref="Matrix{T}"/> to be rotated</param>
        /// <returns>The <paramref name="input"/> <see cref="Matrix{T}"/> rotated counter-clockwise.</returns>
        public Matrix<Pixel> RotateCCW(Matrix<Pixel> input)
        {
            var output = new Matrix<Pixel>(input.Width);

            for (var i = 0; i < input.Width; i++)
            {
                for (var j = input.Width - 1; j >= 0; j--)
                {
                    output[i, input.Width - (j + 1)] = input[j, i];
                }
            }

            return output;
        }
    }
}
