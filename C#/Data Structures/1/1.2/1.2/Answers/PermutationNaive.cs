using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2.Answers
{
    public class PermutationNaive : IPermutationChecker
    {
        public bool IsPermutation(string s1, string s2)
        {
            if(s1 == null || s2 == null)
            {
                return s1 == s2;
            }

            // If the strings aren't of equal length, one cannot be a permutation of the other.
            if(s2.Length != s1.Length)
            {
                return false;
            }

            int[] count1 = CountChars(s1);
            int[] count2 = CountChars(s2);

            for(var i = 0; i < count1.Length; i++)
            {
                if(count1[i] != count2[i])
                {
                    return false;
                }
            }

            return true;
        }

        private int[] CountChars(string txt)
        {
            var ret = new int[128];

            foreach(var c in txt)
            {
                ret[c]++;
            }

            return ret;
        }
    }
}
