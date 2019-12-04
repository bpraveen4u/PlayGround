using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class BinarySearchProblems
    {
        public static void Main()
        {
            Console.WriteLine("Binary Search");
            var items = new int[] { 1, 4, 6, 8, 20, 23, 34, 45 };
            var res = BinarySearch(items, 45);
            Console.WriteLine(res);

            res = BinarySearchIterative(items, 45);
            Console.WriteLine(res);

            items = new int[] { 23, 34, 45, 1, 4, 6, 8, 20, 21 };
            items = new int[] { 23, 34, 45, 51, 54, 61, 68, 20, 21 };
            res = BinarySearchInCircularSortedArray(items, 54);
            Console.WriteLine(res);

            Console.ReadLine();
        }

        static int BinarySearch(int[] arr, int no)
        {
            return BinarySearchUtil(arr, no, 0, arr.Length - 1);
        }

        static int BinarySearchUtil(int[] arr, int no, int low, int high)
        {
            var mid = (low + high) / 2;
            if (arr[mid] == no)
            {
                return mid;
            }
            else if (no < arr[mid])
            {
                return BinarySearchUtil(arr, no, low, mid - 1);
            }
            else
            {
                return BinarySearchUtil(arr, no, mid + 1, high);
            }
        }

        static int BinarySearchIterative(int[] arr, int no)
        {
            int low = 0;
            int high = arr.Length - 1;
            int mid = -1;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (arr[mid] == no)
                {
                    return mid;
                }
                else if (no < arr[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }

        static int BinarySearchInCircularSortedArray(int[] arr, int no)
        {
            int low = 0;
            int high = arr.Length - 1;
            int mid = -1;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (arr[mid] == no)
                {
                    return mid;
                }

                if (arr[mid] <= arr[high])
                {
                    // compare target with A[mid] and A[high] to know
                    // if it lies in A[mid..high] or not
                    if (no > arr[mid] && no <= arr[high])
                        low = mid + 1;  // go searching in right sorted half
                    else
                        high = mid - 1;	// go searching left
                }
                else
                {
                    // compare target with A[low] and A[mid] to know
                    // if it lies in A[low..mid] or not
                    if (no >= arr[low] && no < arr[mid])
                        high = mid - 1; // go searching in left sorted half
                    else
                        low = mid + 1;	// go searching right
                }
            }

            return -1;
        }
    }
}
