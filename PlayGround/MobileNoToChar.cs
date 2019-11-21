using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PlayGround
{
    class MobileNoToChar
    {
        public static void Main()
        {
            Console.WriteLine("Mobile number to string conversion");

            MobileNoToString("234");

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
    }
}
