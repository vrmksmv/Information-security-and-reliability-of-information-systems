using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab7
{
    partial class Program
    {
        static Random rand = new Random();
        static Encoding ascii = Encoding.ASCII;

        static void Main(string[] args)
        {
            int maxBigIntegerLengthInBits = 100;
            int z = 8;

            List<BigInteger> privateKeyList = CreatePrivateKeyList(maxBigIntegerLengthInBits, z);
            Console.WriteLine("\nPrivate Key List");
            ShowListBigInteger(privateKeyList);

            BigInteger n = privateKeyList[privateKeyList.Count - 1] * 2 + 1;
            n = GetRandomPrimeBigIntegerBiggerThan(n);
            BigInteger a = 64;
            BigInteger a_inverse = BigInteger.ModPow(a, n - 2, n);
            Console.WriteLine("\n n = " + n + "\n");
            Console.WriteLine("\n a = " + a + "\n");

            List<BigInteger> publicKeyList = CreatePublicKeyList(privateKeyList, a, n);
            Console.WriteLine("\nPublic Key List");
            ShowListBigInteger(publicKeyList);

            string message = "TsvetkovNikolaySergeevich";
            //Get ASCII bytes

            /////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////ASCII
            /////////////////////////////////////////////////////////

            //Encode
            List<BigInteger> encodedMessageASCII = EncodeMessage(message, publicKeyList);
            Console.WriteLine("\nEncoded Message");
            ShowListBigInteger(encodedMessageASCII);

            //Decode
            string decodedMessageASCII = DecodeMessage(encodedMessageASCII, privateKeyList, a_inverse, n);
            Console.WriteLine("\nDecoded Message from ASCII");
            Console.WriteLine(decodedMessageASCII);

            /////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////Base64
            /////////////////////////////////////////////////////////
            z = 8;
            privateKeyList = CreatePrivateKeyList(maxBigIntegerLengthInBits, z);
            Console.WriteLine("\nPrivate Key List");
            ShowListBigInteger(privateKeyList);

            n = privateKeyList[privateKeyList.Count - 1] * 2 + 1;
            n = GetRandomPrimeBigIntegerBiggerThan(n);
            a = 64;
            a_inverse = BigInteger.ModPow(a, n - 2, n);
            Console.WriteLine("\n n = " + n + "\n");
            Console.WriteLine("\n a = " + a + "\n");

            publicKeyList = CreatePublicKeyList(privateKeyList, a, n);
            Console.WriteLine("\nPublic Key List");
            ShowListBigInteger(publicKeyList);

            //Get Base64 string
            string Base64String = Base64Encode(message);
            Console.WriteLine("\nBase64 String");
            Console.WriteLine(Base64String);

            //Encode
            List<BigInteger> encodedMessageBase64 = EncodeMessage(Base64String, publicKeyList);
            Console.WriteLine("\nEncoded Message");
            ShowListBigInteger(encodedMessageBase64);

            //Decode
            string decodedMessageBase64 = DecodeMessage(encodedMessageBase64, privateKeyList, a_inverse, n);
            Console.WriteLine("\nDecoded Message from ASCII");
            Console.WriteLine(decodedMessageBase64);


            Console.WriteLine(Base64Decode(Base64String));



            Console.ReadLine();
        }
    }
}
