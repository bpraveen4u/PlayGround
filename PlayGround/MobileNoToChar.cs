using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;

namespace PlayGround
{
    class MobileNoToChar
    {
        public static void Main()
        {
            Console.WriteLine("Mobile number to string conversion");

            //MobileNoToString("234");
            AllPermutations("2356");
            //TowersProblem(4, "A", "B", "C");

            Console.ReadLine();
        }

        static string[] map = new string[] { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

        static void MobileNoToString(string number)
        {
            MobileNoToStringUtil(number, 0, new char[number.Length]);
        }

        static void MobileNoToStringUtil(string number, int current, char[] result)
        {
            if (number.Length == current)
            {
                Console.WriteLine(new string(result));
                return;
            }

            var numToString = map[number[current] - '0'];
            for (int i = 0; i < numToString.Length; i++)
            {
                result[current] = numToString[i];
                MobileNoToStringUtil(number, current + 1, result);
            }
        }

        static void Iterative(string number)
        {
            char[] result = new char[number.Length];
            for (int j = 0; j < number.Length; j++)
            {
                var numToString = map[number[j]];
                for (int i = 0; i < numToString.Length; i++)
                {
                    result[j] = numToString[i];
                    //MobileNoToStringUtil(number, current + 1, result);
                }
            }
        }

        static void AllPermutations(string input)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char item in input)
            {
                if (map.ContainsKey(item))
                {
                    map[item] = map[item] + 1;
                }
                else
                {
                    map[item] = 1;
                }
            }

            char[] str = new char[map.Count];
            int[] count = new int[map.Count];
            int index = 0;
            foreach (var c in map)
            {
                str[index] = c.Key;
                count[index] = c.Value;
                index++;
            }

            AllPermutationUtil(new string(str), count, 0, new char[input.Length]);
        }

        static void AllPermutationUtil(string str, int[] count, int current, char[] result)
        {
            if (result.Length == current)
            {
                Console.WriteLine(new string(result));
                return;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (count[i] == 0)
                {
                    continue;
                }

                result[current] = str[i];
                count[i]--;
                AllPermutationUtil(str, count, current + 1, result);
                count[i]++;
            }
        }
        
        static void TowersProblem(int n, string source, string dest, string aux)
        {
            if (n == 0)
            {
                return;
            }
            else
            {
                TowersProblem(n - 1, source, aux, dest);
                Console.WriteLine("Move disk {0} from {1} to {2}", n, source, dest);
                TowersProblem(n - 1, aux, dest, source);
            }
        }
    }
}
