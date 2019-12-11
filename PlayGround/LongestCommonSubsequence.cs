using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PlayGround
{
    class LongestCommonSubsequence
    {
        public static void Main()
        {
            Console.WriteLine("Longest common subsequence");
            String A = "ACBDEA";
            String B = "ABCDA";
            //lcs = acad, len = 4
            var res = LCSRecursive(A, B);
            Console.WriteLine(res);
            Console.WriteLine("LCS DP");
            res = LCSDP(A, B);
            Console.WriteLine(res);

            Console.WriteLine("LCS DP Print solution");
            res = LCSDPWithSolution(A, B);
            Console.WriteLine(res);
            Console.ReadLine();
        }

        static int LCSRecursive(string s1, string s2)
        {
            if (s1.Length == 0 || s2.Length == 0)
            {
                return 0;
            }
            var s1Len = s1.Length;
            var s2Len = s2.Length;

            if (s1[s1Len - 1] == s2[s2Len - 1])
            {
                // Add 1 to the result and remove the last character from both
                // the strings and make recursive call to the modified strings.
                return 1 + LCSRecursive(s1.Substring(0, s1Len - 1), s2.Substring(0, s2Len - 1));
            }
            else
            {
                return Math.Max(
                    LCSRecursive(s1.Substring(0, s1Len - 1), s2),
                    LCSRecursive(s1, s2.Substring(0, s2Len - 1)));
            }
        }

        static int LCSDP(string s1, string s2)
        {
            int[,] res = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
            {
                res[i, 0] = 0;
            }

            for (int j = 0; j < s2.Length; j++)
            {
                res[0, j] = 0;
            }

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        res[i, j] = 1 + res[i - 1, j - 1];
                    }
                    else
                    {
                        res[i, j] = Math.Max(res[i - 1, j], res[i, j - 1]);
                    }
                }
            }
            res.Dump();

            return res[s1.Length, s2.Length];
        }

        static int LCSDPWithSolution(string s1, string s2)
        {
            int[,] res = new int[s1.Length + 1, s2.Length + 1];
            string[,] solution = new string[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
            {
                res[i, 0] = 0;
                solution[i, 0] = "0";
            }

            for (int j = 0; j < s2.Length; j++)
            {
                res[0, j] = 0;
                solution[0, j] = "0";
            }

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        res[i, j] = 1 + res[i - 1, j - 1];
                        solution[i, j] = "diagonal";
                    }
                    else
                    {
                        res[i, j] = Math.Max(res[i - 1, j], res[i, j - 1]);
                        if (res[i, j] == res[i - 1, j])
                        {
                            solution[i, j] = "top";
                        }
                        else
                        {
                            solution[i, j] = "left";
                        }
                    }
                }
            }

            // below code is to just print the result
            string x = solution[s1.Length, s2.Length];
            String answer = "";
            int a = s1.Length;
            int b = s2.Length;
            while (x != "0")
            {
                if (solution[a, b] == "diagonal")
                {
                    answer = s1[a - 1] + answer;
                    a--;
                    b--;
                }
                else if (solution[a, b] == "left")
                {
                    b--;
                }
                else if (solution[a, b] == "top")
                {
                    a--;
                }
                x = solution[a, b];
            }
            Console.WriteLine(answer);
                        
            res.Dump();

            return res[s1.Length, s2.Length];
        }
    }
}
