using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class TwoSumProblem
    {
        public static void Main()
        {
            Console.WriteLine("sum of two numbers matching the target value");

            var arr = new int[] { 3, 2, 8, 4, 1};
            arr.Dump();
            var res = TwoSum(arr, 6);
            res.Dump();
            Console.ReadLine();
        }

        static int[] TwoSum(int[] num, int target)
        {
            var result = new int[2];
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < num.Length; i++)
            {
                if (map.ContainsKey(target - num[i]))
                {
                    result[0] = map[target - num[i]];
                    result[1] = i;
                }
                map[num[i]] = i;
            }

            return result;
        }
    }
}
