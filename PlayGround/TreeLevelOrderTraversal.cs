using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class TreeLevelOrderTraversal
    {
        public static void Main()
        {
            Console.WriteLine("Level order traversal of a tree");

            Node<char> root = new Node<char>('a');
            root.Left = new Node<char>('b');
            root.Right = new Node<char>('c');
            root.Left.Left = new Node<char>('d');
            root.Right.Left = new Node<char>('e');
            root.Right.Right = new Node<char>('f');
            root.Right.Left.Left = new Node<char>('g');
            root.Right.Left.Right = new Node<char>('h');
            root.Right.Left.Right.Left = new Node<char>('i');
            root.Right.Left.Right.Right = new Node<char>('j');

            //LevelOrderTraversal(root);
            //LevelOrderTraversalRecursion(root);
            //var height = Height(root);
            //Console.WriteLine(height);
            //Console.WriteLine(HeightIterative(root));
            SpiralTraversal(root);
            Console.ReadLine();
        }

        static void LevelOrderTraversal(Node<char> root)
        {
            Queue<Node<char>> queue = new Queue<Node<char>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.Write(node.Data + " ");
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }

        static int HeightIterative(Node<char> root)
        {
            Queue<Node<char>> queue = new Queue<Node<char>>();
            queue.Enqueue(root);
            int height = 0;

            while (true)
            {
                var nodeCount = queue.Count;
                if (nodeCount == 0)
                {
                    return height;
                }

                height++;

                while (nodeCount > 0)
                {
                    var node = queue.Dequeue();
                    //Console.Write(node.Data + " ");
                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }

                    nodeCount--;
                }
            }
        }

        static void SpiralTraversal(Node<char> root)
        {
            Stack<Node<char>> s1 = new Stack<Node<char>>();
            Stack<Node<char>> s2 = new Stack<Node<char>>();

            s1.Push(root);

            while (s1.Count > 0 || s2.Count > 0)
            {
                while (s1.Count > 0)
                {
                    var node = s1.Pop();
                    Console.WriteLine(node.Data);

                    if (node.Left != null)
                    {
                        s2.Push(node.Left);
                    }

                    if (node.Right != null)
                    {
                        s2.Push(node.Right);
                    }
                }

                while (s2.Count > 0)
                {
                    var n = s2.Pop();
                    Console.WriteLine(n.Data);

                    if (n.Right != null)
                    {
                        s1.Push(n.Right);
                    }
                    if (n.Left != null)
                    {
                        s1.Push(n.Left);
                    }
                }
            }

        }

        static void LevelOrderTraversalRecursion(Node<char> root)
        {
            var height = Height(root);

            for (int i = 0; i < height; i++)
            {
                LevelOrderRecursive(root, i + 1);
            }
        }

        static void LevelOrderRecursive(Node<char> node, int level)
        {
            if (node == null)
            {
                return;
            }

            if (level == 1)
            {
                Console.WriteLine(node.Data);
                return;
            }

            LevelOrderRecursive(node.Left, level - 1);
            LevelOrderRecursive(node.Right, level - 1);
        }

        static int Height(Node<char> root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                var lh = Height(root.Left);
                var rh = Height(root.Right);

                if (lh > rh)
                {
                    return lh + 1;
                }
                else
                {
                    return rh + 1;
                }
            }
        }
    }
}
