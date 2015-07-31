using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2.Answers
{
    public class PermutationNaive : IPermutationChecker
    {
        // Naive solution
        public bool IsPermutation(string s1, string s2)
        {
            if(s1 == s2)
            {
                return true;
            }

            // If the strings aren't of equal length, one cannot be a permutation of the other.
            // Use the new null propagation operator here to handle cases where one of the strings is null. The prior equality check
            // will handle the case where both are null so null propagation operator means one being null triggers this false return.
            if(s2?.Length != s1?.Length)
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
