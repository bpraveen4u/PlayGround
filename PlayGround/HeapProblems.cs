using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class HeapProblems
    {
        public static void Main()
        {
            Console.WriteLine("Min Heap - complete logic");

            MinHeap minHeap = new MinHeap(5);
            minHeap.Insert(3, 0);
            minHeap.Insert(1, 0);
            minHeap.Insert(10, 0);
            minHeap.Insert(0, 0);
            minHeap.Insert(12, 0);
            minHeap.Print();

            var min = minHeap.ExtractMin();
            Console.WriteLine(min.Data);
            minHeap.Insert(13, 0);
            minHeap.Print();

            min = minHeap.ExtractMin();
            Console.WriteLine(min.Data);
            minHeap.Print();

            Console.ReadLine();
        }
    }

    public class MinHeap
    {
        HeapNode[] minHeap;
        int position;

        public MinHeap(int size)
        {
            this.minHeap = new HeapNode[size];
            this.position = -1;
        }

        public void Insert(int data, int listNumber)
        {
            if (this.position < 0)
            {
                this.minHeap[++this.position] = new HeapNode(data, listNumber);
            }
            else
            {
                this.minHeap[++this.position] = new HeapNode(data, listNumber);
                this.BubbleUp();
            }
        }

        public void BubbleUp()
        {
            var pos = this.position;
            var parent = (pos - 1) / 2;
            while (pos > 0 && this.minHeap[parent].Data > this.minHeap[pos].Data)
            {
                //swap
                HeapNode node = this.minHeap[parent];
                this.minHeap[parent] = this.minHeap[pos];
                this.minHeap[pos] = node;
                pos = parent;
                parent = (pos - 1) / 2;
            }
        }

        private void Swap(int a, int b)
        {
            //  System.out.println("swappinh" + mH[a] + " and " + mH[b]);
            HeapNode temp = this.minHeap[a];
            this.minHeap[a] = this.minHeap[b];
            this.minHeap[b] = temp;
        }

        private void SinkDown(int k)
        {
            int smallest = k;
            var left = (2 * k) + 1;
            var right = (2 * k) + 2;
            if (((left <= this.position) && (this.minHeap[smallest].Data > this.minHeap[left].Data)))
            {
                //left child
                smallest = left;
            }

            if (((right <= this.position) && (this.minHeap[smallest].Data > this.minHeap[right].Data)))
            {
                //right child
                smallest = right;
            }

            if ((smallest != k))
            {
                //  if any if the child is small, swap
                this.Swap(k, smallest);
                this.SinkDown(smallest);
                //  call recursively
            }
        }
        public HeapNode ExtractMin()
        {
            //return minHeap[0];
            var min = minHeap[0];
            if (this.position > 0)
            {
                minHeap[0] = minHeap[position];
                minHeap[position] = null;
                position--;
            }

            this.SinkDown(0);

            return min;
        }

        public void Print()
        {
            for (int i = 0; i <= this.position; i++)
            {
                Console.Write("[{0},{1}] ", this.minHeap[i].Data, this.minHeap[i].ListNumber);
            }
            Console.WriteLine();
        }
    }

    public class HeapNode
    {
        public int Data { get; set; }

        public int ListNumber { get; set; }

        public HeapNode(int data, int listNumber)
        {
            this.Data = data;
            this.ListNumber = listNumber;
        }
    }
}
