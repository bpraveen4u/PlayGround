using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PlayGround
{
    class SortAlgorithms
    {
        public static void Main()
        {
            var arr = new int[] { 4, 3, 9, 6, 1, 5 };
            //BubbleSort(arr);
            //arr.Dump();
            //Console.WriteLine();
            //BubbleSortRecursion(arr, arr.Length);

            //arr.Dump();
            MathTable(9, 0);

            Console.ReadLine();
        }

        static void BubbleSort(int[] arr)
        {
            Console.WriteLine("Buble sort");
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                //arr.Dump();
            }
        }

        static void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }

        static void BubbleSortRecursion(int[] arr, int n)
        {
            if (n > 0)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
                BubbleSortRecursion(arr, n - 1);
            }
        }

        static void MathTable(int n, int i)
        {
            if (i <= 10)
            {
                Console.WriteLine("{0} x {1} = {2}", n, i, n * i);
                MathTable(n, i + 1);
            }
        }
    }
}
