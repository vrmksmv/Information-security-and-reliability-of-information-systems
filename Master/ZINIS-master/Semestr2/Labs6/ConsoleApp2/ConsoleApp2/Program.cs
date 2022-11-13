using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sWatch = new Stopwatch();
            for (; ; )
            {
                Console.WriteLine("Выберите операцию");
                Console.WriteLine("1. RC4");
                Console.WriteLine("2. RSA");
                Console.WriteLine("3. Генератор ПСП на основе регистров сдвига. (4-3-1-0)");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:                      
                        sWatch.Start();
                        byte[] keys = ASCIIEncoding.ASCII.GetBytes("122");
                        RC4 encoder = new RC4(keys);
                        string testString = "Salimon Paul Dmitrievich";
                        byte[] testBytes = ASCIIEncoding.ASCII.GetBytes(testString);
                        byte[] result = encoder.Encode(testBytes, testBytes.Length);
                        string encryptedString = ASCIIEncoding.ASCII.GetString(result);
                        Console.WriteLine(encryptedString);
                        RC4 decoder = new RC4(keys);
                        byte[] decryptedBytes = decoder.Decode(result, result.Length);
                        string decryptedString = ASCIIEncoding.ASCII.GetString(decryptedBytes);
                        Console.WriteLine(decryptedString);
                        sWatch.Stop();
                        Console.WriteLine("Время выполнения");
                        Console.WriteLine(sWatch.ElapsedMilliseconds.ToString() + "мс");
                        break;
                    case 2:
                        Console.WriteLine("p = 113");
                        long ps = 113;
                        Console.WriteLine("n = 211");
                        long n = 211;
                        sWatch.Start();
                        RSA rsa = new RSA();
                        rsa.Encrypt(ps, n);
                        rsa.Decrypt();
                        sWatch.Stop();
                        Console.WriteLine("Время выполнения");
                        Console.WriteLine(sWatch.ElapsedMilliseconds.ToString() + "мс");
                        break;
                    case 3:
                        String text;
                        using (StreamReader sr = new StreamReader("sdvigin.txt", System.Text.Encoding.ASCII, false))
                        {
                            text = sr.ReadLine();
                        }
                        lfsr t1 = new lfsr(text, 0, "10001110101011101110000111");
                        Console.WriteLine("Текст: {0}", t1.CleanText);
                        Console.WriteLine("Ключ: {0}", t1.Key);
                        Console.WriteLine("Последовательность текста: {0}", t1.TextKey);
                        Console.WriteLine("Зашифрованный текст: {0}", t1.EncryptedText);
                        Console.WriteLine("Расшифрованный текст: {0}", t1.DecryptedText);
                        Console.Read();
                        using (StreamWriter sw = new StreamWriter("outsdvigout.txt"))
                        {
                            sw.WriteLine(t1.EncryptedText);
                            sw.WriteLine(t1.DecryptedText);
                        }
                            break;
                    case 45:
                        sWatch.Start();
                        var strIn = "Salimon Pavel Smitr";
                        var p = Numbers.GetNextPrimeAfter(1);
                        var g = Numbers.GetPRoot(p);
                        var x = Numbers.Rand(1, p - 1);
                        ElGamal elGamal = new ElGamal();
                        elGamal.Crypt(p, g, x, strIn);                       
                        elGamal.Decrypt(p, x);
                        sWatch.Stop();
                        Console.WriteLine("Время выполнения");
                        Console.WriteLine(sWatch.ElapsedMilliseconds.ToString() + "мс");
                        break;
                    case 55:
                        sWatch.Start();
                        testSpeedRand();
                        sWatch.Stop();
                        Console.WriteLine(sWatch.ElapsedMilliseconds.ToString() + "мс");
                        sWatch.Reset();
                        sWatch.Start();
                        testSpeedRandStandart();
                        sWatch.Stop();
                        Console.WriteLine(sWatch.ElapsedMilliseconds.ToString() + "мс");
                        break;
                    default:
                        Console.WriteLine("Введите корректные данные");
                        break;
                }
            }
        }
        private static void testSpeedRandStandart()
        {
            var rnd = new Random();
            for (var n = 0; n < 100000000; n++)
                rnd.Next();
        }
        private static  void testSpeedRand()
        {
            var rnd = new Rnd();
            for (var n = 0; n < 100000000; n++)
                rnd.Next();
        }
    }
}
