using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1.Solutions
{
    /// <summary>
    /// A simple implementation of a bit vector that can handle characters with whose integer values are 0 - 127
    /// </summary>
    public class BitVector
    {
        // Explicitly call for UInt64 rather than my usual ulong since we'll be doing bit manipulation
        // Use high/low so we can support up to character code 127 which should cover the typical characters
        private UInt64 _low = 0;
        private UInt64 _high = 0;

        public bool Add(char c)
        {
            bool ret;
            int val = c;

            if (val >= 128)
            {
                throw new ArgumentOutOfRangeException("c", "Character code must be less than 128");
            }

            if (val >= 64)
            {
                ret = Add(ref _high, val - 64);
            }
            else
            {
                ret = Add(ref _low, val);
            }

            return ret;
        }

        private bool Add(ref UInt64 vector, int value)
        {
            UInt64 oldVal = vector;
            vector |= (UInt64)1 << value;
            return oldVal != vector;
        }
    }
}