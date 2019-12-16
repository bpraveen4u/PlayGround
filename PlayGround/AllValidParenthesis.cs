using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class AllValidParenthesis
    {
        public static void Main()
        {
            Console.WriteLine("Find all combination of paranthesis for given value N");
            int n = 8;
            ValidParenthisis(n / 2, n / 2, string.Empty);
            Console.ReadLine();
        }

        static void ValidParenthisis(int openParenthesis, int closedParanthesis, string result)
        {
            if (openParenthesis == 0 && closedParanthesis == 0)
            {
                Console.WriteLine(result);
            }

            if (openParenthesis > closedParanthesis)
            {
                return;
            }

            if (openParenthesis > 0)
            {
                ValidParenthisis(openParenthesis - 1, closedParanthesis, result + "(");
            }

            if (closedParanthesis > 0)
            {
                ValidParenthisis(openParenthesis, closedParanthesis - 1, result + ")");
            }
        }
    }
}
