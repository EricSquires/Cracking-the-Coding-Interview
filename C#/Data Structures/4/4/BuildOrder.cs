using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;

namespace _4
{
    public class BuildOrder<T>
    {
        private Dictionary<T, DirectedGraphNode<T>> _projects = new Dictionary<T, DirectedGraphNode<T>>();
        private Dictionary<T, HashSet<T>> _dependencies = new Dictionary<T, HashSet<T>>();
        private HashSet<T> _rootProjects = new HashSet<T>();

        public BuildOrder(IEnumerable<T> projects, IEnumerable<Tuple<T, T>> dependencies)
        {
            foreach(var p in projects)
            {
                _projects[p] = new DirectedGraphNode<T>(p);
                _rootProjects.Add(p);
            }

            foreach(var d in dependencies)
            {
                AddDependency(d.Item1, d.Item2);
            }
        }

        public void AddDependency(T project, T dependency)
        {
            _projects[dependency].ConnectTo(_projects[project]);

            if(!_dependencies.ContainsKey(project))
            {
                _dependencies[project] = new HashSet<T>();
            }

            _dependencies[project].Add(dependency);
            _rootProjects.Remove(project);
        }

        public bool CanBuild()
        {
            return !HasCycle();
        }

        public bool HasCycle()
        {
            foreach(var proj in _projects.Values)
            {
                if(proj.Neighbors.Any(n => HasCycle(n, proj, new HashSet<GraphNode<T>>())))
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasCycle(GraphNode<T> node, GraphNode<T> root, HashSet<GraphNode<T>> visited)
        {
            if(node == root)
            {
                return true;
            }

            visited.Add(node);
            
            return node.Neighbors.Any(n => !visited.Contains(n) && HasCycle(n, root, visited));
        }

        public IEnumerable<T> GetBuildOrder()
        {
            var order = new LinkedList<T>();
            var visited = new HashSet<T>();

            foreach(var p in _rootProjects)
            {
                GetBuildOrder(_projects[p], order, visited);
            }

            return order;
        }

        private LinkedList<T> GetBuildOrder(DirectedGraphNode<T> root, LinkedList<T> order, HashSet<T> visited)
        {
            // We haven't built all this node's dependencies
            if (_dependencies.ContainsKey(root.Value) && _dependencies[root.Value].Any(d => !visited.Contains(d)))
            {
                return order;
            }

            // We've already visited this node
            if (!visited.Add(root.Value))
            {
                return order;
            }

            order.AddLast(root.Value);
            
            foreach(var n in root.Neighbors)
            {
                GetBuildOrder((DirectedGraphNode<T>)n, order, visited);
            }

            return order;
        }
    }
}
