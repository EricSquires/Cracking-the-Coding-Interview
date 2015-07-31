using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2.Answers
{
    public class PermutationSort : IPermutationChecker
    {
        public bool IsPermutation(string s1, string s2)
        {
            if (s1 == null || s2 == null)
            {
                return s1 == s2;
            }

            // If the strings aren't of equal length, one cannot be a permutation of the other.
            if (s2.Length != s1.Length)
            {
                return false;
            }

            char[] c1 = s1.ToArray();
            char[] c2 = s2.ToArray();

            Array.Sort(c1);
            Array.Sort(c2);

            for(var i = 0; i < c1.Length; i++)
            {
                if(c1[i] != c2[i])
                {
                    return false;
                }
            }

            return true;
        }

        private Dictionary<string, int> GenerateSet(string txt)
        {
            var set = new Dictionary<string, int>();

            for(var i = 0; i < txt.Length; i++)
            {
                string key = "" + txt[i] + txt[(i + 1) % txt.Length];

                if(set.ContainsKey(key))
                {
                    set[key]++;
                }
                else
                {
                    set[key] = 1;
                }
            }

            return set;
        }

        private bool SetsEqual(Dictionary<string, int> s1, Dictionary<string, int> s2)
        {
            if(s1.Keys.Count != s2.Keys.Count)
            {
                return false;
            }

            foreach(var kvp in s1)
            {
                int val;
                if(!s2.TryGetValue(kvp.Key, out val) || kvp.Value != val)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
