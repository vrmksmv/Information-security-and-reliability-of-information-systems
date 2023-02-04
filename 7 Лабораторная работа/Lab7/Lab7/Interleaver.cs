namespace Lab7
{
    public class Interleaver
    {
        public static int[] ExecInterleaving(int[] arrN, int k)
        {
            int r = HemmingCode.GetNumOfVerifChar(k);
            int n = k + r;

            int[,] matrix = new int[k, n];

            for (int i = 0, m = 0; i < k; i++)
            {
                for (int j = 0; j < n; j++, m++)
                {
                    matrix[i, j] = arrN[m];
                }
            }
            Console.WriteLine("\n\nВид и содержание матрицы перемежения:");
            MatrixOperations.PrintMatrix(matrix, k, n);

            for (int i = 0, m = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++, m++)
                {
                    arrN[m] = matrix[j, i];
                }
            }

            return arrN;
        }

        public static int[] ExecDeInterleaving(int[] arrN, int k)
        {
            int r = HemmingCode.GetNumOfVerifChar(k);
            int n = k + r;

            int[,] matrix = new int[k, n];

            for (int j = 0, m = 0; j < n; j++)
            {
                for (int i = 0; i < k; i++, m++)
                {
                    matrix[i, j] = arrN[m];
                }
            }
            Console.WriteLine("\n\nПолученая матрица");
            MatrixOperations.PrintMatrix(matrix, k, n);

            for (int j = 0, m = 0; j < k; j++)                              //осуществляем деперемежение
            {
                for (int i = 0; i < n; i++, m++)
                {
                    arrN[m] = matrix[j, i];
                }
            }

            return arrN;
        }

        public static int[] AddCheckBits(int[] arrK, int[] arrN, int[,] verifMatrix)
        {
            int infoFLow = arrK.Length;
            int k = (int)(Math.Sqrt(infoFLow));
            int r = HemmingCode.GetNumOfVerifChar(k);
            int n = k + r;

            for (int i = 0; i < k; i++)
            {
                int[] temp = new int[n];
                for (int j = 0; j < k; j++)
                {
                    temp[j] = arrK[(k * i) + j];
                }

                HemmingCode.GetSyndrom(verifMatrix, temp, k);       //для каждой строки определяем проверочные символы и складываем в однну бю//Запись строки в массив, для получения одной большой строкистроку

                for (int j = 0; j < n; j++)
                {
                    arrN[i * n + j] = temp[j];
                }
            }
            return arrN;
        }

        public static int[] RemoveCheckBits(int[] arrK, int[] arrN, int[,] checkMatrix)
        {
            int infoFLow = arrK.Length;
            int k = (int)(Math.Sqrt(infoFLow));
            int r = HemmingCode.GetNumOfVerifChar(k);
            int n = k + r;

            for (int i = 0; i < k; i++)
            {
                int[] temp = new int[n];
                for (int j = 0; j < n; j++)
                {
                    temp[j] = arrN[(n * i) + j];
                }

                for (int j = 0; j < k; j++)
                {
                    arrK[i * k + j] = temp[j];
                }
            }
            return arrK;
        }

        public static int[] LineByLineSearchError(int[] arrN, int[,] verifMatrix, int k)
        {
            int r = HemmingCode.GetNumOfVerifChar(k);
            int n = r + k;

            for (int i = 0; i < k; i++)
            {
                int[] temp = new int[n];
                for (int j = 0; j < n; j++)
                {
                    temp[j] = arrN[(n * i) + j];
                }

                HemmingCode.SearchError(temp, verifMatrix, k);

                for (int j = 0; j < n; j++)
                {
                    arrN[i * n + j] = temp[j];
                }
            }

            return arrN;
        }
    }
}
