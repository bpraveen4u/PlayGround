using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class RodCuttingProblem
    {
        public static void Main()
        {
            Console.WriteLine("Given a rod of length n inches and a table of prices pi, i=1,2,…,n, write an algorithm to find the maximum revenue rn obtainable by cutting up the rod and selling the pieces.");

            int[] values = { 2, 3, 7, 8, 9 };
            int len = 5;
            var res = profit(values, len);
            Console.WriteLine(res);
            Console.WriteLine("DP");
            //res = profitDP(values, len);
            //Console.WriteLine(res);
            res = profitDP(values);
            Console.WriteLine(res);

            Console.ReadLine();
        }

        public static int profit(int[] value, int length)
        {
            if (length <= 0)
                return 0;
            // either we will cut it or don't cut it
            int max = -1;
            for (int i = 0; i < length; i++)
                max = Math.Max(max, value[i] + profit(value, length - (i + 1)));
            return max;
        }

        public static int profitDP(int[] value, int length)
        {
            //not clear solution
            int[] solution = new int[length + 1];
            solution[0] = 0;

            for (int i = 1; i <= length; i++)
            {
                int max = -1;
                for (int j = 0; j < i; j++)
                {
                    max = Math.Max(max, value[j] + solution[i - (j + 1)]);
                    solution[i] = max;
                }
                Console.Write(i + ": ");
                solution.Dump();
            }
           
            solution.Dump();
            return solution[length];
        }

        static int profitDP(int [] price)
        {
            var val = new int[price.Length + 1];
            for (int i = 1; i <= price.Length; i++)
            {
                for (int j = i; j <= price.Length; j++)
                {
                    val[j] = Math.Max(val[j], val[j - i] + price[i - 1]);
                }
                Console.Write(i + ": ");
                val.Dump();
            }
            return val[price.Length];
        }

        static int maxValue1(int[] price)
        {
            var dp = new int[price.Length + 1];
            for (int i = 1; i <= price.Length; i++)
            {
                dp[i] = price[i - 1];
            }
            for (int i = 1; i <= price.Length; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    dp[i] = Math.Max(dp[i], dp[i - j] + dp[j]);
                }
            }
            return dp[price.Length];
        }
    }
}
