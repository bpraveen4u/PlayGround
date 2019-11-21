using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PlayGround
{
    public static class Extensions
    {
        public static void Dump<T>(this T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(items[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
