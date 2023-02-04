using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class Program
    {
        public static void ShowMatrix(byte[,] matrix, int firstAxel, int secondAxel)
        {
            for (int i = 0; i < firstAxel; i++)
            {
                for (int j = 0; j < secondAxel; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // 7 _ 5 _ х^5 + х^4 + х^3 + х + 1

            Random rand = new Random();
            int k = 14; //10-16
            int r = 14;
            r += 1;
            int n = k + r;
            byte[] Xr_Byte = new byte[r];
            byte[] Xr_Byte2 = new byte[r];
            byte[] E_Byte = new byte[r];

            //Xn[0] = (byte)(1);
            //for (int i = 1; i < k; i++)
            //{
            //    Xn[i] = (byte)(rand.Next(0, 2));
            //}
            //Console.WriteLine();
            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write(Xn[i] + " ");
            //}

            byte[] BaseBytes = new byte[] { 1, 1, 1, 0, 1, 1 };
            int firstAxelOfCreatingMatrix = r - 1;
            int secondAxelOfCreatingMatrix = (r - 1) + BaseBytes.Length - 1;
            byte[,] creatingMatrix = new byte[firstAxelOfCreatingMatrix, secondAxelOfCreatingMatrix];
            
            //ФОРМИРУЕМ СДВИНУТУЮ МАТРИЦУ
            for (int i = 0; i < firstAxelOfCreatingMatrix; i++)
            {
                for (int j = 0; j < BaseBytes.Length; j++)
                {
                    creatingMatrix[i, j + i] = BaseBytes[j];
                }
            }
            ShowMatrix(creatingMatrix, firstAxelOfCreatingMatrix, secondAxelOfCreatingMatrix);

            //ПРИВОДИМ СДВИНУТУЮ МАТРИЦУ К КАНОНИЧЕСКОМУ ВИДУ
            byte[,] firstCanonMatrix = creatingMatrix;
            for (int row = 0; row < r; row++)
            {
                for (int i = row+1; i < firstAxelOfCreatingMatrix; i++)
                {
                    if (firstCanonMatrix[row, i] == (byte)1)
                    {
                        for (int j = 0; j < secondAxelOfCreatingMatrix; j++)
                        {
                            firstCanonMatrix[row, j] = (byte)((firstCanonMatrix[row, j] + firstCanonMatrix[i, j]) % 2);
                        }
                    }
                }
            }
            ShowMatrix(firstCanonMatrix, firstAxelOfCreatingMatrix, secondAxelOfCreatingMatrix);

            //СОЗДАЁМ ПРОВЕРОЧНУЮ МАТРИЦУ КАНОНИЧЕСКОЙ ФОРМЫ
            byte[,] helpMatrix = new byte[r -1, secondAxelOfCreatingMatrix - (r - 1)];
            for (int i = 0; i < firstAxelOfCreatingMatrix; i++)
            {
                for (int j = 0; j < secondAxelOfCreatingMatrix - (r - 1) ; j++)
                {
                    helpMatrix[i,j] = firstCanonMatrix[i,j +  r - 1];
                }
            }
            ShowMatrix(helpMatrix, r - 1, secondAxelOfCreatingMatrix - (r - 1));


            //ТРАНСПОНИРУЕМ МАТРИЦУ И ЗАПОЛНЯЕМ ПРОВЕРОЧНУЮ
            byte[,] checkCanonMatrix = new byte[secondAxelOfCreatingMatrix - (r - 1), secondAxelOfCreatingMatrix];
            for (int i = 0; i < r - 1; i++)
            {
                for (int j = 0; j < secondAxelOfCreatingMatrix - (r - 1); j++)
                {
                    checkCanonMatrix[j, i] = helpMatrix[i, j];
                }
            }
            ShowMatrix(checkCanonMatrix, secondAxelOfCreatingMatrix - (r - 1), secondAxelOfCreatingMatrix );

            for (int i = 0; i < secondAxelOfCreatingMatrix - (r - 1); i++)
            {
                for (int j = r - 1; j < secondAxelOfCreatingMatrix; j++)
                {
                    if (i + (r - 1) == j)
                    {
                        checkCanonMatrix[i, j] = (byte)1;
                    }
                }
            }
            ShowMatrix(checkCanonMatrix, secondAxelOfCreatingMatrix - (r - 1), secondAxelOfCreatingMatrix);

            int newR = Convert.ToInt32(Math.Ceiling(Math.Log(r, 2))) + 1;

            byte[] Xk_Byte = new byte[k];
            for (int i = 0; i < k; i++)
            {
                Xk_Byte[i] = (byte)(rand.Next(0, 2));
            }
            foreach(byte b in Xk_Byte)
            {
                Console.Write(b + " ");
            }
            Console.WriteLine();

            for (int i = 0, XrCounter = 0; i < newR; i++, XrCounter++)
            {
                int result = 0;
                for (int j = 0; j < k; j++)
                {
                    result += (checkCanonMatrix[i, j] * Xk_Byte[j]);
                    //Console.WriteLine(checkCanonMatrix[i, j] + " * " + Xk_Byte[j] + " = " + result);
                }
                if ((result % 2) == 0)
                    Xr_Byte[XrCounter] = 0;
                if ((result % 2) == 1)
                    Xr_Byte[XrCounter] = 1;
            }


            //формируем ошибки ---------------------------------------------------------------------------------------------------------------------------
            for (int i = 0, countOfMistakes = 1; i < countOfMistakes; i++)
            {
                int placeOfMistake = rand.Next(0, k);
                if (Xk_Byte[placeOfMistake] == 1)
                    Xk_Byte[placeOfMistake] = 0;
                else
                    Xk_Byte[placeOfMistake] = 1;
            }
            //вычисляем избыточные символы 2
            for (int i = 0, XrCounter = 0; i < newR; i++, XrCounter++)
            {
                int result = 0;
                for (int j = 0; j < k; j++)
                {
                    result += (checkCanonMatrix[i, j] * Xk_Byte[j]);
                    //Console.WriteLine(checkCanonMatrix[i, j] + " * " + Xk_Byte[j] + " = " + result);
                }
                if ((result % 2) == 0)
                    Xr_Byte2[XrCounter] = 0;
                if ((result % 2) == 1)
                    Xr_Byte2[XrCounter] = 1;
            }
            Console.WriteLine();
            for (int j = 0; j < k; j++)
            {
                Console.Write(Xk_Byte[j] + " ");
            }
            for (int j = 0; j < newR; j++)
            {
                Console.Write(Xr_Byte2[j] + " ");
            }
            Console.WriteLine();


            //вычисляем синдром 
            Console.WriteLine("Синдром");
            for (int j = 0; j < newR; j++)
            {
                E_Byte[j] = (byte)(Xr_Byte[j] ^ Xr_Byte2[j]);
                Console.Write(E_Byte[j] + " ");
            }
            Console.WriteLine();

            int RowWithMistake = -1;
            for (int row = 0, counter = 0; row < k; row++)
            {
                counter = 0;
                for (int col = 0; col < newR; col++)
                {
                    if (E_Byte[col] == checkCanonMatrix[col, row])
                        counter++;
                    if (counter == newR)
                    {
                        RowWithMistake = row;
                        break;
                    }
                }
            }
            Console.WriteLine("ошибка в бите №" + (1 + RowWithMistake));
            Console.WriteLine();


            Console.ReadLine();

        }
    }
}
