using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_5.Answers
{
    public class OneAwaySimple : IOneAwayChecker
    {
        public bool IsOneAway(string s1, string s2)
        {
            if (s1 == null || s2 == null)
            {
                if (s1 == s2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (Math.Abs(s1.Length - s2.Length) > 1)
            {
                return false;
            }

            string minStr = s1.Length < s2.Length ? s1 : s2;
            string maxStr = s1.Length < s2.Length ? s2 : s1;

            int idxBegin = 0;

            for (; idxBegin < minStr.Length && minStr[idxBegin] == maxStr[idxBegin]; idxBegin++) ;

            // If we got to the end of the smaller string, they're either identical or only need a letter at the end of the smaller string to match
            if (idxBegin == minStr.Length)
            {
                return true;
            }

            // Begin searching for the first change from the end of the strings, matching the end of each to one another.
            int idxEnd = 1;
            for (; maxStr.Length - idxEnd > idxBegin && minStr[minStr.Length - idxEnd] == maxStr[maxStr.Length - idxEnd]; idxEnd++) ;

            // If the two indices aren't equal, there's more than one difference in the strings
            return idxBegin == maxStr.Length - idxEnd;
        }
    }
}
