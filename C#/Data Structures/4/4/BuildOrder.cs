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
            _rootProjects.Remove(project);
        }

        public bool CanBuild()
        {
            return _rootProjects.Any(p => HasCycle(_projects[p], new HashSet<DirectedGraphNode<T>>()));
        }

        public bool HasCycle(DirectedGraphNode<T> root, HashSet<DirectedGraphNode<T>> visited)
        {
            if(visited.Contains(root))
            {
                return true;
            }

            visited.Add(root);

            return root.Neighbors.Any(n => HasCycle((DirectedGraphNode<T>)n, visited));
        }
    }
}
