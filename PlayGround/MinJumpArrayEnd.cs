using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class MinJumpArrayEnd
    {
        public static void Main()
        {
            Console.WriteLine("Minimum jumps to reach end of the array, each array index representing max jumps can be taken");

            var arr = new int[] { 1, 3, 5, 3, 2, 2, 6, 1, 6, 8, 9 };
             //{ 2, 3, 1, 1, 4 };
            arr.Dump();
            var res = MinJumpEnd(arr);
            Console.WriteLine(res);
            Console.ReadLine();
        }

        static int MinJumpEnd(int[] arr)
        {
            int[] result = new int[arr.Length];
            int[] jumps = new int[arr.Length];
            jumps[0] = 0;
            for (int i = 1; i < jumps.Length; i++)
            {
                jumps[i] = int.MaxValue;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (j + arr[j] >= i)
                    {
                        if (jumps[j] + 1 < jumps[i])
                        {
                            result[i] = j;
                            jumps[i] = jumps[j] + 1;
                        }
                    }
                }
            }

            //jumps.Dump();
            //result.Dump();

            string res = arr[arr.Length - 1].ToString();
            int k = arr.Length - 1;
            while (k > 0)
            {
                res = arr[result[k]] + " -> " + res;
                k = result[k];
            }

            Console.WriteLine(res);

            return jumps[arr.Length - 1];
        }
    }
}
