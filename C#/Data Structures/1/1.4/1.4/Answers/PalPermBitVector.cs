using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4.Answers
{
    public class PalPermBitVector : IPalindromePermutationChecker
    {
        public bool IsPalindromePermutation(string txt)
        {
            if(string.IsNullOrWhiteSpace(txt))
            {
                return true;
            }

            var counts = new int[128];

            foreach(var c in txt)
            {
                counts[c]++;
            }

            bool hasOdd = false;

            for(var i = 0; i < counts.Length; i++)
            {
                if(counts[i] != 0 && counts[i] % 2 == 1)
                {
                    if(hasOdd)
                    {
                        return false;
                    }

                    hasOdd = true;
                }
            }

            return true;
        }
    }
}
