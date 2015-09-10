﻿using DS;
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
            var ret = new LinkedList<LinkedList<T>>();

            var depthLists = DepthsLists.GetDepthLists(root);

            foreach(var dList in depthLists)
            {
                if(ret.Count == 0)
                {
                    ret.AddLast(new LinkedList<T>(dList.Select(n => n.Value)));
                }
                else
                {
                    ret = BuildNewList(dList, ret);
                }
            }

            return ret;
        }

        private static LinkedList<LinkedList<T>> BuildNewList<T>(LinkedList<BinaryTree<T>> depthLst, LinkedList<LinkedList<T>> currentLst)
        {
            var ret = new LinkedList<LinkedList<T>>();

            foreach (var newPermutation in GetPermutations(depthLst))
            {
                foreach (var existingPermutation in currentLst)
                {
                    ret.AddLast(existingPermutation.AddRange(newPermutation.Select(n => n.Value)));
                }
            }

            return ret;
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(LinkedList<T> lst)
        {
            var start = lst.First;
            do
            {
                yield return lst.ToArray();

                lst.AddLast(lst.First);
                lst.RemoveFirst();
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
