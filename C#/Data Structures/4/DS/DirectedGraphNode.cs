using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class DirectedGraphNode<T> : GraphNode<T>
    {
        public DirectedGraphNode(T value) : base(value) { }

        /// <summary>
        /// Connects this node to the given one and returns this node for easy chaining of statements.
        /// </summary>
        public override GraphNode<T> ConnectTo(GraphNode<T> neighbor, double weight)
        {
            _neighbors[neighbor] = weight;
            return this;
        }
    }
}
