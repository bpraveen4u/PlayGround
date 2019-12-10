using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class MinimumEditDistance
    {
        public static void Main()
        {
            Console.WriteLine("Minimum no of edit required convert string s1 to s2");
            string s1 = "CAGG";
            string s2 = "DAGGY";
            var res = MinEditRecursive(s1, s2, s1.Length, s2.Length);
            Console.WriteLine(res);

            Console.WriteLine("DP");
            MinEditDP(s1, s2);
            Console.ReadLine();

        }

        static int MinEditRecursive(string s1, string s2, int s1Length, int s2Length)
        {
            //If any of the string if empty then number of operations
            //needed would be equal to the length of other string
            //(Either all characters will be removed or inserted)

            if (s1Length == 0)
            {
                return s2Length; //all elements to be inserted
            }
            if (s2Length == 0)
            {
                return s1Length; // all elements to be removed
            }

            //If last characters are matching, ignore the last character
            // and make a recursive call with last character removed.
            if (s1[s1Length - 1] == s2[s2Length - 1])
            {
                return MinEditRecursive(s1, s2, s1Length - 1, s2Length - 1);
            }
            else
            {
                return 1 + Math.Min(MinEditRecursive(s1, s2, s1Length, s2Length - 1),
                    Math.Min(MinEditRecursive(s1, s2, s1Length - 1, s2Length), MinEditRecursive(s1, s2, s1Length - 1, s2Length - 1)));
            }
        }

        static int MinEditDP(string s1, string s2)
        {
            int[,] res = new int[s1.Length + 1, s2.Length + 1];

            res[0, 0] = 0;
            for (int i = 1; i <= s1.Length; i++)
            {
                res[i, 0] = 1 + res[i - 1, 0];
            }

            for (int j = 1; j <= s2.Length; j++)
            {
                res[0, j] = 1 + res[0, j - 1];
            }

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        res[i, j] = res[i - 1, j - 1];
                    }
                    else
                    {
                        res[i, j] = 1 + Math.Min(res[i - 1, j], Math.Min(res[i, j - 1], res[i - 1, j - 1]));
                    }
                }
            }

            res.Dump();

            return res[s1.Length, s2.Length];
        }
    }
}
