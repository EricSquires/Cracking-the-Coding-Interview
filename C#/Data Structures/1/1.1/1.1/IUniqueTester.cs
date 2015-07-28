using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    public interface IUniqueTester
    {
        /// <summary>
        /// Returns true if there are no repeated characters in the string.
        /// </summary>
        bool IsUnique(string txt);
    }
}
