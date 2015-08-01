using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4.Answers
{
    public class PalPermSort : IPalindromePermutationChecker
    {
        public bool IsPalindromePermutation(string txt)
        {
            if(string.IsNullOrWhiteSpace(txt))
            {
                return true;
            }

            char[] c = txt.ToArray();
            Array.Sort(c);

            char? currentChar = null;
            int count = 0;
            bool hasOdd = false;

            for(var i = 0; i < c.Length; i++, count++)
            {
                if(currentChar != c[i])
                {
                    if(count > 0 && count % 2 == 1)
                    {
                        if(hasOdd)
                        {
                            return false;
                        }

                        hasOdd = true;
                    }

                    currentChar = c[i];
                    count = 0;
                }
            }

            return true;
        }
    }
}
