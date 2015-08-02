using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_5.Answers
{
    public interface IOneAwayChecker
    {
        /// <summary>
        /// Tests whether the two strings are one edit or less away from each other
        /// </summary>
        /// <returns>True if one edit or less separates the strings, false otherwise.</returns>
        bool IsOneAway(string s1, string s2);
    }
}
