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
            var root = new Node<int>(5);
            root.Left = new Node<int>(3);
            root.Right = new Node<int>(4);
            root.Left.Left = new Node<int>(2);
            root.Left.Right = new Node<int>(1);

            var subroot = new Node<int>(3);
            subroot.Left = new Node<int>(2);
            subroot.Right = new Node<int>(1);

            var res = IsSubTree(root, subroot);
            Console.WriteLine(res);
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
