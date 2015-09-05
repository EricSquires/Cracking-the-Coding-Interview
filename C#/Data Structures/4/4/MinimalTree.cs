using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public static class MinimalTree
    {
        public static BST<T> BuildTree<T>(IList<T> values) where T : IComparable<T>
        {
            int pivot = values.Count / 2;
            
            var ret = new BST<T>(values[pivot]);

            for(int i = 0; i < Math.Ceiling(values.Count / 2.0) + 1; i++)
            {
                var low = pivot - i;
                var high = pivot + i;

                if(low >= 0)
                {
                    ret.Insert(values[low]);
                }

                if(high < values.Count)
                {
                    ret.Insert(values[high]);
                }
            }

            return ret;
        }
    }
}
