using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    public class UniqueSet : IUniqueTester
    {
        // O(n) thanks to O(1) insertion into the set
        public bool IsUnique(string txt)
        {
            if(txt == null)
            {
                return true;
            }

            var set = new HashSet<char>();

            foreach(var c in txt)
            {
                if(!set.Add(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
