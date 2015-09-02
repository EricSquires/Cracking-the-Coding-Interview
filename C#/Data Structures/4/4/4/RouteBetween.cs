using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public class RouteBetween<T> : DirectedGraphNode<T>
    {
        public RouteBetween(T value) : base(value) { }

        public bool HasRoute(RouteBetween<T> dest, HashSet<RouteBetween<T>> touched = null)
        {
            if(_neighbors.ContainsKey(dest))
            {
                return true;
            }

            if(touched == null)
            {
                touched = new HashSet<RouteBetween<T>>();
            }

            touched.Add(this);

            var searchNodes = _neighbors.Keys.Where(k => !touched.Contains(k)).Cast<RouteBetween<T>>();

            foreach (var n in searchNodes)
            {
                if(n.HasRoute(dest))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
