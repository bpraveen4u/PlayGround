using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class StackProblems
    {
        public static void Main()
        {
            Console.WriteLine("Min Stack");

            var minStack = new MinStack();
            minStack.Push(9);
            minStack.Push(8);
            Console.WriteLine(minStack.Min());

            minStack.Push(-1);
            Console.WriteLine(minStack.Min());

            minStack.Push(0);
            Console.WriteLine(minStack.Min());

            minStack.Push(-6);
            minStack.Push(10);
            Console.WriteLine(minStack.Min());


            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            Console.WriteLine(minStack.Min());

            Console.WriteLine("Max Stack");

            var maxStack = new MaxStack();
            maxStack.Push(9);
            maxStack.Push(8);
            Console.WriteLine(maxStack.Max());

            maxStack.Push(-1);
            Console.WriteLine(maxStack.Max());

            maxStack.Push(0);
            Console.WriteLine(maxStack.Max());

            maxStack.Push(-6);
            maxStack.Push(10);
            Console.WriteLine(maxStack.Max());


            maxStack.Pop();
            maxStack.Pop();
            maxStack.Pop();
            Console.WriteLine(maxStack.Max());

            Console.ReadLine();

        }
    }

    public class MinStack
    {
        Stack<int> stack;
        int minElement;
        public MinStack()
        {
            stack = new Stack<int>();
            this.minElement = int.MinValue;
        }

        public int? Pop()
        {
            if (stack.Count == 0)
            {
                return null;
            }

            int item = stack.Pop();

            if (item < minElement)
            {
                var t = minElement;
                this.minElement = 2 * this.minElement - item;
                return t;
            }
            else
            {
                return item;
            }
        }

        public void Push(int item)
        {
            if (stack.Count == 0)
            {
                this.minElement = item;
                stack.Push(item);
                return;
            }

            if (item < this.minElement)
            {
                stack.Push(2 * item - this.minElement);
                this.minElement = item;
            }
            else
            {
                stack.Push(item);
            }
        }

        public int? Peek()
        {
            if (stack.Count == 0)
            {
                return null;
            }

            var item = stack.Peek();

            if (item < this.minElement)
            {
                return this.minElement;
            }
            else
            {
                return item;
            }
        }

        public int? Min()
        {
            if (stack.Count == 0)
            {
                return null;
            }
            else
            {
                return minElement;
            }
        }

        public int Count
        {
            get
            {
                return stack.Count;
            }
        }
    }

    public class MaxStack
    {
        Stack<int> stack;
        int maxElement;
        public MaxStack()
        {
            stack = new Stack<int>();
            this.maxElement = int.MinValue;
        }

        public int? Pop()
        {
            if (stack.Count == 0)
            {
                return null;
            }

            int item = stack.Pop();

            if (item > maxElement)
            {
                var t = maxElement;
                this.maxElement = 2 * this.maxElement - item;
                return t;
            }
            else
            {
                return item;
            }
        }

        public void Push(int item)
        {
            if (stack.Count == 0)
            {
                this.maxElement = item;
                stack.Push(item);
                return;
            }

            if (item > this.maxElement)
            {
                stack.Push(2 * item - this.maxElement);
                this.maxElement = item;
            }
            else
            {
                stack.Push(item);
            }
        }

        public int? Peek()
        {
            if (stack.Count == 0)
            {
                return null;
            }

            var item = stack.Peek();

            if (item > this.maxElement)
            {
                return this.maxElement;
            }
            else
            {
                return item;
            }
        }

        public int? Max()
        {
            if (stack.Count == 0)
            {
                return null;
            }
            else
            {
                return maxElement;
            }
        }

        public int Count
        {
            get
            {
                return stack.Count;
            }
        }
    }
}
