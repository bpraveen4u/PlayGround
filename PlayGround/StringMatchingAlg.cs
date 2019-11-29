using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class StringMatchingAlg
    {
        public static void Main()
        {
            //Console.WriteLine(KMP("AABAACAADAABAABA", "AADAA
            AllSubs("abcd");
            Console.ReadLine();
        }

        static void AllSubs(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j <= str.Length; j++)
                {
                    for (int k = i; k < j; k++)
                    {
                        Console.Write(str[k]);
                    }
                    Console.WriteLine();
                }
                //Console.WriteLine();

            }
        }

        static int Match(string str, string pat)
        {
            if (str == null || pat == null)
            {
                return -1;
            }

            if (pat.Length > str.Length)
            {
                return -1;
            }

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < str.Length && j < pat.Length)
            {
                if (str[i] == pat[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = 0;
                    k++;
                    i = k;
                }
            }

            if (j == pat.Length)
            {
                return i - j;
            }

            return -1;
        }

        private static int[] ComputeTemporaryArray(string pattern)
        {
            int[] lps = new int[pattern.Length];
            int index = 0;
            for (int i = 1; i < pattern.Length;)
            {
                if (pattern[i] == pattern[index])
                {
                    lps[i] = index + 1;
                    index++;
                    i++;
                }
                else
                {
                    if (index != 0)
                    {
                        index = lps[index - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
            return lps;
        }

        private static int KMP(string str, string pat)
        {
            if (str == null || pat == null)
            {
                return -1;
            }

            var lps = ComputeTemporaryArray(pat);
            int i = 0;
            int j = 0;
            while (i < str.Length && j < pat.Length)
            {
                if (str[i] == pat[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            if (j == pat.Length)
            {
                return i - j;
            }
            else
            {
                return -1;
            }
        }
    }
}
