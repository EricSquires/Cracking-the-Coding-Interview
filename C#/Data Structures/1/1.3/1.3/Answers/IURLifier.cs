using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3
{
    public interface IURLifier
    {
        /// <summary>
        /// Despite its name, this function only replaces spaces with %20.
        /// </summary>
        string URLify(string txt);
    }
}
