using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    public static class Answer
    {
        // Naive solution

        /// <summary>
        /// Returns true if there are no repeated characters in the string.
        /// </summary>
        public static bool IsUnique(this string txt)
        {
            bool ret = true;

            if(txt != null)
            {
                for(var i = 0; ret && i < txt.Length; i++)
                {
                    for(var j = i + 1; ret && j < txt.Length; j++)
                    {
                        ret = txt[i] != txt[j];
                    }
                }
            }

            return ret;
        }
    }
}
