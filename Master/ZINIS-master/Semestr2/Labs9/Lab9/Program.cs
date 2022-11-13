using System;
using System.Security.Cryptography;
using System.Text;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Tsvetkov Nikolay";
            Console.WriteLine(name);
            foreach (var item in Encoding.UTF8.GetBytes(name))
            {
                Console.Write(item.ToString("X"));
            }
            Console.WriteLine();

            SHA512 shaM = new SHA512Managed();
            name = Encoding.UTF8.GetString(shaM.ComputeHash(Encoding.UTF8.GetBytes(name)));
            Console.WriteLine(name);
            foreach (var item in Encoding.UTF8.GetBytes(name))
            {
                Console.Write(item.ToString("X"));
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    
}
}
