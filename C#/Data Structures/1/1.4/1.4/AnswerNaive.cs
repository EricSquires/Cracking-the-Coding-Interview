using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4
{
    public class AnswerNaive : IAnswer
    {
        public bool IsPalindromePermutation(string txt)
        {
            if (IsPalindrome(txt))
            {
                return true;
            }

            for (var i = 1; i < txt.Length; i++)
            {
                if (IsPalindrome(txt.Substring(i, txt.Length - i) + txt.Substring(0, i)))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsPalindrome(string txt)
        {
            for (var i = 0; i < txt.Length / 2; i++)
            {
                if (txt[i] != txt[txt.Length - (i + 1)])
                {
                    return false;
                }
            }

            return true;
        }
    }
}