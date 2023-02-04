﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4_Код_Хэмминга
{
    class Program
    {
        static void Main(string[] args)
        {

            string str;
            string binaryString;
            do
            {
                Console.Clear();
                Console.Write("Введите строку: ");
                str = Console.ReadLine();
                binaryString = ToBinary(ConvertToByteArray(str, Encoding.ASCII));
                Console.WriteLine("\nВаша строка в кодах ASCII: "+binaryString);
            }
            while (str.Length < 2);


            int k = binaryString.Length;
            int r = LenghtHemminga(k);
            int n = k + r;

            int[] mas = new int[binaryString.Length + r];
            int[,] checkMatrix = new int[n, r];

            int error;

            //Преобразование строки в массив
            mas = StrInMas(binaryString, k);
            Console.Write("\nВходная строка ");
            OutMass(mas, k);

            //Получение проверочной матрицы
            checkMatrix = CheckMatrix(k);



            Console.WriteLine("\nПроверочная матрица");
            OutMass(checkMatrix, k);

            //Добавление проверочных битов
            Sindrom(checkMatrix, mas, k);
            

            Console.WriteLine("\nПолная строка");
            OutMass(mas, k);

            try
            {
                Console.WriteLine("Введите номер бита первой ошибки");
                error = Convert.ToInt32(Console.ReadLine()) - 1;
                if (mas[error] == 1) mas[error] = 0;
                else mas[error] = 1;

                Console.WriteLine("Введите номер бита второй ошибки");
                error = Convert.ToInt32(Console.ReadLine()) - 1;
                if (mas[error] == 1) mas[error] = 0;
                else mas[error] = 1;
            }
            catch { }

            Console.WriteLine("\nСтрока с ошибкой");
            OutMass(mas, k);

            Console.WriteLine("\nСтрока с вектором ошибки");
            mas = SearchError(mas, checkMatrix, k);
            Console.WriteLine("\nСтрока без ошибки");
            OutMass(mas, k);


        }

        //Считаем r (кол-во пров. симв.)
        public static int LenghtHemminga(int k)
        {
            int r = (int)(Math.Log(k, 2) + 1.99f);
            return r;
        }

        //Создание пров. матрицы
        public static int [,] CheckMatrix(int k)
        {
            int r = LenghtHemminga(k);
            int n = r + k;
            double rDouble = r-1;
            int rPow = (int)(Math.Pow(2, rDouble));

            int[,] mas = new int[n, r];

            int[,] combinations = new int[rPow, r];

            for (int i = 0; i < rPow; i++)
                for (int j = 0; j < r; j++)
                    combinations[i, j] = 0;

            //генератор бит.мн.
            for (int segmentLenght = 0; segmentLenght < r - 2; segmentLenght++)
            {
                if (segmentLenght * r > k) break;

                for (int i = 0; i < segmentLenght + 2; i++)
                {
                    combinations[segmentLenght * r, i] = 1;
                }

                for (int segmentPositin = 1; segmentPositin < r; segmentPositin++)
                {
                    for (int i = 0; i < r - 1; i++)
                    {
                        combinations[segmentLenght * r + segmentPositin, i + 1] = combinations[segmentLenght * r + segmentPositin - 1, i];
                    }
                    combinations[segmentLenght * r + segmentPositin, 0] = combinations[segmentLenght * r + segmentPositin - 1, r - 1];
                }

                if (segmentLenght == r - 3)
                {
                    for (int i = 0; i < r; i++)
                    {
                        combinations[rPow - 1, i] = 1;
                    }
                }
            }


            
            for (int i = 0; i < k; i++)
                for (int j = 0; j < r; j++)
                    mas[i, j] = combinations[i, j];
                    
           for (int i = 0; i < r; i++)
                mas[i+k, i] = 1;

            return mas;
        }

        //Поиск синдрома
        public static int [] Sindrom(int [,] CheckMatrix, int [] mas, int k)
        {

            int r = LenghtHemminga(k);
            int n = r + k;
            int[] sindrom = new int[r];



            for (int i = 0, l = 0; i < r; i++, l = 0)
            {
                for (int j = 0; j < k; j++)
                {
                    if (CheckMatrix[j, i] == 1 && mas[j] == 1) l++; 
                    else sindrom[i] = 0;
                }
                if (l % 2 == 1) sindrom[i] = 1;
                else sindrom[i] = 0;
            }

            for (int i = 0; i < r; i++)
            {
                mas[i + k] = sindrom[i];
            }


            return mas;
        }

        //Нахождение ошибок
        public static int[] SearchError(int[] mas, int[,] checkMatrix, int k)
        {

            int r = LenghtHemminga(k);
            int n = r + k;

            int[] beforeSindrom = new int[r];

            //запоминаем проверочные биты
            for (int i = k; i < n; i++)
            {
                beforeSindrom[i - k] = mas[i];
            }

            mas = Sindrom(checkMatrix, mas, k);

            //Складываем синдром по модулю два
            for (int i = k, j = 0; i < n; i++)
            {
                if (beforeSindrom[i - k].Equals(mas[i]))
                {
                    mas[i] = 0;

                    j++;
                    //если сумма по модулю два все пров. бит равна нулю
                    if (j == r)
                    {
                        for (int l = k; l < n; l++)
                        {
                            mas[l] = beforeSindrom[l - k];
                        }
                        return mas;
                    }
                }
                else
                {
                    mas[i] = 1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                int l = 0;
                for (int j = 0; j < r; j++)
                {
                    if (checkMatrix[i, j].Equals(mas[j + k])) l++;
                }
                if (l == r)
                {
                    mas[i] = (mas[i] + 1) % 2;
                }
            }
            OutMass(mas, k);
            mas = Sindrom(checkMatrix, mas, k);

            return mas;
        }

        //Преобразование строки в массив
        public static int [] StrInMas(string binaryString, int k)
        {
            int r = LenghtHemminga(k);
            int[] mas = new int[binaryString.Length + r];

            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] == 49)
                    mas[i] = 1;
                else mas[i] = 0;
            }
            return mas;
        }

        //вывод матрицы
        public static void OutMass(int [,] mas, int k)
        {
            int r = LenghtHemminga(k);
            int n = r + k;

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mas[j, i]);
                    if (j + 1 == k) Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        //вывод одномерного массива
        public static void OutMass(int [] mas, int k)
        {
            int n = LenghtHemminga(k) + k;

            for (int i = 0; i < n; i++)
            {
                if (i == k) Console.Write("|");
                Console.Write(mas[i]);
            }
            Console.WriteLine("\n");
        }

        public static byte[] ConvertToByteArray(string binaryString, Encoding encoding)
        {
            return encoding.GetBytes(binaryString);
        }

        public static String ToBinary(Byte[] data)
        {
            return string.Join("", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }

        
        

    }
}
