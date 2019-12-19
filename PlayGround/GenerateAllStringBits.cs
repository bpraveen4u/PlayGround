using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class GenerateAllStringBits
    {
        public static void Main()
        {
            Console.WriteLine("N Bits string for given n value");
            NBits(3, new int[3]);

            Console.ReadLine();
        }

        static void NBits(int n, int[] result)
        {
            if (n == 0)
            {
                Console.WriteLine(string.Join(",", result));
            }
            else
            {
                result[n - 1] = 0;
                NBits(n - 1, result);
                result[n - 1] = 1;
                NBits(n - 1, result);
            }
        }
    }
}
