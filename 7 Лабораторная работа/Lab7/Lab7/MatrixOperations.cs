namespace Lab7
{
    public class MatrixOperations
    {
        public static void PrintMatrix(int[,] matrix, int k, int n)
        {
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void PrintVerifMatrix(int[,] matrix, int k, int n)
        {
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < k; i++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
        }
    }
}
