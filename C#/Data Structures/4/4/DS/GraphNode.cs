using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class GraphNode<T>
    {
        public T Value { get; set; }

        private readonly Dictionary<GraphNode<T>, double> _neighbors = new Dictionary<GraphNode<T>, double>();
        public IReadOnlyCollection<GraphNode<T>> Neighbors => _neighbors.Keys.ToList().AsReadOnly();
        
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
        public virtual GraphNode<T> ConnectTo(GraphNode<T> neighbor)
        {
            return ConnectTo(neighbor, 1);
        }

        /// <summary>
        /// Connects this node to the given one and returns this node for easy chaining of statements.
        /// </summary>
        public virtual GraphNode<T> ConnectTo(GraphNode<T> neighbor, double weight)
        {
            _neighbors[neighbor] = weight;
            neighbor._neighbors[this] = weight;

            return this;
        }
    }
}
