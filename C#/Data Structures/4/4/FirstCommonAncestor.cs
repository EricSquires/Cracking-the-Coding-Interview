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
            
            var childAncestor = FindFCA(root.Left, a, b) ??
                                FindFCA(root.Right, a, b);

            if(childAncestor == null)
            {
                bool isAncestor = DFS(root, a) && DFS(root, b);

                if(isAncestor)
                {
                    return root;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return childAncestor;
            }

        }

        private static bool DFS<T>(BinaryTree<T> root, BinaryTree<T> searchNode)
        {
            if(root == null)
            {
                return false;
            }

            if(root == searchNode)
            {
                return true;
            }

            return DFS(root.Left, searchNode) || DFS(root.Right, searchNode);
        }
    }
}
