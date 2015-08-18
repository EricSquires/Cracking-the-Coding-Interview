using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._7.DataStructures
{
    public struct Pixel : IEquatable<Pixel>
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

        public override bool Equals(object obj)
        {
            return Equals((Pixel)obj);
        }

        public override int GetHashCode()
        {
            int hash = 13;

            hash = (hash * 7) + Red.GetHashCode();
            hash = (hash * 7) + Green.GetHashCode();
            hash = (hash * 7) + Blue.GetHashCode();
            hash = (hash * 7) + Alpha.GetHashCode();

            return hash;
        }

        public bool Equals(Pixel other)
        {
            return other.Red == Red && other.Green == Green && other.Blue == Blue && other.Alpha == Alpha;
        }
    }
}