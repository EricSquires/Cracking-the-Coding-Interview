using _1._7.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._7.Answers
{
    public static class RotateSimple
    {
        public static Matrix<Pixel> Rotate(Matrix<Pixel> input)
        {
            var output = new Matrix<Pixel>(input.Width);

            for(var i = 0; i < input.Width; i++)
            {
                for(var j = 0; j < input.Width; j++)
                {
                    output[j,output.Width - i] = input[i,j];
                }
            }

            return output;
        }
    }
}
