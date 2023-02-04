using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    partial class Program
    {
        static BigInteger modInverse(BigInteger a, BigInteger n)
        {

            for (BigInteger x = 1; x < n; x++)
                if (((a % n) * (x % n)) % n == 1)
                    return x;
            return 1;
        }

        public static BigInteger RandomIntegerBelow(BigInteger N)
        {
            byte[] bytes = N.ToByteArray();
            BigInteger R;

            do
            {
                rand.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte)0x7F; //force sign bit to positive
                R = new BigInteger(bytes);
            } while (R >= N);

            return R;
        }

        static BigInteger GetRandomBigInteger(int length)
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rng.GetBytes(bytes);

            BigInteger value = new BigInteger(bytes);

            if (value.Sign == -1)
                value *= -1;

            return value;
        }

        static BigInteger GetRandomPrimeBigInteger()
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[512 / 8];
            rng.GetBytes(bytes);

            BigInteger value = new BigInteger(bytes);
            Boolean isPrime = false;

            if (value.Sign == -1)
                value *= -1;

            BigInteger biggerValue = value;
            Boolean isBiggerPrime = false;
            BigInteger lowerValue = value;
            Boolean isLowerPrime = false;
            do
            {
                biggerValue++;
                lowerValue--;
                isBiggerPrime = biggerValue.IsProbablyPrime();
                isLowerPrime = lowerValue.IsProbablyPrime();
                Console.WriteLine(biggerValue);
                Console.WriteLine(lowerValue);
            } while (!isBiggerPrime && !isLowerPrime);
            if (isLowerPrime)
                value = lowerValue;
            if (isBiggerPrime)
                value = biggerValue;
            return value;
        }

        static BigInteger GetRandomPrimeBigIntegerBiggerThan(BigInteger than)
        {
            BigInteger value = than;
            Boolean isPrime = false;

            if (value.Sign == -1)
                value *= -1;

            BigInteger biggerValue = value;
            Boolean isBiggerPrime = false;
            do
            {
                biggerValue++;
                isBiggerPrime = biggerValue.IsProbablyPrime();
            } while (!isBiggerPrime);
            if (isBiggerPrime)
                value = biggerValue;
            return value;
        }
    }
}
