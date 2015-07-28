using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    public class UniqueSet : IUniqueTester
    {
        private readonly HashSet<char> _set = new HashSet<char>();

        // O(n) thanks to O(1) insertion into the set
        public bool IsUnique(string txt)
        {
            if(txt == null)
            {
                return true;
            }

            _set.Clear();

            foreach(var c in txt)
            {
                if(!_set.Add(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
