using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            string messageString = "Tsvetkov Nikolay";
            Console.WriteLine(messageString);

            //хэшируем сообщение
            SHA512 shaM = new SHA512Managed();
            string messageHash = Encoding.UTF8.GetString(shaM.ComputeHash(Encoding.UTF8.GetBytes(messageString)));
            


            //////RSA
            Console.WriteLine("RSA");
            //подписываем хешированное сообщение
            BigInteger message = new BigInteger(Encoding.UTF8.GetBytes(messageHash));

            RSA.GenerateKeys();
            BigInteger encryptedMessage = RSA.Encrypt(message);

            //дешифруем и сравниваем с хешем
            BigInteger decryptedMessage = RSA.Decrypt(encryptedMessage);

            //проверка подписи
            Console.WriteLine("veryfied = " + (messageHash == (Encoding.UTF8.GetString(decryptedMessage.ToByteArray()))));
            Console.WriteLine("//RSA");
            //////RSA


            //////El Gamal
            Console.WriteLine("El Gamal");

            ElGamal elGamal = new ElGamal();

            string encryptedHash = elGamal.Encrypt(messageHash, "");
            Console.WriteLine(encryptedHash);

            string decryptedHash = elGamal.Decrypt(encryptedHash, "privateKey.txt");
            Console.WriteLine("veryfied = " + (messageHash == decryptedHash));

            Console.WriteLine("//El Gamal");
            //////El Gamal


            //////Shnorr
            Console.WriteLine("Shnorr");

            Console.InputEncoding = Encoding.ASCII;
            var t = DateTime.Now;
            Shnorr.Do();
            Console.WriteLine("Shnorr:" + (DateTime.Now - t));

            //Console.WriteLine("veryfied = " + (hash == hash3));

            Console.WriteLine("//Shnorr");
            //////Shnorr

            Console.ReadLine();
        }
    }
}

