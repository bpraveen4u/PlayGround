using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PlayGround
{
    class SymmetricTree
    {
        public static void Main()
        {
            Console.WriteLine("is tree is symmetric, mirro image on root node");

            var root = new Node<int>(1);
            root.Left = new Node<int>(2);
            root.Right = new Node<int>(2);
            root.Left.Left = new Node<int>(3);
            root.Left.Right = new Node<int>(4);
            root.Right.Left = new Node<int>(4);
            root.Right.Right = new Node<int>(3);
            bool output = IsSymmetric(root);

            Console.WriteLine(output);
            Console.ReadLine();
        }

        static bool IsSymmetric(Node<int> root)
        {
            return IsSymmetric(root, root);
        }
        static bool IsSymmetric(Node<int> node1, Node<int> node2)
        {
            if (node1 == null && node2 == null)
            {
                return true;
            }

            if (node1 != null && node2 != null && node1.Data == node2.Data)
            {
                return IsSymmetric(node1.Left, node2.Right) && IsSymmetric(node1.Right, node2.Left);
            }

            return false;
        }
    }

    class Node<T>
    {
        public T Data;
        public Node<T> Left;
        public Node<T> Right;

        public Node(T data)
        {
            this.Data = data;
            this.Left = this.Right = null;
        }
    }

    class LLNode<T>
    {
        public T Data;
        public LLNode<T> Previous;
        public LLNode<T> Next;

        public LLNode(T data)
        {
            this.Data = data;
            this.Previous = this.Next = null;
        }
    }
}
