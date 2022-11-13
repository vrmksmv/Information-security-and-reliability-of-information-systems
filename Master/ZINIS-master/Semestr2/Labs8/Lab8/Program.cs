using System;
using System.Security.Cryptography;
using System.Text;

namespace Lab8
{
    class Program
    {
        public static void ShowBytes(byte[] bytes)
        {
            foreach (byte item in bytes)
            {
                Console.Write(item.ToString());
            }
            Console.WriteLine();
        }



        static void Main(string[] args)
        {
            try
            {
                //Create a UnicodeEncoder to convert between byte array and string.
                UnicodeEncoding ByteConverter = new UnicodeEncoding();

                //Create byte arrays to hold original, encrypted, and decrypted data.
                byte[] dataToEncrypt = ByteConverter.GetBytes("Tsvetkov Nikolay");
                byte[] encryptedData;
                byte[] decryptedData;

                //Create a new instance of RSACryptoServiceProvider to generate
                //public and private key data.
                using (RSACryptoServiceProvider RSA1 = new RSACryptoServiceProvider())
                {

                    //Pass the data to ENCRYPT, the public key information 
                    //(using RSACryptoServiceProvider.ExportParameters(false),
                    //and a boolean flag specifying no OAEP padding.
                    encryptedData = RSA.RSAEncrypt(dataToEncrypt, RSA1.ExportParameters(false), false);
                    Console.WriteLine("RSA Encrypted Message");
                    ShowBytes(encryptedData);
                    //Pass the data to DECRYPT, the private key information 
                    //(using RSACryptoServiceProvider.ExportParameters(true),
                    //and a boolean flag specifying no OAEP padding.
                    decryptedData = RSA.RSADecrypt(encryptedData, RSA1.ExportParameters(true), false);
                    //Display the decrypted plaintext to the console. 
                    Console.WriteLine("RSA Decrypted text: {0}", ByteConverter.GetString(decryptedData));
                }
            }
            catch (ArgumentNullException)
            {
                //Catch this exception in case the encryption did
                //not succeed.
                Console.WriteLine("Encryption failed.");
            }

            ElGamal elGamal = new ElGamal();

            string encrypted = elGamal.Encrypt("TsvetkovNikolay", "");
            Console.WriteLine(encrypted);

            string decrypted = elGamal.Decrypt(encrypted, "privateKey.txt");
            Console.WriteLine(decrypted);

            Console.ReadLine();
        }
    }
}

