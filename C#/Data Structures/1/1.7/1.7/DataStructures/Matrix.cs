using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._7.DataStructures
{
    public class Matrix<T>
    {
        private readonly T[,] _matrix;

        public T this[int x, int y]
        {
            get { return _matrix[x,y]; }
            set { _matrix[x,y] = value; }
        }

        public int Width
        {
            get { return _matrix.GetLength(0); }
        }

        public int Height
        {
            get { return _matrix.GetLength(1); }
        }

        public Matrix(int width)
        {
            _matrix = new T[width,width];
        }

        /// <summary>
        /// Initializes the Matrix to square dimensions and fills it with the given items
        /// </summary>
        /// <param name="items">The number of items supplied *must* be a square number.</param>
        public Matrix(params T[] items)
        {
            double width = Math.Sqrt(items.Length);

            // If width isn't an integer, the pixel list isn't a square matrix
            if(width != (int)width)
            {
                throw new ArgumentException("Matrix must be square - given number of pixels invalid!", "pixels");
            }

            _matrix = new T[(int)width, (int)width];
            for(var i = 0; i < items.Length; i++)
            {
                _matrix[(int)((double)i/Width), i % Width] = items[i];
            }
        }
    }
}
