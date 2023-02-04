using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    partial class Program
    {
        static void ShowListBigInteger(List<BigInteger> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
                Console.WriteLine();
            }
        }

        static void ShowListChar(List<char> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
                Console.WriteLine();
            }
        }

        static int GetIntFromString(string str)
        {
            int ret = 0;
            int bit = 1;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == '1')
                    ret += bit;
                bit *= 2;
            }
            return ret;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.ASCII.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.ASCII.GetString(base64EncodedBytes);
        }

        static BigInteger GetNOD(BigInteger a, BigInteger b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a = a % b;
                else
                    b = b % a;
            }
            return (a != 0 ? a : b);
        }

    }
}
