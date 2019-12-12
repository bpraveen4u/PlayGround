using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class SearchInsertDeleteGetRandomInConstantTime
    {
        public static void Main()
        {
            Console.WriteLine("Design a data structure that supports insert, delete, search and getRandom in constant time\nhttps://www.geeksforgeeks.org/design-a-data-structure-that-supports-insert-delete-search-and-getrandom-in-constant-time/");

            var fds = new FastDataStructure();
            fds.Add(45);
            fds.Add(5);
            fds.Add(4);
            fds.Add(40);
            fds.Add(39);
            fds.Add(38);
            fds.Remove(40);
            var r = fds.GetRandom();
            r = fds.GetRandom();
            var s = fds.Search(40);
            var k = fds.Search(70);
            Console.ReadLine();
        }
    }

    class FastDataStructure
    {
        Dictionary<int, int> map;
        //int[] arr;
        List<int> arrList;
        public FastDataStructure()
        {
            this.map = new Dictionary<int, int>();
            //this.arr = new int[1];
            arrList = new List<int>();
        }

        public void Add(int item)
        {
            // If element is already present, then noting to do
            if (map.ContainsKey(item))
            {
                return;
            }
            // Else put element at the end of arr[] 
            //int lastIndex = arr.Length - 1;
            //arr[lastIndex] = item;
            var lastIndex = arrList.Count;
            arrList.Add(item);

            // And put in hash also
            map[item] = lastIndex;
        }

        public void Remove(int item)
        {
            if (!map.ContainsKey(item))
            {
                return;
            }
            var index = map[item];
            map.Remove(item);

            // Swap element with last element so that remove from 
            // arr[] can be done in O(1) time 
            var lastIndex = arrList.Count - 1;
            var lastItem = arrList[lastIndex];
            //swap
            var temp = arrList[index];
            arrList[index] = arrList[lastIndex];
            arrList[lastIndex] = temp;

            arrList.RemoveAt(lastIndex);

            map[lastItem] = index;
        }

        public int Search(int item)
        {
            if (map.ContainsKey(item))
            {
                return map[item];
            }

            return -1;
        }

        public int GetRandom()
        {
            // Find a random index from 0 to size - 1 
            Random rand = new Random();  // Choose a different seed 
            int index = rand.Next(0, arrList.Count - 1);

            // Return element at randomly picked index 
            return arrList[index];
        }
    }
}
