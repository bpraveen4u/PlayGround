using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace PlayGround
{
    class TreeLevelOrderTraversal
    {
        public static void Main()
        {
            Console.WriteLine("Level order traversal of a tree");

            var root = GetCharTree();
            var introot = GetIntTree();
            var completeTree = GetCompleteTree();

            Console.WriteLine(IsCompleteBinaryTree(completeTree));

            // Console.WriteLine(LCA(introot, 6, 10).Data);
            //Console.WriteLine("Print Ancestor of a node");
            //PrintAncestors(introot, 10);
            //PrintVerticalSumOfNodes(introot);

            //LevelOrderTraversal(root);
            //LevelOrderTraversalRecursion(root);
            //var height = Height(root);
            //Console.WriteLine(height);
            //Console.WriteLine(HeightIterative(root));
            // SpiralTraversal(root);
            Console.ReadLine();
        }

        static bool PrintAncestors(Node<int> node, int target)
        {
            /* base cases */
            if (node == null)
            {
                return false;
            }

            if (node.Data == target)
            {
                //Console.Write(node.Data + " ");
                return true;
            }

            /* If target is present in either left or right subtree  
            of this node, then print this node */
            if (PrintAncestors(node.Left, target)
            || PrintAncestors(node.Right, target))
            {
                Console.Write(node.Data + " ");
                return true;
            }

            /* Else return false */
            return false;
        }

        static void PrintVerticalSumOfNodes(Node<int> root)
        {
            var llnode = new LLNode<int>(0);

            VerticalSumUtil(root, llnode);
            while (llnode.Previous != null)
            {
                llnode = llnode.Previous;
            }

            while (llnode != null)
            {
                Console.WriteLine(llnode.Data);
                llnode = llnode.Next;
            }
        }

        static void VerticalSumUtil(Node<int> node, LLNode<int> llnode)
        {
            llnode.Data = llnode.Data + node.Data;

            if (node.Left != null)
            {
                if (llnode.Previous == null)
                {
                    llnode.Previous = new LLNode<int>(0);
                    llnode.Previous.Next = llnode;
                }

                VerticalSumUtil(node.Left, llnode.Previous);
            }

            if (node.Right != null)
            {
                if (llnode.Next == null)
                {
                    llnode.Next = new LLNode<int>(0);
                    llnode.Next.Previous = llnode;
                }

                VerticalSumUtil(node.Right, llnode.Next);
            }
        }

        static Node<char> GetCharTree()
        {
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

            return root;
        }
        static Node<int> GetIntTree()
        {
            Node<int> root = new Node<int>(5);
            root.Left = new Node<int>(2);
            root.Right = new Node<int>(8);
            root.Left.Left = new Node<int>(1);
            root.Right.Left = new Node<int>(6);
            root.Right.Right = new Node<int>(10);
            root.Right.Left.Left = new Node<int>(4);
            root.Right.Left.Right = new Node<int>(7);
            root.Right.Left.Right.Left = new Node<int>(4);
            root.Right.Left.Right.Right = new Node<int>(6);

            return root;
        }

        static Node<int> GetCompleteTree()
        {
            Node<int> root = new Node<int>(5);
            root.Left = new Node<int>(2);
            root.Right = new Node<int>(8);

            return root;
        }

        static Node<int> LCA(Node<int> node, int n1, int n2)
        {
            if (node == null)
                return null;

            if (node.Data == n1 || node.Data == n2)
                return node;

            var leftLCA = LCA(node.Left, n1, n2);
            var rightLCA = LCA(node.Right, n1, n2);

            if (leftLCA != null && rightLCA != null)
                return node;

            return leftLCA != null ? leftLCA : rightLCA;
        }

        static void LevelOrderTraversal(Node<char> root)
        {
            Queue<Node<char>> queue = new Queue<Node<char>>();
            queue.Enqueue(root);
            queue.Enqueue(null);//for new line in output
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == null)
                {
                    Console.WriteLine();
                    if (queue.Count > 0)
                    {
                        queue.Enqueue(null);//for new line in output
                    }
                }
                else
                {
                    Console.Write(node?.Data + " ");
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
                Console.WriteLine();
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
                Console.Write(node.Data + " ");
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

        static int NodeCount(Node<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + NodeCount(root.Left) + NodeCount(root.Right);
        }

        static bool IsCompleteBinaryTree(Node<int> root)
        {
            int nodeCount = NodeCount(root);

            return IsCompleteUtil(root, 0, nodeCount);
        }

        static bool IsCompleteUtil(Node<int> node, int nodeIndex, int totalCount)
        {
            if (node == null)
            {
                return true;
            }

            if (nodeIndex >= totalCount)
            {
                return false;
            }

            var leftIndex = 2 * nodeIndex + 1;
            var rightIndex = 2 * nodeIndex + 2;
            return IsCompleteUtil(node.Left, leftIndex, totalCount) && IsCompleteUtil(node.Right, rightIndex, totalCount);
        }
    }
}
