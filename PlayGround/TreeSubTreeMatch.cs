using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class TreeSubTreeMatch
    {
        public static void Main()
        {
            Console.WriteLine("Tree is sub tree of another tree");


            Console.ReadLine();
        }


        static bool AreIdentical(Node<int> tree, Node<int> subtree)
        {
            if (tree == null && subtree == null)
            {
                return true;
            }

            if (tree == null || subtree == null)
            {
                return false;
            }

            return tree.Data == subtree.Data && AreIdentical(tree.Left, subtree.Left) && AreIdentical(tree.Right, subtree.Right);
        }

        static bool IsSubTree(Node<int> tree, Node<int> subtree)
        {
            if (subtree == null)
            {
                return true;
            }

            if (tree == null)
            {
                return false;
            }

            if (AreIdentical(tree, subtree))
            {
                return true;
            }

            return IsSubTree(tree.Left, subtree) || IsSubTree(tree.Right, subtree);

        }
    }

}
