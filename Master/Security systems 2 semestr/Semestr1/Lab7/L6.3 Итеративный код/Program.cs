﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L7
{
    class Program
    {
        
        static void Main(string[] args)
        {
           
            int n = 16;
            int nSqrt = (int)Math.Sqrt(n);
            int lenght = n + nSqrt * 2;
            int[] arr = new int[n];
            int[] newArr = new int[n];
            int[] fullArr = new int[lenght];

            
            ArrayGeneration(arr);
            
            GettingCheckBits(arr, fullArr);
            
            
            GettingError(fullArr);
            
            CorrectionError(newArr, fullArr);
        }
        
        static int [] ArrayGeneration (int [] arr)
        {
            
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++) 
            {
                arr[i] = rand.Next(2);
            }

            ArrayOut(arr,1);

            return arr;
        }

        static void ArrayOut (int [] arr,int prov)
        {
            if(prov==1)
                Console.Write("Исходное сообщение: ");
            else if(prov==2)
                Console.Write("\n"+"Полученное сообщение: ");
            else if(prov==3)
                Console.WriteLine("\n" + "Сообщение с ошибкой");
            else
                Console.WriteLine("\n" + "Исправленное сообщение");
           
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }

        static void MatrixOut(int[,] matrix, int l)
        {
            for (int i = 0; i < l; i++)
            {
                if(i + 1 == l)
                {
                    Console.WriteLine();
                }

                for (int j = 0; j < l; j++)
                {
                    if (j +1 == l)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        static int[] GettingCheckBits(int[] arr, int[] fullArr)
        {
            int n = arr.Length;
            int nSqrt = (int)Math.Sqrt(n);
            int lenght = fullArr.Length;
            int l = nSqrt + 1;

            int[,] matrix = new int[l, l];

            for (int i = 0; i < nSqrt; i++)
            {
                int parity = 0;
                for (int j = 0; j < nSqrt; j++)
                {
                    matrix[i, j] = arr[i * nSqrt + j];
                    parity +=  matrix[i, j];
                    fullArr[i * nSqrt + j] = matrix[i, j];
                }
                matrix[i, nSqrt] = parity % 2;
                fullArr[n + i] = matrix[i, nSqrt];
            }

            for (int i = nSqrt -1 ; i >= 0; i--)
            {
                int parity = 0;
                for (int j = nSqrt - 1; j >= 0; j--)
                {
                    parity += matrix[j, i];
                }
                matrix[nSqrt, i] = parity % 2;
                fullArr[n + nSqrt + (nSqrt - i- 1)] = matrix[nSqrt, i];
            }

            MatrixOut(matrix, l);
            ArrayOut(fullArr,2);

            return fullArr;
        }

        static int[] GettingError(int [] fullArr)
        {
            int error;
            try
            {
                Console.WriteLine("###############################");
                Console.WriteLine("#Введите позицию первой ошибки#");
                Console.WriteLine("###############################");
                error = Convert.ToInt32(Console.ReadLine()) - 1;
                if (fullArr[error] == 1) fullArr[error] = 0;
                else fullArr[error] = 1;
            }
            catch { }
            try
            {
                Console.WriteLine("###############################");
                Console.WriteLine("#Введите позицию второй ошибки#");
                Console.WriteLine("###############################");
                error = Convert.ToInt32(Console.ReadLine()) - 1;
                if (fullArr[error] == 1) fullArr[error] = 0;
                else fullArr[error] = 1;
            }
            catch { }

            ArrayOut(fullArr,3);
            return fullArr;
        }

        static int[] CorrectionError(int[] newArr, int[] fullArr)
        {
            int n = newArr.Length;
            int nSqrt = (int)Math.Sqrt(n);
            int lenght = fullArr.Length;
            int l = nSqrt + 1;

            int ErrorStr = -1;
            int ErrorSlb = -1;
            bool ErrorDoubleStr = false;
            bool ErrorDoubleSlb = false;

            int[,] matrix = new int[l, l];

            for (int i = 0; i < nSqrt; i++)
            {
                int parity = 0;
                for (int j = 0; j < nSqrt; j++)
                {
                    matrix[i, j] = fullArr[i * nSqrt + j];
                    parity += matrix[i, j];
                    newArr[i * nSqrt + j] = matrix[i, j];
                }
                matrix[i, nSqrt] = parity % 2;

                if (matrix[i, nSqrt] != fullArr[n + i])
                {
                    if(ErrorStr != -1)
                    {
                        ErrorDoubleStr = true;
                    }

                    ErrorStr = i;
                }
            }

            if (ErrorStr == -1)
            {
                Console.WriteLine("#############");
                Console.WriteLine("#Ошибок НЕТ!#");
                Console.WriteLine("#############");
                return newArr;
            }

            for (int i = nSqrt - 1; i >= 0; i--)
            {
                int parity = 0;
                for (int j = nSqrt - 1; j >= 0; j--)
                {
                    parity += matrix[j, i];
                }
                matrix[nSqrt, i] = parity % 2;

                if (matrix[nSqrt, i] != fullArr[n + nSqrt + (nSqrt - i - 1)])
                {
                    if (ErrorSlb != -1)
                    {
                        ErrorDoubleSlb = true;
                        
                        if (ErrorStr != -1)
                        {
                            Console.WriteLine("Ошибок больше чем одна, исправление невозможно.");
                            return newArr;
                        }
                    }

                    ErrorSlb = i;

                    if (ErrorDoubleStr)
                    {
                        Console.WriteLine("Ошибок больше чем одна, исправление невозможно.");
                        return newArr;
                    }
                }
            }
            if (ErrorStr != -1 && ErrorSlb != -1)
            {
                newArr[ErrorStr * nSqrt + ErrorSlb] = (matrix[ErrorStr, ErrorSlb] + 1) % 2;
            }
            ArrayOut(newArr,4);


            return newArr;
        }
    }
}
