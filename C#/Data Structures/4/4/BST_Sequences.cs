using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public static class BST_Sequences
    {
        public static IEnumerable<IEnumerable<T>> GetSequences<T>(BST<T> root) where T : IComparable<T>
        {
            var ret = new List<IEnumerable<T>>();

            if(root == null)
            {
                return ret;
            }

            var leftPerms = GetSequences(root.Left);
            var rightPerms = GetSequences(root.Right);

            if (leftPerms.Count() == 0)
            {
                foreach (var rp in rightPerms)
                {
                    var lst = new List<T>();
                    lst.Add(root.Value);
                    lst.AddRange(rp);

                    ret.Add(lst);
                }
            }
            else if (rightPerms.Count() == 0)
            {
                foreach (var lp in leftPerms)
                {
                    var lst = new List<T>();
                    lst.Add(root.Value);
                    lst.AddRange(lp);

                    ret.Add(lst);
                }
            }
            else
            {
                foreach (var lp in leftPerms)
                {
                    foreach (var rp in rightPerms)
                    {
                        var perms = GetPermutations(lp.ToList(), rp.ToList());

                        foreach (var perm in perms)
                        {
                            var lst = new List<T>();
                            lst.Add(root.Value);
                            lst.AddRange(perm);

                            ret.Add(lst);
                        }
                    }
                }
            }

            if(ret.Count == 0)
            {
                ret.Add(new[] { root.Value });
            }

            return ret;
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IList<T> a, IList<T> b)
        {
            var ret = new List<IEnumerable<T>>();

            if((a == null || a.Count == 0) && (b == null || b.Count == 0))
            {
                return ret;
            }

            ret.Add(new LinkedList<T>(a).AddRange(b));

            for(var i = a.Count - 1; i >= 0; i--)
            {
                for(var j = 1; j <= b.Count; j++)
                {
                    foreach(var perm in GetPermutations(a.Skip(i).ToList(), b.Skip(j).ToList()))
                    {
                        var lst = a.Take(i).ToList();
                        lst.AddRange(b.Take(j));
                        lst.AddRange(perm);

                        if(!ListsAreEqual(ret.Last().ToList(), lst))
                        {
                            ret.Add(lst);
                        }
                    }
                }
            }

            return ret;
        }

        private static bool ListsAreEqual<T>(IList<T> a, IList<T> b)
        {
            if(a.Count != b.Count)
            {
                return false;
            }

            for(var i = 0; i < a.Count; i++)
            {
                if(!a[i].Equals(b[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static LinkedList<T> AddRange<T>(this LinkedList<T> lst, IEnumerable<T> rng)
        {
            foreach(var item in rng)
            {
                lst.AddLast(item);
            }

            return lst;
        }
    }
}
