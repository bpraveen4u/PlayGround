using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class QueueProblems
    {
        public static void Main()
        {
            Console.WriteLine("Queue Problems");
            //QueueWithStack<int> queue = new QueueWithStack<int>();

            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);
            //var t = queue.Dequeue();
            //Console.WriteLine(t);

            //t = queue.Dequeue();
            //Console.WriteLine(t);

            var stack = new StackWithQueue<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            Console.ReadLine();
        }
    }

    class QueueWithStack<T>
    {
        Stack<T> stack;
        public QueueWithStack()
        {
            stack = new Stack<T>();
        }

        public void Enqueue(T data)
        {
            stack.Push(data);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            return DequeueUtil();
        }

        private T DequeueUtil()
        {
            T current = stack.Pop();
            if (stack.Count == 0)
            {
                return current;
            }
            var result = this.DequeueUtil();
            stack.Push(current);

            return result;
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }
    }

    class StackWithQueue<T>
    {
        Queue<T> queue1;
        Queue<T> queue2;
        int size;
        public StackWithQueue()
        {
            this.queue1 = new Queue<T>();
            this.queue2 = new Queue<T>();
            this.size = 0;
        }

        public void Push(T data)
        {
            size++;

            // Push x first in empty q2 
            queue2.Enqueue(data);

            // Push all the remaining 
            // elements in q1 to q2. 
            while (queue1.Count > 0)
            {
                queue2.Enqueue(queue1.Peek());
                queue1.Dequeue();
            }

            // swap the names of two queues 
            var q = queue1;
            queue1 = queue2;
            queue2 = q;
        }

        public T Pop()
        {
            // if no elements are there in q1 
            if (queue1.Count == 0)
                return default(T);
            var res = queue1.Dequeue();
            size--;

            return res;
        }

        public T Top()
        {
            if (queue1.Count == 0)
                return default(T);

            return queue1.Peek();
        }

        public int Count
        {
            get
            {
                return queue1.Count;
            }
        }
    }
}
