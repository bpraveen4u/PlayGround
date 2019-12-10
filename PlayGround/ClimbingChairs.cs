using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class ClimbingChairs
    {
        public static void Main()
        {
            Console.WriteLine("You are climbing a stair case. It takes n steps to reach to the top.\nEach time you can either climb 1 or 2 steps. \nIn how many distinct ways can you climb to the top?\nNote: Given n will be a positive integer.");
            
            Console.WriteLine(ClimbStairs(10));
            Console.WriteLine(ClimbStairsFormula(10));

            Console.ReadLine();
        }

        static int ClimbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        static int ClimbStairsFormula(int n)
        {
            //O(1)
            double sqrt5 = Math.Sqrt(5);
            double fibn = Math.Pow((1 + sqrt5) / 2, n + 1) - Math.Pow((1 - sqrt5) / 2, n + 1);
            return (int)(fibn / sqrt5);
        }
    }
}
