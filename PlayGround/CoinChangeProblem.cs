using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class CoinChangeProblem
    {
        public static void Main()
        {
            Console.WriteLine("Coin change problem.");

            int total = 6;
            int[] coins = { 1, 2, 3, 4 };
            //Dictionary<int, int> map = new Dictionary<int, int>();
            //int topDownValue = MinCoinTopDown(total, coins, map);
            //int bottomUpValue = MinimumCoinBottomUp(total, coins);
            int count = 0;
            CoinChangeSolutions(coins, total, 0, new List<int>(), ref count);
            Console.WriteLine(count);
            CN(coins, total, 0, new List<int>());
            Console.WriteLine("DP");//same as knapsack problem
            var s = CoinChangeWaysDP(6, coins);
            Console.WriteLine(s);
            //Console.WriteLine(String.Format("Bottom up and top down result {0} {1}", bottomUpValue, topDownValue));

            Console.ReadLine();
        }

        static void CoinChangeSolutions(int[] coins, int total, int current, List<int> result, ref int count)
        {
            if (total == 0)
            {
                count++;
                Console.WriteLine(string.Join("-", result));
            }
            for (int i = current; i < coins.Length; i++)
            {
                if (total >= coins[i])
                {
                    result.Add(coins[i]);
                    CoinChangeSolutions(coins, total - coins[i], i, result, ref count);
                    result.Remove(coins[i]);
                }
            }
        }

        static int MinCoinTopDown(int total, int[] coins, Dictionary<int, int> map)
        {
            //total is 0 there is nothing to do
            if (total == 0)
            {
                return 0;
            }

            if (map.ContainsKey(total))
            {
                return map[total];
            }

            int min = int.MaxValue;
            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i] > total)
                {
                    continue;
                }

                int val = MinCoinTopDown(total - coins[i], coins, map);
                if (val < min)
                {
                    min = val;
                }
            }

            //if min is MAX_VAL dont change it. Just result it as is. Otherwise add 1 to it.
            min = (min == int.MaxValue ? min : min + 1);

            //memoize the minimum for current total.
            map.Add(total, min);
            return min;

        }

        /**
        * Bottom up way of solving this problem.
        * Keep input sorted. Otherwise temp[j-arr[i]) + 1 can become Integer.Max_value + 1 which
        * can be very low negative number
        * Returns Integer.MAX_VALUE - 1 if solution is not possible.
        */
        static int MinimumCoinBottomUp(int total, int[] coins)
        {
            int[] T = new int[total + 1];
            int[] R = new int[total + 1];
            T[0] = 0;
            for (int i = 1; i <= total; i++)
            {
                T[i] = int.MaxValue - 1;
                R[i] = -1;
            }
            for (int j = 0; j < coins.Length; j++)
            {
                for (int i = 1; i <= total; i++)
                {
                    if (i >= coins[j])
                    {
                        if (T[i - coins[j]] + 1 < T[i])
                        {
                            T[i] = 1 + T[i - coins[j]];
                            R[i] = j;
                        }
                    }
                }
            }
            PrintCoinCombination(R, coins);
            return T[total];
        }

        static void PrintCoinCombination(int[] R, int[] coins)
        {
            if (R[R.Length - 1] == -1)
            {
                Console.WriteLine("No solution is possible");
                return;
            }
            int start = R.Length - 1;
            Console.WriteLine("Coins used to form total ");
            while (start != 0)
            {
                int j = R[start];
                Console.WriteLine(coins[j] + " ");
                start = start - coins[j];
            }
            Console.WriteLine();
        }

        static void CN(int[] coins, int total, int current, List<int> result)
        {
            if (total == 0)
            {
                Console.WriteLine(string.Join("-", result));
                return;
            }

            for (int i = current; i < coins.Length; i++)
            {
                if (total >= coins[i])
                {
                    result.Add(coins[i]);
                    CN(coins, total - coins[i], i, result);
                    result.Remove(coins[i]);
                }
            }
        }

        static int CoinChangeWaysDP(int amount, int[] coins)
        {

            /*
              Each row represents using the denominations up to that point in
              the denominations array (see the video explanation)
            */
            int[,] dp = new int[coins.Length + 1, amount + 1];

            /*
              Max ways to make change for 0 will be 1, doing nothing.
            */
            dp[0, 0] = 1;

            for (int i = 1; i <= coins.Length; i++)
            {
                /*
                  Set the subproblem for the amount of 0 to 1 when
                  solving this row
                */
                dp[i, 0] = 1;

                for (int j = 1; j <= amount; j++)
                {
                    int currentCoinValue = coins[i - 1];

                    /*
                      dp[i,j] will be the sum of the ways to make change not considering
                      this coin (dp[i-1,j]) and the ways to make change considering this
                      coin (dp[i,j] - currentCoinValue] ONLY if currentCoinValue <= j, otherwise
                      this coin can not contribute to the total # of ways to make change at this
                      sub problem target amount)
                    */
                    int withoutThisCoin = dp[i - 1, j];
                    int withThisCoin = 0;
                    if (currentCoinValue <= j)
                    {
                        withThisCoin = dp[i, j - currentCoinValue];
                    }
                    //int withThisCoin = currentCoinValue <= j ? dp[i,j - currentCoinValue] : 0;

                    dp[i, j] = withoutThisCoin + withThisCoin;
                }
            }

            /*
              The answer considering ALL coins for the FULL amount is what
              we want to return as the answer
            */
            dp.Dump();
            return dp[coins.Length, amount];
        }


    }
}
