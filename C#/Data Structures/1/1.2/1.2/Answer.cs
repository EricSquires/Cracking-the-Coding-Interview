using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2
{
    public static class Answer
    {
        // Naive solution

        /// <summary>
        /// Returns true if this string (<paramref name="s1"/>) is a permutation of the argument string (<paramref name="s2"/>)
        /// </summary>
        public static bool IsPermutation(this string s1, string s2)
        {
            if(s1 == s2)
            {
                return true;
            }

            // If the strings aren't of equal length, one cannot be a permutation of the other.
            if(s2.Length != s1.Length)
            {
                return false;
            }

            for(var i = 1; i < s2.Length; i++)
            {
                if(s1 == s2.Substring(i, s2.Length - i) + s2.Substring(0, i))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
