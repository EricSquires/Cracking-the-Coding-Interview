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
        public static bool IsUnique(this string txt)
        {
            bool ret = true;

            for(var i = 0; ret && i < txt.Length; i++)
            {
                for(var j = i; ret && j < txt.Length; j++)
                {
                    ret = txt[0] != txt[1];
                }
            }

            return ret;
        }
    }
}
