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
            Console.WriteLine("Is s2 is rotated string of s1");
            Console.WriteLine(IsStringRotated("praveen", "veenpar"));

            Console.WriteLine("A compressed string or original string whichever us smaller.");
            Console.WriteLine(CompressString("ssssuuuummmmmmiiiitttttt"));

            Console.WriteLine("Replace all spaces in a String with ‘%20’");
            Console.WriteLine(ReplaceSpace("Replace all spaces in a String"));
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

        static bool IsStringRotated(string s1, string s2)
        {
            //s1+s1 - Add
            //check s2 is substring of above one

            if (s1.Length != s2.Length)
            {
                return false;
            }

            s1 = s1 + s1;
            if (s1.Contains(s2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string CompressString(string str)
        {
            StringBuilder sb = new StringBuilder();
            int count = 1;
            char prev = str[0];

            for (int i = 1; i < str.Length; i++)
            {
                char cur = str[i];
                if (prev == cur)
                {
                    count++;
                }
                else
                {
                    sb.Append(prev);
                    sb.Append(count);
                    prev = cur;
                    count = 1;
                }
            }

            sb.Append(prev);
            sb.Append(count);
            if (str.Length < sb.Length)
            {
                return str;
            }
            else
            {
                return sb.ToString();
            }
        }

        static string ReplaceSpace(string str)
        {
            int spaceCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }

            int newLen = str.Length + 2 * spaceCount;
            var charsNew = new char[newLen];
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    charsNew[--newLen] = '0';
                    charsNew[--newLen] = '2';
                    charsNew[--newLen] = '%';
                }
                else
                {
                    charsNew[--newLen] = str[i];
                }
            }

            return new string(charsNew);
        }
    }
}

