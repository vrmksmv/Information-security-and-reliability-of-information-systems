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
        static List<BigInteger> CreatePrivateKeyList(int maxBigIntegerLengthInBits, int z)
        {
            List<BigInteger> privateKeyList = new List<BigInteger>();
            privateKeyList.Add(GetRandomBigInteger(maxBigIntegerLengthInBits));

            for (int i = 1; i < z; i++)
            {
                privateKeyList.Insert(
                    0,
                    privateKeyList[privateKeyList.Count - i] % 2 == 1 ?
                    ((privateKeyList[privateKeyList.Count - i] - 1) / 2 - 1) : (privateKeyList[privateKeyList.Count - i] / 2 - 1));
            }
            return privateKeyList;
        }

        static List<BigInteger> CreatePublicKeyList(List<BigInteger> privateKeyList, BigInteger a, BigInteger n)
        {
            List<BigInteger> publicKeyList = new List<BigInteger>();
            publicKeyList.AddRange(privateKeyList);
            for (int i = 0; i < publicKeyList.Count; i++)
            {
                publicKeyList[i] = (publicKeyList[i] * a) % n;
            }
            return publicKeyList;
        }
        static List<BigInteger> EncodeMessage(string message, List<BigInteger> publicKeyList)
        {
            List<Byte> Bytes = ascii.GetBytes(message).ToList();
            List<BigInteger> encodedMessageASCII = new List<BigInteger>();
            foreach (var item in Bytes)
            {
                string symbol = Convert.ToString(item, 2);
                BigInteger weight = 0;
                for (int i = 0; i < symbol.Length; i++)
                {
                    if (symbol[symbol.Length - 1 - i] == '1')
                        weight += publicKeyList[publicKeyList.Count - 1 - i];
                }
                encodedMessageASCII.Add(weight);
            }
            return encodedMessageASCII;
        }
        static string DecodeMessage(List<BigInteger> encodedMessage, List<BigInteger> privateKeyList, BigInteger a_inverse, BigInteger n)
        {
            List<string> symbols = new List<string>();
            for (int i = 0; i < encodedMessage.Count; i++)
            {
                string symbol = "";
                BigInteger decodedCode = (encodedMessage[i] * a_inverse) % n;
                for (int j = 0; decodedCode != 0; j++)
                {
                    if (decodedCode - privateKeyList[privateKeyList.Count - 1 - j] >= 0)
                    {
                        decodedCode -= privateKeyList[privateKeyList.Count - 1 - j];
                        symbol = '1' + symbol;
                    }
                    else
                    {
                        symbol = '0' + symbol;
                    }
                }
                symbol = symbol.PadLeft(8, '0');
                symbols.Add(symbol);
            }

            List<byte> symbolsCodes = new List<byte>();
            for (int i = 0; i < symbols.Count; i++)
            {
                symbolsCodes.Add((byte)GetIntFromString(symbols[i]));
            }

            string decodedMessage = "";
            foreach (var item in ascii.GetChars(symbolsCodes.ToArray()))
            {
                decodedMessage += item;
            }
            return decodedMessage;
        }

        static List<BigInteger> EncodeMessageBase64(string message, List<BigInteger> publicKeyList)
        {
            List<Byte> Bytes = Encoding.UTF8.GetBytes(message).ToList();
            List<BigInteger> encodedMessageASCII = new List<BigInteger>();
            foreach (var item in Bytes)
            {
                string symbol = Convert.ToString(item, 2);
                BigInteger weight = 0;
                for (int i = 0; i < symbol.Length; i++)
                {
                    if (symbol[symbol.Length - 1 - i] == '1')
                        weight += publicKeyList[publicKeyList.Count - 1 - i];
                }
                encodedMessageASCII.Add(weight);
            }
            return encodedMessageASCII;
        }
        static string DecodeMessageBase64(List<BigInteger> encodedMessage, List<BigInteger> privateKeyList, BigInteger a_inverse, BigInteger n)
        {
            List<string> symbols = new List<string>();
            for (int i = 0; i < encodedMessage.Count; i++)
            {
                string symbol = "";
                BigInteger decodedCode = (encodedMessage[i] * a_inverse) % n;
                for (int j = 0; decodedCode != 0; j++)
                {
                    if (decodedCode - privateKeyList[privateKeyList.Count - 1 - j] >= 0)
                    {
                        decodedCode -= privateKeyList[privateKeyList.Count - 1 - j];
                        symbol = '1' + symbol;
                    }
                    else
                    {
                        symbol = '0' + symbol;
                    }
                }
                symbol = symbol.PadLeft(8, '0');
                symbols.Add(symbol);
            }

            List<byte> symbolsCodes = new List<byte>();
            for (int i = 0; i < symbols.Count; i++)
            {
                symbolsCodes.Add((byte)GetIntFromString(symbols[i]));
            }

            string decodedMessage = "";
            foreach (var item in Encoding.UTF8.GetChars(symbolsCodes.ToArray()))
            {
                decodedMessage += item;
            }
            return decodedMessage;
        }
    }
}
