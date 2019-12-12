using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class MergeKSortedArraysRun
    {
        public static void Main()
        {
            Console.WriteLine("Merge K sorted arrays with min heap");

            int[,] A = {{ 1, 5, 8, 9 },
                    { 2, 3, 7, 10 },
                    { 4, 6, 11, 15 },
                    { 9, 14, 16, 19 },
                    { 2, 4, 60, 90 }};
            MergeKSortedArrays m = new MergeKSortedArrays(A.GetLength(0));
            var mksa = new MergeKSortedArrays(A.GetLength(0));
            var res = mksa.merge(A, A.GetLength(0), A.GetLength(1));
            res.Dump();
        }
    }

    class MergeKSortedArrays
    {
        private int size;
        int[] result;
        private MinHeap minHeap;

        public MergeKSortedArrays(int k)
        {
            this.size = k;
            this.minHeap = new MinHeap(k);
        }

        public int[] merge(int[,] A, int k, int n)
        {
            int nk = n * k;
            result = new int[nk];
            int count = 0;
            int[] ptrs = new int[k];
            // create index pointer for every list.
            for (int i = 0; i < ptrs.Length; i++)
            {
                ptrs[i] = 0;
            }
            for (int i = 0; i < k; i++)
            {
                if (ptrs[i] < n)
                {
                    this.minHeap.Insert(A[i, ptrs[i]], i); // insert the element into heap
                }
                else
                {
                    this.minHeap.Insert(int.MaxValue, i); // if any of this list burns out, insert +infinity
                }
            }
            //this.minHeap.Print();
            while (count < nk)
            {
                HeapNode h = this.minHeap.ExtractMin(); // get the min node from the heap.
                                                        //this.minHeap.Print();
                result[count] = h.Data; // store node data into result array
                ptrs[h.ListNumber]++; // increase the particular list pointer
                if (ptrs[h.ListNumber] < n)
                { // check if list is not burns out
                    this.minHeap.Insert(A[h.ListNumber, ptrs[h.ListNumber]], h.ListNumber); // insert the next element from the list
                }
                else
                {
                    this.minHeap.Insert(int.MaxValue, h.ListNumber); // if any of this list burns out, insert +infinity
                }
                count++;
            }
            return result;
        }
    }

}
