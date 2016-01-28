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
        /// <param name="neighbor">The node to connect to</param>
        /// <param name="weight">The weight of the edge from this node to <paramref name="neighbor"/></param>
        /// <returns>This node. This is really just for convenience so clients can chain calls together.</returns>
        public override GraphNode<T> ConnectTo(GraphNode<T> neighbor, double weight)
        {
            _neighbors[neighbor] = weight;
            return this;
        }
    }
}
