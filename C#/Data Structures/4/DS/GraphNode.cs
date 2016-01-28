using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    /// <summary>
    /// A simple implementation of an undirected graph node.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the graph</typeparam>
    public class GraphNode<T>
    {
        /// <summary>
        /// The value stored in the current node.
        /// </summary>
        public T Value { get; set; }

        protected readonly Dictionary<GraphNode<T>, double> _neighbors = new Dictionary<GraphNode<T>, double>();
        public IReadOnlyCollection<GraphNode<T>> Neighbors => _neighbors.Keys.ToList().AsReadOnly();
        
        /// <summary>
        /// Initializes the node with the given value and connects it to the given neighbors.
        /// </summary>
        /// <param name="value">The value in the current node</param>
        /// <param name="neighbors">The initial nodes to connect to</param>
        public GraphNode(T value, params GraphNode<T>[] neighbors)
        {
            Value = value;

            foreach(var n in neighbors)
            {
                ConnectTo(n);
            }
        }

        /// <summary>
        /// Connects this node to the given one and returns this node for easy chaining of statements.
        /// </summary>
        /// <param name="neighbors">The node to connect to</param>
        /// <returns>This node. This is really just for convenience so clients can chain calls together.</returns>
        public GraphNode<T> ConnectTo(GraphNode<T> neighbor)
        {
            return ConnectTo(neighbor, 1);
        }

        /// <summary>
        /// Connects this node to the given one and returns this node for easy chaining of statements.
        /// </summary>
        /// <param name="neighbors">The node to connect to</param>
        /// <returns>This node. This is really just for convenience so clients can chain calls together.</returns>
        public virtual GraphNode<T> ConnectTo(GraphNode<T> neighbor, double weight)
        {
            _neighbors[neighbor] = weight;
            neighbor._neighbors[this] = weight;

            return this;
        }
    }
}
