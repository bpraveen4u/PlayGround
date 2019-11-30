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
            QueueWithStack<int> queue = new QueueWithStack<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            var t = queue.Dequeue();
            Console.WriteLine(t);

            t = queue.Dequeue();
            Console.WriteLine(t);

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
}
