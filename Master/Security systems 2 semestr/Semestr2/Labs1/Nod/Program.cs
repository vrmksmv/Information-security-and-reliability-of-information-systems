using System;
using System.Collections.Generic;

namespace Nod
{
    class Program
    {
        static void Main(string[] args)
        {
            int c = 5;
            Console.WriteLine("Приложение для подсчёта НОД 2-ух числе, а также для поиска простых чисел");
            Console.WriteLine();
            
            while (c == 5)
            {
                Console.WriteLine();
                Console.WriteLine("Нажмите");
                Console.WriteLine("1 - Поиск НОД");
                Console.WriteLine("2 - Поиск простых чисел от 1 до n ");
                Console.WriteLine("3 - Поиск простых чисел от m до n ");
                Console.WriteLine("0 - Выход из консоли ");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("Поиск НОД!");
                        Console.Write("Введите a(>0): ");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите b(>0): ");
                        int b = Convert.ToInt32(Console.ReadLine());
                        int result = Nod(a, b);
                        Console.WriteLine("NOD");
                        Console.WriteLine(result);
                        break;
                    case "2":
                        Console.WriteLine("Введите n: ");
                        int z = Convert.ToInt32(Console.ReadLine());
                        Simple(z);
                        break;
                    case "3":
                        Console.WriteLine("Введите n: ");
                        int q = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите m: ");
                        int x = Convert.ToInt32(Console.ReadLine());
                        Simple2(q, x);
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Вы нажали неизвестную букву");
                        break;
                }
            }
        }

    static int Nod(int a, int b) 
        {
            if (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
                return Nod(a,b);
            }
            else
            {
                return a + b;
            }
        }
     
    static void Simple(int z)
        {
            List<int> num = new List<int> { };
            for (int i = 2; i <= z; i++)
            {
                num.Add(i);
            }

            for (int i = 0; i < num.Count; i++)
            {
                for (int j = 2; j < z; j++)
                    num.Remove(num[i] * j);
            }
            if (num.Count != 0)
            {
                Console.WriteLine("Простые числа от 1 до " + z);
                foreach (int w in num)
                {
                    Console.Write(w);
                    Console.Write("; ");
                }
                Console.WriteLine("Количесвто простых чисел: " + num.Count);
            }
            else 
            {
                Console.WriteLine("Простых чисел в данном диапозоне нет!!!");
            }
        }

        
        static void Simple2(int q, int z)
        {
            List<int> num = new List<int> { };
            for (int i = 2; i <= z; i++)
            {
                num.Add(i);
            }

            for (int i = 0; i < num.Count; i++)
            {
                for (int j = 2; j < z; j++)
                    num.Remove(num[i] * j);
            }
            if (num.Count != 0)
            {
                Console.WriteLine("Простые числа от "+ q + " до " + z);
                foreach (int w in num)
                {
                    if (w > q)
                    {
                        Console.Write(w);
                        Console.Write("; ");
                    }
                }
               
            }
            else
            {
                Console.WriteLine("Простых чисел в данном диапозоне нет!!!");
            }
        }

    }
}
