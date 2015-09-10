using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public static class FirstCommonAncestor
    {
        public static BinaryTree<T> FindFCA<T>(BinaryTree<T> root, BinaryTree<T> a, BinaryTree<T> b)
        {
            if(root == null) return null;

            bool isAncestor = DFS(root, a) && DFS(root, b);
            
            if(isAncestor)
            {
                return root;
            }
            
            return FindFCA(root.Left, a, b) ??
                   FindFCA(root.Right, a, b);
        }

        private static bool DFS<T>(BinaryTree<T> root, BinaryTree<T> searchNode)
        {
            if(root == searchNode)
            {
                return true;
            }

            return DFS(root.Left, searchNode) || DFS(root.Right, searchNode);
        }
    }
}
