using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class MinWindowSubstring
    {
        public static void Main()
        {
            Console.WriteLine("Minimum window substrin containing all the character of the pattern");

            var res= MinWindowStr("ADOBECODEBANC", "AABC");
            Console.WriteLine(res);
            Console.ReadLine();
        }

        static string MinWindowStr(string s, string t)
        {
            if ((s == null && t == null) || s == "" && t == "" && s.Length > t.Length)
            {
                return "";
            }

            //char[] bank = new char[256];
            Dictionary<char, int> map = new Dictionary<char, int>();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            string result = "";
            int start = 0;
            //int end = 0;
            int min = int.MaxValue;
            int count = 0;

            for (int i = 0; i < t.Length; i++)
            {
                map[t[i]] = 0;
                if (dict.ContainsKey(t[i]))
                {
                    dict[t[i]]++;
                }
                else
                {
                    dict[t[i]] = 1;
                }
            }

            for(int end = 0; end < s.Length; end++) {
                if (map.ContainsKey(s[end]))
                {
                    map[s[end]]++;

                    if (map[s[end]] <= dict[s[end]])
                    {
                        count++;
                    }
                }
                //Console.WriteLine(count+", start:"+start+", end:" +end);
                if (count == t.Length)
                {
                    while (!dict.ContainsKey(s[start]) || map[s[start]] > dict[s[start]])
                    {
                        if (map.ContainsKey(s[start]))
                        {
                            map[s[start]]--;
                        }
                        start++;
                    }

                    if (end - start + 1 < min)
                    {
                        min = end - start + 1;
                        result = s.Substring(start, end - start + 1);
                    }
                }
            }

            //bank.Dump();

            return result;
        }
    }
}
