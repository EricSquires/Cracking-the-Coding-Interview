using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._7.DataStructures
{
    public struct Pixel
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; }

        public Pixel(byte r, byte g, byte b, byte a)
        {
            Red = r;
            Green = g;
            Blue = b;
            Alpha = a;
        }
    }
}