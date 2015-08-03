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
    }
}
