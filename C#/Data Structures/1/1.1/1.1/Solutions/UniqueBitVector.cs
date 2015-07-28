using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1.Solutions
{
    public class UniqueBitVector : IUniqueTester
    {
        public bool IsUnique(string txt)
        {
            if(txt == null)
            {
                return true;
            }

            var vector = new BitVector();

            foreach(var c in txt)
            {
                if(!vector.Add(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
