using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Labs2
{
  
    class Program
    {
        static void Main(string[] args)
        {
            char[] EngAlph = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] BelRusAlph = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'i', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'Y', 'ф', 'ч', 'ц', 'ч', 'ш', 'ы', 'ь', 'э', 'ю', 'я' };
            char[] Eng = { 'h', 'e', 'l', 'l', 'o' };
            char[] Belrus = { 'п', 'р', 'ы', 'в', 'i', 'т',};
            double lengEng = EngAlph.Length;
            double lengBelRus = BelRusAlph.Length;
            double Hbinary = 0;//Бинарный язык
            double Heng = 0;//Энтропия для каждого языка
            double HBelrus = 0;
            Console.WriteLine("Кол-во букв в английском алфавите :" + lengEng);
            Console.WriteLine("Кол-во букв в белорусском алфавите :" + lengBelRus);
            foreach (char i in EngAlph)
            {
                double count = 0;
                foreach (char z in Eng)
                {
                    if (z == i)
                        count++;

                }

                double Pai = count / lengEng;
                // Console.WriteLine(Pai);
                if (Pai != 0)
                {
                    Heng += Pai * Math.Log2(Pai);
                }
            }
            Heng = Heng * (-1);
            Console.WriteLine("Энтропия английского алфавита:");
            Console.WriteLine(Heng);


            foreach (char i in BelRusAlph)
            {
                double count = 0;
                foreach (char z in Belrus)
                {
                    if (z == i)
                        count++;

                }

                double Pai = count / lengBelRus;
                // Console.WriteLine(Pai);
                if (Pai != 0)
                {
                    HBelrus += Pai * Math.Log2(Pai);
                }
            }
            HBelrus = HBelrus * (-1);
            Console.WriteLine("Энтропия белорусского алфавита:");
            Console.WriteLine(HBelrus);

            int[] countLetter = new int[2];
            double[] probabilityLetters = new double[2];
            string letters = "01";
            using (StreamReader streamReader = new StreamReader(@"D:\3 курс 1 сем\ЗАЩИТА ИНФОРМАЦИИ И НАДЕЖНОСТЬ ИНФОРМАЦИОННЫХ СИСТЕМ\2 Лабораторная работа\binary.txt"))
            {
                string file = streamReader.ReadToEnd();
                double binaryleng = file.Count();
                for (int j = 0; j < 2; j++)
                {
                    countLetter[j] = file.Count(x => x == letters[j]);

                    probabilityLetters[j] = (double)countLetter[j] / binaryleng;
                    Console.WriteLine();
                    Hbinary += (probabilityLetters[j] * (Math.Log(probabilityLetters[j])) / Math.Log(2));
                }

            }

            Hbinary = Hbinary * (-1);
            Console.WriteLine("Энтропия бинарного алфавита:");
            Console.WriteLine(Hbinary);


            Console.WriteLine("Введите Ваше ФИО: ");
            string FIO = Console.ReadLine();


            double countBelInformation = HBelrus * FIO.Replace(" ", "").ToLower().Count();
            double countBinaryInformation = Hbinary * FIO.Replace(" ", "").ToLower().Count();

            Console.WriteLine("Количество информации с использованием энтропии беларусского алфавита:");
            Console.WriteLine(countBelInformation);

            Console.WriteLine("Количество информации с использованием энтропии бинарного алфавита:");
            Console.WriteLine(countBinaryInformation);


            Console.WriteLine();
            double ascii = FIO.ToLower().Count() * 8;

            Console.WriteLine();
            Console.WriteLine("Количество информации с использованием ASСII для белорусского алфавита:");
            double ASIIBelrInformation = ascii * HBelrus;
            Console.WriteLine(ASIIBelrInformation);


            Console.WriteLine();
            Console.WriteLine("Количество информации с использованием ASСII для бинарного алфавита:");
            double ASIIbinaryInformation = ascii * Hbinary;
            Console.WriteLine(ASIIbinaryInformation);


            Console.WriteLine("Вероятность ошибочной передачи единичного бита сообщения состовляет 0,1");

            float p = 0.1F;
            float q = 1 - p;
            Console.WriteLine("Условная энтропия ");
            double H01 = -1 * p * (Math.Log2(p) / Math.Log(2)) - q * (Math.Log2(q) / Math.Log(2));
            Console.WriteLine(H01);
            Console.WriteLine("Эффективная энтропия");
            double effectH01 = 1 - H01;
            Console.WriteLine(effectH01);
            Console.WriteLine("Вероятность ошибочной передачи единичного бита сообщения состовляет 0,5");

            p = 0.5F;
            q = 1 - p;
            Console.WriteLine("Условная энтропия ");
            double H05 = -1 * p * (Math.Log2(p) / Math.Log(2)) - q * (Math.Log2(q) / Math.Log(2));
            Console.WriteLine(H05);
            Console.WriteLine("Эффективная энтропия");
            double effectH05 = 1 - H01;
            Console.WriteLine(effectH05);
            Console.WriteLine("Вероятность ошибочной передачи единичного бита сообщения состовляет 1,0");

            p = 1;
            q = 1 - p;
            Console.WriteLine("Условная энтропия ");
            double H1 = -1 * p * Math.Log2(p) - q * Math.Log2(q);
            Console.WriteLine(H1);
            Console.WriteLine("Эффективная энтропия");
            double effectH1 = 1 - H1;
            Console.WriteLine(effectH1);
        }

    }
}
