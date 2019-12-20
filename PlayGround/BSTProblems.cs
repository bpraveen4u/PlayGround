using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PlayGround
{
    class BSTProblems
    {
        public static void Main()
        {
            Console.WriteLine("BST Problems");

            var root = GetBST();
            InOrder(root);
            Swap(root, root.Left.Right);
            Console.WriteLine();
            InOrder(root);
            Console.WriteLine();

            FixBST(root);
            InOrder(root);
            Console.ReadLine();

        }

        static void Swap(Node<int> a, Node<int> b)
        {
            var temp = a.Data;
            a.Data = b.Data;
            b.Data = temp;
        }

        static void FixBST(Node<int> root)
        {
            Node<int> current = null;
            Node<int> middle = null;
            Node<int> last = null;
            Node<int> prev = null;
            //InOrder(root, ref prev, ref current, ref middle, ref last);
            InOrder(root, ref prev, ref current, ref last);

            //swap only data of current and last
            if (current != null && last != null)
            {
                Swap(current, last);
            }
            //else
            //{
            //    Swap(current, middle);
            //}
        }

        static Node<int> GetBST()
        {
            Node<int> root = new Node<int>(15);
            root.Left = new Node<int>(10);
            root.Left.Left = new Node<int>(8);
            root.Left.Right = new Node<int>(12);
            root.Right = new Node<int>(20);
            root.Right.Left = new Node<int>(16);
            root.Right.Right = new Node<int>(25);

            return root;
        }

        static void InOrder(Node<int> root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Console.Write(" " + root.Data);
                InOrder(root.Right);
            }
        }

        static void InOrder(Node<int> root, ref Node<int> prev, ref Node<int> current, ref Node<int> middle, ref Node<int> last)
        {
            //extra variable used
            if (root != null)
            {
                InOrder(root.Left, ref prev, ref current, ref middle, ref last);
                // 2 5 7 6
                if (prev != null && prev.Data > root.Data)
                {
                    if (current == null)
                    {
                        current = prev;
                        middle = root;
                    }
                    else
                        last = root;
                }

                prev = root;

                InOrder(root.Right, ref prev, ref current, ref middle, ref last);
            }
        }

        static void InOrder(Node<int> root, ref Node<int> prev, ref Node<int> current, ref Node<int> last)
        {
            //simpler and handles all the cases, dont forget to use ref variable or class level variables
            if (root != null)
            {
                InOrder(root.Left, ref prev, ref current, ref last);
                // 2 5 7 6
                if (prev != null && prev.Data > root.Data)
                {
                    if (current == null)
                    {
                        current = prev;
                    }
                    
                    last = root;
                }

                prev = root;

                InOrder(root.Right, ref prev, ref current, ref last);
            }
        }
    }
}
