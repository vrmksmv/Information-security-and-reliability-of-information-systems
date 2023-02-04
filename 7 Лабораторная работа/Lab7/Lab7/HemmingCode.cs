namespace Lab7
{
    public class HemmingCode
    {
        public static int GetNumOfVerifChar(int k)
        {
            int r = (int)(Math.Log(k, 2) + 1.99f);
            return r;
        }

        public static int[,] GetVerifMatrix(int k)
        {
            int r = GetNumOfVerifChar(k);
            int n = r + k;
            double rDouble = r - 1;
            int rPow = (int)(Math.Pow(2, rDouble));

            int[,] arr = new int[n, r];

            int[,] combinations = new int[rPow, r];

            for (int i = 0; i < rPow; i++)
                for (int j = 0; j < r; j++)
                    combinations[i, j] = 0;

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
                    arr[i, j] = combinations[i, j];

            for (int i = 0; i < r; i++)
                arr[i + k, i] = 1;

            return arr;
        }

        public static int[] GetSyndrom(int[,] VerifMatrix, int[] arr, int k)
        {
            int r = GetNumOfVerifChar(k);
            int n = r + k;
            int[] syndrom = new int[r];

            for (int i = 0, l = 0; i < r; i++, l = 0)
            {
                for (int j = 0; j < k; j++)
                {
                    if (VerifMatrix[j, i] == 1 && arr[j] == 1) l++;
                    else syndrom[i] = 0;
                }
                if (l % 2 == 1) syndrom[i] = 1;
                else syndrom[i] = 0;
            }

            for (int i = 0; i < r; i++)
            {
                arr[i + k] = syndrom[i];
            }

            return arr;
        }

        public static int[] SearchError(int[] arr, int[,] varifMatrix, int k)
        {

            int r = GetNumOfVerifChar(k);
            int n = r + k;

            int[] beforeSyndrom = new int[r];

            for (int i = k; i < n; i++)
            {
                beforeSyndrom[i - k] = arr[i];
            }

            arr = GetSyndrom(varifMatrix, arr, k);

            for (int i = k, j = 0; i < n; i++)
            {
                if (beforeSyndrom[i - k].Equals(arr[i]))
                {
                    arr[i] = 0;

                    j++;
                    if (j == r)
                    {
                        for (int l = k; l < n; l++)
                        {
                            arr[l] = beforeSyndrom[l - k];
                        }
                        return arr;
                    }
                }
                else
                {
                    arr[i] = 1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                int l = 0;
                for (int j = 0; j < r; j++)
                {
                    if (varifMatrix[i, j].Equals(arr[j + k])) l++;
                }
                if (l == r)
                {
                    arr[i] = (arr[i] + 1) % 2;
                }
            }
            arr = GetSyndrom(varifMatrix, arr, k);

            return arr;
        }
    }
}
