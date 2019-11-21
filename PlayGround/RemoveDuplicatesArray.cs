using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class RemoveDuplicatesArray
    {
        public static void Main()
        {
            Console.WriteLine("remove duplicates in array and insert 0 inplace");

            var arr = new int[] { 1, 1, 2, 2, 2, 4, 4, 5, 5, 5 };
            arr.Dump();
            RemoveDups(arr);
            arr.Dump();

            Console.ReadLine();
        }

        static void RemoveDups(int[] arr)
        {
            int j = 0;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                if (arr[i] != arr[i+1])
                {
                    arr[j++] = arr[i];
                }
            }

            arr[j++] = arr[arr.Length - 1];
            while (j < arr.Length)
            {
                arr[j++] = 0;
            }
        }
    }
}
