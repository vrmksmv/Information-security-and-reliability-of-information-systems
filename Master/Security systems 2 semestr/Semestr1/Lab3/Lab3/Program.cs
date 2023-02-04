using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            


            //LAB 2
            //task 1
            ToBase64 toBase64 = new ToBase64();
            toBase64.MethodToBase64();

            //task 2
            Superfluity izbitochoct = new Superfluity();
            izbitochoct.CalculationSuperfluity();

            //task 3
            XORNameFamily xORNameFamily = new XORNameFamily();
            xORNameFamily.CalculateXOR("Nikita", "Osoprilko");
            Console.WriteLine();

        }

        class ToBase64
        {
            public void MethodToBase64()
            {
                string base64 = "";
                using (StreamReader streamReader = new StreamReader(@"D:\универ\5 сем\ЗИ\Labs2\english.txt"))
                {
                    string file = streamReader.ReadToEnd();
                    Console.WriteLine("Исходный текст:");
                    Console.WriteLine(file);
                    Console.WriteLine();

                    for (int i = 0; i < file.Length; i++)
                    {
                        byte[] ascii = Encoding.ASCII.GetBytes(file);
                        base64 = Convert.ToBase64String(ascii);
                    }
                    Console.WriteLine("Перевод в base64:");
                    Console.WriteLine(base64);
                }
                using (StreamWriter sw = new StreamWriter(@"D:\универ\5 сем\ЗИ\Lab3\base64.txt", false))
                {
                    sw.WriteLine(base64);
                }
            }
        }


        class Superfluity
        {
            public void CalculationSuperfluity()
            {
                //english
                EntropyEnglish entropyenglish = new EntropyEnglish();
                entropyenglish.EntropyEnglishAlphabet();

                double entropyEnglishAlphabetHartly = Math.Log(33, 2);
                Console.WriteLine($"Энтропия по Хартли нем текста: {entropyEnglishAlphabetHartly}");

                double superfluityEnglish = 1 - (ShannonEntropyOfTheGAlphabet / entropyEnglishAlphabetHartly);
                Console.WriteLine($"Избыточность информации нем текста: {superfluityEnglish}");

                //base
                EntropyBase entropyBase = new EntropyBase();
                entropyBase.EntropyBaseAlphabet();


                double entropyBinaryAlphabetHartly = Math.Log(64, 2);
                Console.WriteLine($"Энтропия по Хартли Base текста: {entropyBinaryAlphabetHartly}");

                double superfluityBinary = 1 - (ShannonEntropyOfTheBAlphabet / entropyBinaryAlphabetHartly);
                Console.WriteLine($"Избыточность информации Base текста: {superfluityBinary}");
            }
        }

        class XORNameFamily
        {
            public void CalculateXOR(string a, string b)
            {
                byte[] asciiName = Encoding.ASCII.GetBytes(a);
                byte[] asciFamily = Encoding.ASCII.GetBytes(b);

                string base64Name = "";
                string base64Family = "";

                byte[] newasciiName = new byte[] { };
                byte[] newasciiFamily = new byte[] { };
                if (asciiName.Length < asciFamily.Length)
                {
                    Console.WriteLine();
                    newasciiFamily = asciFamily;
                    newasciiName = new byte[asciFamily.Length];
                    for (int i = 0
                        ; i < asciiName.Length; i++)
                    {
                        newasciiName[i] = asciiName[i];
                        Console.Write(newasciiName[i] + " ");
                    }
                    for (int j = asciiName.Length; j < asciFamily.Length; j++)
                    {
                        newasciiName[asciiName.Length + 1] = 0;
                        Console.Write(newasciiName[j] + " ");
                    }
                    Console.WriteLine();
                    for (int i = 0; i < asciFamily.Length; i++)
                    {
                        Console.Write(newasciiFamily[i] + " ");
                    }

                    base64Name = Convert.ToBase64String(newasciiName);
                    base64Family = Convert.ToBase64String(asciFamily);
                    Console.WriteLine();
                    Console.WriteLine(base64Name);
                    Console.WriteLine(base64Family);
                }
                else
                {
                    Console.WriteLine();
                    newasciiName = asciiName;
                    newasciiFamily = new byte[asciiName.Length];
                    for (int i = 0; i < asciFamily.Length; i++)
                    {
                        newasciiFamily[i] = asciFamily[i];
                        Console.WriteLine(newasciiFamily[i]);
                    }
                    for (int j = asciFamily.Length; j < asciiName.Length; j++)
                    {
                        newasciiFamily[asciFamily.Length + 1] = 0;
                        Console.WriteLine(newasciiFamily[j]);
                    }

                    base64Name = Convert.ToBase64String(newasciiName);
                    base64Family = Convert.ToBase64String(asciFamily);
                    Console.WriteLine(base64Name);
                    Console.WriteLine(base64Family);
                }

                Console.WriteLine("\n\nРезультат логического сложения в ASCII:");
                int[] result = new int[newasciiName.Length];
                int[] aaa = new int[base64Name.Length];
                for (int i = 0; i < newasciiName.Length; i++)
                {
                    result[i] = newasciiName[i] ^ newasciiFamily[i] ^ newasciiFamily[i];
                    //Console.Write(result[i] + " ");
                    char ch = (char)result[i];
                    Console.Write(ch);
                }

                string res="";
                Console.WriteLine();
                for (int i = 0; i < base64Name.Length; i++)
                {
                    aaa[i] = base64Name[i] ^ base64Family[i] ^ base64Family[i];
                    //Console.Write(result[i] + " ");
                    
                    char ch = (char)aaa[i];
                    res += ch;
                    Console.Write(ch);
                }

                Console.WriteLine();
                Console.WriteLine( Encoding.ASCII.GetString( Convert.FromBase64String(res)));
            }
        }

        //LAB 1
        static double ShannonEntropyOfTheGAlphabet = 0;
        static double ShannonEntropyOfTheBAlphabet = 0;
        static double ShannonEntropyOfTheBinaryAlphabet = 0;
        class EntropyEnglish
        {
            public void EntropyEnglishAlphabet()
            {
                int[] countLetter = new int[26];
                int countLettersInFile = 0;
                double[] probabilityLetters = new double[26];
                // double ShannonEntropyOfTheAlphabet = 0;
                string letters = "abcdefghijklmnopqrstuvwxyz";
                using (StreamReader streamReader = new StreamReader(@"D:\универ\5 сем\ЗИ\Labs2\english.txt"))
                {
                    string file = streamReader.ReadToEnd().ToLower();
                    countLettersInFile = file.Count();

                    Console.WriteLine($"Количество символов в файле: {countLettersInFile}");
                    Console.WriteLine();
                    Console.WriteLine("Количество вхождений каждой буквы:\n");


                    for (int j = 0; j < 26; j++)
                    {
                        countLetter[j] = file.Count(x => x == letters[j]);
                        if (countLetter[j] != 0)
                        {
                            Console.WriteLine($"{ letters[j]}: { countLetter[j]}");

                            probabilityLetters[j] = (double)countLetter[j] / countLettersInFile;
                            Console.WriteLine($"P({letters[j]}): {probabilityLetters[j]}");
                            Console.WriteLine();

                            ShannonEntropyOfTheGAlphabet += probabilityLetters[j] * (Math.Log(probabilityLetters[j]) / Math.Log(2)) * (-1);
                        }
                    }
                    Console.WriteLine("Энтропия Английского алфавита по Шеннону:");
                    Console.WriteLine(ShannonEntropyOfTheGAlphabet);

                }
            }
        }

        class EntropyBase
        {
            public void EntropyBaseAlphabet()
            {
                int[] countLetter = new int[64];
                int countLettersInFile = 0;
                double[] probabilityLetters = new double[64];
                // double ShannonEntropyOfTheAlphabet = 0;
                string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
                using (StreamReader streamReader = new StreamReader(@"D:\универ\5 сем\ЗИ\Lab3\base64.txt"))
                {
                    string file = streamReader.ReadToEnd().ToLower();
                    countLettersInFile = file.Count();

                    Console.WriteLine($"Количество символов в файле: {countLettersInFile}");
                    Console.WriteLine();
                    Console.WriteLine("Количество вхождений каждой буквы:\n");


                    for (int j = 0; j < 64; j++)
                    {
                        countLetter[j] = file.Count(x => x == letters[j]);
                        if (countLetter[j] != 0)
                        {
                            Console.WriteLine($"{ letters[j]}: { countLetter[j]}");

                            probabilityLetters[j] = (double)countLetter[j] / countLettersInFile;
                            Console.WriteLine($"P({letters[j]}): {probabilityLetters[j]}");
                            Console.WriteLine();

                            ShannonEntropyOfTheBAlphabet += probabilityLetters[j] * (Math.Log(probabilityLetters[j]) / Math.Log(2)) * (-1);
                        }
                    }
                    Console.WriteLine("Энтропия алфавита Base по Шеннону:");
                    Console.WriteLine(ShannonEntropyOfTheBAlphabet);

                }
            }
        }
        class EntropyBinaryDigit
        {
            public void EntropyBinaryAlphabet()
            {
                int[] countLetter = new int[2];
                int countLettersInFile = 0;
                double[] probabilityLetters = new double[2];
                //double ShannonEntropyOfTheBinaryAlphabet = 0;
                string letters = "01";
                using (StreamReader streamReader = new StreamReader(@"D:\универ\5 сем\ЗИ\Lab3\base64.txt"))
                {
                    string file = streamReader.ReadToEnd();
                    countLettersInFile = file.Count();

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("BINARY DIGIT");
                    Console.WriteLine($"Количество символов в файле: {countLettersInFile}");
                    Console.WriteLine();
                    Console.WriteLine("Количество вхождений каждой цифры:");
                    for (int i = 0; i < file.Length; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            countLetter[j] = file.Count(x => x == letters[j]);
                            Console.WriteLine($"{ letters[j]}: { countLetter[j]}");

                            probabilityLetters[j] = (double)countLetter[j] / countLettersInFile;
                            Console.WriteLine($"P({letters[j]}): {probabilityLetters[j]}");
                            Console.WriteLine();

                            ShannonEntropyOfTheBinaryAlphabet += (probabilityLetters[j] * (Math.Log(probabilityLetters[j])) / Math.Log(2)) * (-1);

                        }
                        Console.WriteLine($"Энтропия бинарного алфавита по Шеннону: {ShannonEntropyOfTheBinaryAlphabet}");
                        break;
                    }
                }
            }
        }

     


        
        

    }
}
