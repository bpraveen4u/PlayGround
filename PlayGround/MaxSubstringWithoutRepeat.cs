using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class MaxSubstringWithoutRepeat
    {
        public static void Main()
        {
            Console.WriteLine("Find the max substring without repeating character");

            Console.WriteLine(MaxSubNoDups("pwwkew"));

            Console.ReadLine();
        }

        static int MaxSubNoDups(string text)
        {
            Console.WriteLine(text);
            //Sliding window approach
            int max = 0;
            int i = 0;
            int j = 0;
            string ans = string.Empty;
            List<char> map = new List<char>();

            while (i < text.Length && j < text.Length)
            {
                if (!map.Contains(text[i]))
                {
                    map.Add(text[i++]);
                    int len = i - j;
                    if (len > max)
                    {
                        max = len;
                        ans = text.Substring(j, len);
                    }
                }
                else
                {
                    map.Remove(text[j++]);
                }
                //map.ToArray().Dump();
            }

            Console.WriteLine(ans);
            return max;

        }
    }
}
