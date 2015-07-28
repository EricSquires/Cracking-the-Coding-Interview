using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1.Solutions
{
    public class UniqueNaive : IUniqueTester
    {
        // O(n^2) solution
        public bool IsUnique(string txt)
        {
            bool ret = true;

            if (txt != null)
            {
                for (var i = 0; ret && i < txt.Length; i++)
                {
                    for (var j = i + 1; ret && j < txt.Length; j++)
                    {
                        ret = txt[i] != txt[j];
                    }
                }
            }

            return ret;
        }
    }
}
