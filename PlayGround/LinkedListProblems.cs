using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class LinkedListProblems
    {
        public static void Main()
        {
            Console.WriteLine("LL");
            var head = new LLNode<int>(1);
            var tNode = new LLNode<int>(2);
            head.Next = tNode;
            var current = tNode;
            tNode = new LLNode<int>(3);
            current.Next = tNode;
            current = tNode;
            var loop = tNode;

            tNode = new LLNode<int>(4);
            current.Next = tNode;
            current = tNode;
            
            tNode = new LLNode<int>(5);
            current.Next = tNode;
            current = tNode;
            //var loop = tNode;
            tNode = new LLNode<int>(6);
            current.Next = tNode;
            current = tNode;
            current.Next = loop;
            //var res = DetectLoop(head);
            var res = Detect(head);
            if (res == null)
            {
                Console.WriteLine("no loop");
            }
            else
            {
                Console.WriteLine("found loop");
                Console.WriteLine(res.Data);
            }
            Console.ReadLine();
        }

        static LLNode<int> DetectLoop(LLNode<int> head)
        {
            var p = head;
            var q = head;

            while (p != null && q != null && q.Next != null)
            {
                p = p.Next;
                q = q.Next.Next;

                if (p == q)
                {
                    //var loop = p;
                    q = head;
                    while (p == q)
                    {
                        p = p.Next;
                        q = q.Next;
                    }
                    return p;
                }
            }
            return null;
        }

        static LLNode<int> Detect(LLNode<int> head)
        {
            LLNode<int> temp = new LLNode<int>(-1);
            while (head !=null)
            {
                Console.WriteLine(head.Data);
                if (head.Next == null)
                {
                    return null;
                }

                if (head.Next == temp)
                {
                    break;
                }
                var next = head.Next;
                head.Next = temp;
                head = next;
            }

            return head;
        }
    }
}
