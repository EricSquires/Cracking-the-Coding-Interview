using _1._7.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._7.Answers
{
    public interface IRotator
    {
        /// <summary>
        /// Rotates the given <see cref="Matrix{T}"/> clockwise.
        /// </summary>
        /// <param name="input">A <see cref="Matrix{T}"/> to be rotated</param>
        /// <returns>The <paramref name="input"/> <see cref="Matrix{T}"/> rotated clockwise.</returns>
        Matrix<Pixel> RotateCW(Matrix<Pixel> input);
        /// <summary>
        /// Rotates the given <see cref="Matrix{T}"/> counter-clockwise.
        /// </summary>
        /// <param name="input">A <see cref="Matrix{T}"/> to be rotated</param>
        /// <returns>The <paramref name="input"/> <see cref="Matrix{T}"/> rotated counter-clockwise.</returns>
        Matrix<Pixel> RotateCCW(Matrix<Pixel> input);
    }
}
