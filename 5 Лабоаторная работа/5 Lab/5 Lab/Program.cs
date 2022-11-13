using System;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("6 Вариант");
            Console.WriteLine("Генирируемое сообщение 20 бит");

            int[] array_message = new int[20];
            Random rand = new Random();
            for (int i = 0; i < array_message.Length; i++) {
                array_message[i] = rand.Next(0,2);
                Console.Write(array_message[i] + " ");
            }
               
            Console.WriteLine('\n' + "Матрица k1 = 2, k2 = 10");

            for (int i = 0; i < array_message.Length; i++)
            {
                if(i == 10)
                {
                    Console.WriteLine("");
                }
                Console.Write(array_message[i] + " ");
            }

            Console.WriteLine("");

            #region Расчет паритета строк
            Console.WriteLine("Паритет строк");

            int[] array_paritet_rows = new int[2];
            int flag = 0;

            for (int i = 0; i < array_message.Length; i++)
            {
                if (array_message[i] == 1)
                {
                    flag += 1;
                }
                if (i == 9)
                {
                    if (flag % 2 == 0) { array_paritet_rows[0] = 0; }
                    else { array_paritet_rows[0] = 1; }
                    flag = 0;
                }
                if (i == 19)
                {
                    if (flag % 2 == 0) { array_paritet_rows[1] = 0; }
                    else { array_paritet_rows[1] = 1; }
                    flag = 0;
                }
            }
            #endregion


            for (int i = 0; i < array_paritet_rows.Length; i++)
            {
                Console.Write(array_paritet_rows[i] + " ");
            }


            Console.WriteLine();

            #region Расчет паритета столбцов
            Console.WriteLine("Паритет столбцов");
            
            int[] array_paritet_colums = new int[10];
         
            if ((array_message[0] + array_message[10]) % 2 == 0) { array_paritet_colums[0] = 0; }
            else { array_paritet_colums[0] = 1; }

            if ((array_message[1] + array_message[11]) % 2 == 0) { array_paritet_colums[1] = 0; }
            else { array_paritet_colums[1] = 1; }

            if ((array_message[2] + array_message[12]) % 2 == 0) { array_paritet_colums[2] = 0; }
            else { array_paritet_colums[2] = 1; }

            if ((array_message[3] + array_message[13]) % 2 == 0) { array_paritet_colums[3] = 0; }
            else { array_paritet_colums[3] = 1; }

            if ((array_message[4] + array_message[14]) % 2 == 0) { array_paritet_colums[4] = 0; }
            else { array_paritet_colums[4] = 1; }

            if ((array_message[5] + array_message[15]) % 2 == 0) { array_paritet_colums[5] = 0; }
            else { array_paritet_colums[5] = 1; }

            if ((array_message[6] + array_message[16]) % 2 == 0) { array_paritet_colums[6] = 0; }
            else { array_paritet_colums[6] = 1; }

            if ((array_message[7] + array_message[17]) % 2 == 0) { array_paritet_colums[7] = 0; }
            else { array_paritet_colums[7] = 1; }

            if ((array_message[8] + array_message[18]) % 2 == 0) { array_paritet_colums[8] = 0; }
            else { array_paritet_colums[8] = 1; }

            if ((array_message[9] + array_message[19]) % 2 == 0) { array_paritet_colums[9] = 0; }
            else { array_paritet_colums[9] = 1; }

            for (int i = 0; i < array_paritet_colums.Length; i++)
            {
                Console.Write(array_paritet_colums[i] + " ");
            }
            #endregion


            Console.WriteLine('\n'+"Сообщение с избыточными битами");
            for (int i = 0; i < array_message.Length; i++)
            {
                Console.Write(array_message[i] + " ");
            }
            Console.Write(".");
            for (int i = 0; i < array_paritet_rows.Length; i++)
            {
                Console.Write(array_paritet_rows[i] + " ");
            }

            for (int i = 0; i < array_paritet_colums.Length; i++)
            {
                Console.Write(array_paritet_colums[i] + " ");
            }

            Console.WriteLine("");
            Console.WriteLine("");

            #region Ситуация когда ошибок 0

            Console.WriteLine("Ситуация когда ошибок 0");
            Console.WriteLine('\n' + "Париет строк");
            for (int i = 0; i < array_paritet_rows.Length; i++)
            {
                Console.Write(array_paritet_rows[i] + " ");
            }
            Console.WriteLine('\n' + "XOR");
            for (int i = 0; i < array_paritet_rows.Length; i++)
            {
                Console.Write(array_paritet_rows[i] + " ");
            }
            Console.WriteLine('\n' + "---" + '\n' + "0 0");

            Console.WriteLine('\n' + "Париет столбцов");
            for (int i = 0; i < array_paritet_colums.Length; i++)
            {
                Console.Write(array_paritet_colums[i] + " ");
            }
            Console.WriteLine('\n' + "XOR");
            for (int i = 0; i < array_paritet_colums.Length; i++)
            {
                Console.Write(array_paritet_colums[i] + " ");
            }
            Console.WriteLine('\n' + "-------------------" + '\n' + "0 0 0 0 0 0 0 0 0 0");
            Console.WriteLine('\n' + "Ошибок нет");


            #endregion

            Console.WriteLine("");

            #region Ситуация когда ошибка 1

            Console.WriteLine("Ситуация когда 1 ошибка");
            int error_in_rows = 0;
            int error_in_colums = 0;

            int[] array_message_with_one_error = new int[20];
            array_message_with_one_error = array_message;
            int rand_index = rand.Next(0, 20);
            if (array_message_with_one_error[rand_index] == 1) { array_message_with_one_error[rand_index] = 0; }
            else
            {
                array_message_with_one_error[rand_index] = 1;
            }

            Console.WriteLine("");
            for (int i = 0; i < array_message_with_one_error.Length; i++)
            {
                if (i == 10)
                {
                    Console.WriteLine("");
                }
                Console.Write(array_message_with_one_error[i] + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("Паритет строк");
            for (int i = 0; i < array_paritet_rows.Length; i++)
            {
                Console.Write(array_paritet_rows[i] + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("Паритет столбцов");
            for (int i = 0; i < array_paritet_colums.Length; i++)
            {
                Console.Write(array_paritet_colums[i] + " ");
            }
            Console.WriteLine("");


            #region Новый паритет строк
            Console.WriteLine("Новый паритет строк");
            int[] array_paritet_rows_with_one_error = new int[2];

            for (int i = 0; i < array_message_with_one_error.Length; i++)
            {
                if (array_message_with_one_error[i] == 1)
                {
                    flag += 1;
                }
                if (i == 9)
                {
                    if (flag % 2 == 0) { array_paritet_rows_with_one_error[0] = 0; }
                    else { array_paritet_rows_with_one_error[0] = 1; }
                    flag = 0;
                }
                if (i == 19)
                {
                    if (flag % 2 == 0) { array_paritet_rows_with_one_error[1] = 0; }
                    else { array_paritet_rows_with_one_error[1] = 1; }
                    flag = 0;
                }
            }


            for (int i = 0; i < array_paritet_rows_with_one_error.Length; i++)
            {
                Console.Write(array_paritet_rows_with_one_error[i] + " ");
            }
            Console.WriteLine("");


            #endregion

            #region Новый паритет столбцов
            Console.WriteLine("Новый паритет столбцов");

            int[] array_paritet_colums_with_one_error = new int[10];

            if ((array_message_with_one_error[0] + array_message_with_one_error[10]) % 2 == 0) { array_paritet_colums_with_one_error[0] = 0; }
            else { array_paritet_colums_with_one_error[0] = 1; }

            if ((array_message_with_one_error[1] + array_message_with_one_error[11]) % 2 == 0) { array_paritet_colums_with_one_error[1] = 0; }
            else { array_paritet_colums_with_one_error[1] = 1; }

            if ((array_message_with_one_error[2] + array_message_with_one_error[12]) % 2 == 0) { array_paritet_colums_with_one_error[2] = 0; }
            else { array_paritet_colums_with_one_error[2] = 1; }

            if ((array_message_with_one_error[3] + array_message_with_one_error[13]) % 2 == 0) { array_paritet_colums_with_one_error[3] = 0; }
            else { array_paritet_colums_with_one_error[3] = 1; }

            if ((array_message_with_one_error[4] + array_message_with_one_error[14]) % 2 == 0) { array_paritet_colums_with_one_error[4] = 0; }
            else { array_paritet_colums_with_one_error[4] = 1; }

            if ((array_message_with_one_error[5] + array_message_with_one_error[15]) % 2 == 0) { array_paritet_colums_with_one_error[5] = 0; }
            else { array_paritet_colums_with_one_error[5] = 1; }

            if ((array_message_with_one_error[6] + array_message_with_one_error[16]) % 2 == 0) { array_paritet_colums_with_one_error[6] = 0; }
            else { array_paritet_colums_with_one_error[6] = 1; }

            if ((array_message_with_one_error[7] + array_message_with_one_error[17]) % 2 == 0) { array_paritet_colums_with_one_error[7] = 0; }
            else { array_paritet_colums_with_one_error[7] = 1; }

            if ((array_message_with_one_error[8] + array_message_with_one_error[18]) % 2 == 0) { array_paritet_colums_with_one_error[8] = 0; }
            else { array_paritet_colums_with_one_error[8] = 1; }

            if ((array_message_with_one_error[9] + array_message_with_one_error[19]) % 2 == 0) { array_paritet_colums_with_one_error[9] = 0; }
            else { array_paritet_colums_with_one_error[9] = 1; }

            for (int i = 0; i < array_paritet_colums_with_one_error.Length; i++)
            {
                Console.Write(array_paritet_colums_with_one_error[i] + " ");
            }

            #endregion

            #region Ошибка в строке
            Console.WriteLine('\n'+"Поиск ошибки в строке");
            for (int i = 0; i < array_paritet_rows.Length; i++)
            {
                Console.Write(array_paritet_rows[i] + " ");
            }
            Console.WriteLine('\n' + "XOR");
            for (int i = 0; i < array_paritet_rows_with_one_error.Length; i++)
            {
                Console.Write(array_paritet_rows_with_one_error[i] + " ");
            }
            Console.WriteLine('\n' + "---");
            int[] rows_paritet_with_errors = new int[2];

            if ((array_paritet_rows[0] == 0 && array_paritet_rows_with_one_error[0] == 0) || (array_paritet_rows[0] == 1 && array_paritet_rows_with_one_error[0] == 1))
            {
                rows_paritet_with_errors[0] = 0;
            }
            else
            {
                rows_paritet_with_errors[0] = 1;
            }
            if ((array_paritet_rows[1] == 0 && array_paritet_rows_with_one_error[1] == 0) || (array_paritet_rows[1] == 1 && array_paritet_rows_with_one_error[1] == 1))
            {
                rows_paritet_with_errors[1] = 0;
            }
            else
            {
                rows_paritet_with_errors[1] = 1;
            }

            for (int i = 0; i < rows_paritet_with_errors.Length; i++)
            {
                Console.Write(rows_paritet_with_errors[i] + " ");
                if(rows_paritet_with_errors[i] == 1)
                {
                    error_in_rows = i;
                }
            }
            #endregion

            #region Ошибка в колонке

            Console.WriteLine('\n' + "Поиск ошибки в паритете столбцов");
            for (int i = 0; i < array_paritet_colums.Length; i++)
            {
                Console.Write(array_paritet_colums[i] + " ");
            }
            Console.WriteLine('\n' + "XOR");
            for (int i = 0; i < array_paritet_colums_with_one_error.Length; i++)
            {
                Console.Write(array_paritet_colums_with_one_error[i] + " ");
            }
            Console.WriteLine('\n' + "--------------");


            int[] colums_paritet_with_errors = new int[10];

            if ((array_paritet_colums[0] == 0 && array_paritet_colums_with_one_error[0] == 0) || (array_paritet_colums[0] == 1 && array_paritet_colums_with_one_error[0] == 1))
            {
                colums_paritet_with_errors[0] = 0;
            }
            else { colums_paritet_with_errors[0] = 1; }

            if ((array_paritet_colums[1] == 0 && array_paritet_colums_with_one_error[1] == 0) || (array_paritet_colums[1] == 1 && array_paritet_colums_with_one_error[1] == 1))
            {
                colums_paritet_with_errors[1] = 0;
            }
            else { colums_paritet_with_errors[1] = 1; }


            if ((array_paritet_colums[2] == 0 && array_paritet_colums_with_one_error[2] == 0) || (array_paritet_colums[2] == 1 && array_paritet_colums_with_one_error[2] == 1))
            {
                colums_paritet_with_errors[2] = 0;
            }
            else { colums_paritet_with_errors[2] = 1; }


            if ((array_paritet_colums[3] == 0 && array_paritet_colums_with_one_error[3] == 0) || (array_paritet_colums[3] == 1 && array_paritet_colums_with_one_error[3] == 1))
            {
                colums_paritet_with_errors[3] = 0;
            }
            else { colums_paritet_with_errors[3] = 1; }


            if ((array_paritet_colums[4] == 0 && array_paritet_colums_with_one_error[4] == 0) || (array_paritet_colums[4] == 1 && array_paritet_colums_with_one_error[4] == 1))
            {
                colums_paritet_with_errors[4] = 0;
            }
            else { colums_paritet_with_errors[4] = 1; }


            if ((array_paritet_colums[5] == 0 && array_paritet_colums_with_one_error[5] == 0) || (array_paritet_colums[5] == 1 && array_paritet_colums_with_one_error[5] == 1))
            {
                colums_paritet_with_errors[5] = 0;
            }
            else { colums_paritet_with_errors[5] = 1; }


            if ((array_paritet_colums[6] == 0 && array_paritet_colums_with_one_error[6] == 0) || (array_paritet_colums[6] == 1 && array_paritet_colums_with_one_error[6] == 1))
            {
                colums_paritet_with_errors[6] = 0;
            }
            else { colums_paritet_with_errors[6] = 1; }


            if ((array_paritet_colums[7] == 0 && array_paritet_colums_with_one_error[7] == 0) || (array_paritet_colums[7] == 1 && array_paritet_colums_with_one_error[7] == 1))
            {
                colums_paritet_with_errors[7] = 0;
            }
            else { colums_paritet_with_errors[7] = 1; }


            if ((array_paritet_colums[8] == 0 && array_paritet_colums_with_one_error[8] == 0) || (array_paritet_colums[8] == 1 && array_paritet_colums_with_one_error[8] == 1))
            {
                colums_paritet_with_errors[8] = 0;
            }
            else { colums_paritet_with_errors[8] = 1; }


            if ((array_paritet_colums[9] == 0 && array_paritet_colums_with_one_error[9] == 0) || (array_paritet_colums[9] == 1 && array_paritet_colums_with_one_error[9] == 1))
            {
                colums_paritet_with_errors[9] = 0;
            }
            else { colums_paritet_with_errors[9] = 1; }


            for (int i = 0; i < colums_paritet_with_errors.Length; i++)
            {
                Console.Write(colums_paritet_with_errors[i] + " ");
                if(colums_paritet_with_errors[i] == 1)
                {
                    error_in_colums = i;
                }
            }
            #endregion

            Console.WriteLine('\n' + "Следовательно ошибка в ");
            Console.WriteLine("Строке " + error_in_rows);
            Console.WriteLine("Колонке " + error_in_colums);

            Console.WriteLine("Исправленная матрица");

            for (int i = 0; i < array_message_with_one_error.Length; i++)
            {
                if (i == 10)
                {
                    Console.WriteLine("");
                }
                if(i == (error_in_colums + error_in_rows))
                {
                    if (error_in_rows == 1)
                    {
                        if (array_message_with_one_error[i + 9] == 1) { array_message_with_one_error[i + 9] = 0; }
                        else { array_message_with_one_error[i + 9] = 1; }
                    }
                    else
                    {
                        if (array_message_with_one_error[i] == 1) { array_message_with_one_error[i] = 0; }
                        else { array_message_with_one_error[i] = 1; }
                    }
                 
                }

                Console.Write(array_message_with_one_error[i] + " ");
            }

            #endregion


            



        }
    }
}