using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class StringManipulations
    {
        public static void Main()
        {
            Console.WriteLine("string manipulations");

            Reverse("Hello World");
            Console.WriteLine();
            Reverse1("Hello World");

            Console.ReadLine();
        }
        static void Reverse(string str)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    stack.Push(str[i]);
                }
                else
                {
                    while (stack.Count != 0)
                    {
                        Console.Write(stack.Pop());
                    }

                    Console.Write(" ");
                }
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
        }

        static void Reverse1(string str)
        {
            int j = 0;
            var k = 0;
            int i = 0;
            for (i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    k = i - 1;
                    while (j <= k)
                    {
                        Console.Write(str[k--]);
                    }

                    j = i + 1;
                    Console.Write(" ");
                }
            }

            k = i - 1;
            while (j <= k)
            {
                Console.Write(str[k--]);
            }
        }
    }
}

