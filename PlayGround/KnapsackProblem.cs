using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class KnapsackProblem
    {
        public static void Main()
        {
            Console.WriteLine("0/1 Knapsack problem recursive and DP");

            int[] wt = new int[] { 1, 3, 4, 5 };
            int[] v = new int[] { 1, 4, 5, 7 };
            int n = 4;
            int W = 6;
            int res = Knapsack(wt, v, W, n);
            Console.WriteLine(res);
            res = KnapsackDP(wt, v, W, n);
            Console.WriteLine(res);
            Console.ReadLine();
        }

        static int Knapsack(int[] wt, int[]v, int W, int n)
        {
            if (W == 0 || n == 0)
            {
                return 0;
            }
            else if(wt[n-1] > W)
            {
                return Knapsack(wt, v, W, n - 1);
            }
            else
            {
                //return Math.Max(v[n - 1] + Knapsack(wt, v, W - wt[n - 1], n - 1), Knapsack(wt, v, W, n - 1));
                var a = v[n - 1] + Knapsack(wt, v, W - wt[n - 1], n - 1);
                var b = Knapsack(wt, v, W, n - 1);
                if (a > b)
                {
                    Console.WriteLine(wt[n - 1]);
                    return a;
                }

                return b;
            }
        }

        static int KnapsackDP(int[] wt, int[] v, int W, int n)
        {
            int[,] K = new int[n + 1, W + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        K[i, w] = 0;
                    }
                    else if (wt[i-1] <= w)
                    {
                        K[i, w] = Math.Max(v[i - 1] + K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                    }
                    else
                    {
                        K[i, w] = K[i - 1, w];
                    }
                }
            }

            //return K[n, W];
            var res = K[n, W];
            Console.WriteLine(res);
            var weight = W;
            for (int i = n; i > 0; i--)
            {
                if (res == K[i-1, weight])
                {
                    continue;
                }
                else
                {
                    Console.Write(wt[i - 1] + " ");
                    res = res - v[i - 1];
                    weight = weight - wt[i - 1];
                }
            }
            Console.WriteLine();
            return K[n, W];
        }
    }
}
