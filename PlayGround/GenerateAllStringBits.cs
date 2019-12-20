using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    class GenerateAllStringBits
    {
        public static void Main()
        {
            Console.WriteLine("N Bits string for given n value");
            NBits(4, new int[4]);
            var arr = new int[] { 0, 1, 1, 1 };
            Reverse(arr);
            DecToBinary(17);
            Console.WriteLine();
            BecToBinaryBits(5);
            Console.ReadLine();
        }

        static void NBits(int n, int[] result)
        {
            if (n == 0)
            {
                int[] clone = (int[])result.Clone();
                Reverse(clone);
                Console.WriteLine(string.Join("", clone));
            }
            else
            {
                result[n - 1] = 0;
                NBits(n - 1, result);
                result[n - 1] = 1;
                NBits(n - 1, result);
            }
        }

        static void Reverse(int[] items)
        {
            int i = 0;
            int j = items.Length - 1;
            while (i < j)
            {
                var temp = items[i];
                items[i] = items[j];
                items[j] = temp;
                i++;
                j--;
            }

            return;
        }

        static void DecToBinary(int n)
        {
            // array to store binary number 
            int[] binaryNum = new int[32];

            // counter for binary array 
            int i = 0;
            while (n > 0)
            {
                // storing remainder in 
                // binary array 
                binaryNum[i] = n % 2;
                n = n / 2;
                i++;
            }

            // printing binary array 
            // in reverse order 
            for (int j = i - 1; j >= 0; j--)
                Console.Write(binaryNum[j]);
        }

        static void BecToBinaryBits(int n)
        {
            // Size of an integer is assumed to be 32 bits 
            for (int i = 31; i >= 0; i--)
            {
                int k = n >> i;
                if ((k & 1) > 0)
                    Console.Write("1");
                else
                    Console.Write("0");
            }
        }

        public static char[] Base64Encoding(byte[] data)
        {
            int length, length2;
            int blockCount;
            int paddingCount;

            length = data.Length;

            if ((length % 3) == 0)
            {
                paddingCount = 0;
                blockCount = length / 3;
            }
            else
            {
                paddingCount = 3 - (length % 3);
                blockCount = (length + paddingCount) / 3;
            }

            length2 = length + paddingCount;

            byte[] source2;
            source2 = new byte[length2];

            for (int x = 0; x < length2; x++)
            {
                if (x < length)
                {
                    source2[x] = data[x];
                }
                else
                {
                    source2[x] = 0;
                }
            }

            byte b1, b2, b3;
            byte temp, temp1, temp2, temp3, temp4;
            byte[] buffer = new byte[blockCount * 4];
            char[] result = new char[blockCount * 4];

            for (int x = 0; x < blockCount; x++)
            {
                b1 = source2[x * 3];
                b2 = source2[x * 3 + 1];
                b3 = source2[x * 3 + 2];

                temp1 = (byte)((b1 & 252) >> 2);

                temp = (byte)((b1 & 3) << 4);
                temp2 = (byte)((b2 & 240) >> 4);
                temp2 += temp;

                temp = (byte)((b2 & 15) << 2);
                temp3 = (byte)((b3 & 192) >> 6);
                temp3 += temp;

                temp4 = (byte)(b3 & 63);

                buffer[x * 4] = temp1;
                buffer[x * 4 + 1] = temp2;
                buffer[x * 4 + 2] = temp3;
                buffer[x * 4 + 3] = temp4;

            }

            for (int x = 0; x < blockCount * 4; x++)
            {
                result[x] = SixBitToChar(buffer[x]);
            }

            switch (paddingCount)
            {
                case 0:
                    break;
                case 1:
                    result[blockCount * 4 - 1] = '=';
                    break;
                case 2:
                    result[blockCount * 4 - 1] = '=';
                    result[blockCount * 4 - 2] = '=';
                    break;
                default:
                    break;
            }

            return result;
        }

        private static char SixBitToChar(byte b)
        {
            char[] lookupTable = new char[64] {
        'A','B','C','D','E','F','G','H','I','J','K','L','M',
        'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
        'a','b','c','d','e','f','g','h','i','j','k','l','m',
        'n','o','p','q','r','s','t','u','v','w','x','y','z',
        '0','1','2','3','4','5','6','7','8','9','+','/'
                };

            if ((b >= 0) && (b <= 63))
            {
                return lookupTable[(int)b];
            }
            else
            {
                return ' ';
            }
        }
    }
}
