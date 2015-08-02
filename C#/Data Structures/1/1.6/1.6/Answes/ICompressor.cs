using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._6.Answes
{
    public interface ICompressor
    {
        /// <summary>
        /// Compresses the given string.
        /// </summary>
        /// <param name="txt">The string to compress.</param>
        /// <returns>The string after compression.</returns>
        string Compress(string txt);
    }
}
