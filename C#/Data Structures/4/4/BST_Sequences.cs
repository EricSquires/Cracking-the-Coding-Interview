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

            foreach(var lp in leftPerms)
            {
                foreach(var rp in rightPerms)
                {
                    var perms = GetPermutations(lp.ToList(), rp.ToList());

                    foreach(var perm in perms)
                    {
                        var lst = new List<T>();
                        lst.Add(root.Value);
                        lst.AddRange(perm);

                        ret.Add(lst);
                    }
                }
            }

            if(ret.Count == 0)
            {
                ret.Add(new[] { root.Value });
            }

            //var depthLists = DepthsLists.GetDepthLists(root);

            //foreach(var dList in depthLists)
            //{
            //    if(ret.Count == 0)
            //    {
            //        ret.AddLast(new LinkedList<T>(dList.Select(n => n.Value)));
            //    }
            //    else
            //    {
            //        ret = BuildNewList(dList, ret);
            //    }
            //}

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

        private static Tuple<IEnumerable<IEnumerable<T>>, IEnumerable<IEnumerable<T>>> GetChildSequences<T>(BST<T> root) where T : IComparable<T>
        {
            IEnumerable<IEnumerable<T>> leftSeq = null;
            IEnumerable<IEnumerable<T>> rightSeq = null;

            if(root.Left != null)
            {
                leftSeq = GetSequences(root.Left);
            }

            if(root.Right != null)
            {
                rightSeq = GetSequences(root.Right);
            }

            return Tuple.Create(leftSeq, rightSeq);
        }

        private static LinkedList<LinkedList<T>> BuildNewList<T>(LinkedList<BinaryTree<T>> depthLst, LinkedList<LinkedList<T>> currentLst)
        {
            if(depthLst.Count == 0)
            {
                return currentLst;
            }

            var ret = new LinkedList<LinkedList<T>>();

            foreach (var newPermutation in GetPermutations(depthLst))
            {
                foreach (var existingPermutation in currentLst)
                {
                    var newLst = new LinkedList<T>(existingPermutation);
                    ret.AddLast(newLst.AddRange(newPermutation.Select(n => n.Value)));
                }
            }

            return ret;
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(LinkedList<T> lst)
        {
            if(lst.Count == 0)
            {
                yield break;
            }

            var start = lst.First;
            do
            {
                yield return lst.ToArray();

                var fst = lst.First;
                lst.RemoveFirst();
                lst.AddLast(fst);
            }
            while(lst.First != start);
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
