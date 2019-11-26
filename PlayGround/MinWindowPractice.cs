using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PlayGround
{
    class MinWindowPractice
    {
        public static void Main()
        {
            Console.WriteLine("Mind window pattern matching");

            var res = MinWindow("ADOBECAAODEBANC", "AABC");

            Console.WriteLine(res);
            Console.ReadLine();
        }

        static string MinWindow(string str, string pat)
        {
            string result = "";

            if (str == null || str.Length == 0 || pat == null || pat.Length == 0||str.Length < pat.Length)
            {
                return result;
            }

            Dictionary<char, int> patter_map = new Dictionary<char, int>();
            Dictionary<char, int> string_map = new Dictionary<char, int>();

            for (int i = 0; i < pat.Length; i++)
            {
                string_map[pat[i]] = 0;

                if (patter_map.ContainsKey(pat[i]))
                {
                    patter_map[pat[i]]++;
                }
                else
                {
                    patter_map[pat[i]] = 1;
                }
            }

            int start = 0;
            int patternCount = 0;
            int minLen = int.MaxValue;

            for (int end = 0; end < str.Length; end++)
            {
                if (string_map.ContainsKey(str[end]))
                {
                    string_map[str[end]]++;
                    if (string_map[str[end]] <= patter_map[str[end]])
                    {
                        patternCount++;
                    }
                }

                if (patternCount == pat.Length)
                {
                    while (!patter_map.ContainsKey(str[start]) || string_map[str[start]] > patter_map[str[start]])
                    {
                        if (string_map.ContainsKey(str[start]))
                        {
                            string_map[str[start]]--;
                        }
                        start++;
                    }

                    int windowLen = end - start + 1;
                    if (windowLen < minLen)
                    {
                        minLen = windowLen;
                        result = str.Substring(start, windowLen);
                    }
                }
            }

            return result;
        }
    }
}
