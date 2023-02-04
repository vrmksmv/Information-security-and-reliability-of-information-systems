using System;
using System.Diagnostics;
using System.Linq;

//string myFIO = "10011100 10110000 10000000 10000111 10000011 10111010 10011010 10111110 10111101 10000001 10000010 10110000 10111101 10000010 10111000 10111101 10100001 10110101 10000000 10110011 10110101 10110101 10110010 10111000 10000111";
//string[] myFIOArray = myFIO.Split();
//foreach (var item in myFIOArray)
//{
//    //Console.WriteLine(Convert.ToInt32(item, 2));
//    Console.Write(Convert.ToString(Convert.ToInt32(item, 2), 2) + " ");
//    Console.Write(Convert.ToString(Convert.ToInt32(item, 2), 8) + " ");
//    Console.Write(Convert.ToString(Convert.ToInt32(item, 2), 10) + " ");
//    Console.WriteLine(Convert.ToString(Convert.ToInt32(item, 2), 16));
//}

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            int p_LengthFromStart = 0;
            int q_MatchLength = 0;
            string s_LastSymbol = "";

            int N_AlphabetCapacity = 2;
            string baseMessage = "10011100101100001000000010000111100000111011101010011010101111101011110110000001100000101011000010111101100000101011100010111101101000011011010110000000101100111011010110110101101100101011100010000111";
            Console.WriteLine("Длина исходного сообщения = " + baseMessage.Length);
            Console.WriteLine();

            int[] dictionarySizeArray = new int[] { 8, 16, 24, 32, 48, 64 };
            int[] buferSizeArray = new int[] { 8, 16, 24, 32, 48, 64 };

            for (int i = 0; i < dictionarySizeArray.Length; i++)
            {

                int dictionarySize = dictionarySizeArray[i];
                int buferSize = buferSizeArray[i];
                Console.WriteLine("Размер словаря = " + dictionarySize);
                Console.WriteLine("Размер буфера = " + buferSize);

                int buferPaddingLength = (int)Math.Round(Math.Log(buferSize, N_AlphabetCapacity));
                int dictionaryPaddingLength = (int)Math.Round(Math.Log(dictionarySize, N_AlphabetCapacity));

                int l_AlphabetCapacity = ((int)Math.Round(Math.Log(dictionarySize, N_AlphabetCapacity))
                                        + (int)Math.Round(Math.Log(buferSize, N_AlphabetCapacity))
                                        + 1);


                string FIOInASCII = baseMessage;

                if (buferSize > FIOInASCII.Length)
                    throw new ArgumentException("Bufer Size " + buferSize + " is bigger than size of message " + FIOInASCII.Length);

                string window = "";
                string encodedFIO = "";


                window = window.PadLeft(dictionarySize, '0');
                window += FIOInASCII.Substring(0, buferSize);
                FIOInASCII = FIOInASCII.Substring(buferSize, FIOInASCII.Length - buferSize);

                Stopwatch sw = new Stopwatch();
                sw.Start();

                while (FIOInASCII != "" || window.Length > dictionarySize)
                {
                    q_MatchLength = 0;

                    string dictionary = window.Substring(0, dictionarySize);
                    string bufer = window.Substring(dictionarySize, window.Length - dictionarySize);

                    string searchString = bufer.Substring(0, 1);

                    //Console.WriteLine("Dictionary " + dictionary);
                    //Console.WriteLine("Bufer      " + bufer);
                    //Console.WriteLine("encodedFIO " + encodedFIO);

                    while (dictionary.IndexOf(searchString) != -1)
                    {
                        p_LengthFromStart = dictionary.IndexOf(searchString);
                        q_MatchLength++;
                        if (bufer.Length > q_MatchLength)
                            searchString = bufer.Substring(0, q_MatchLength + 1);
                        else break;
                    }
                    if (bufer.Length < q_MatchLength + 1)
                        q_MatchLength = bufer.Length - 1;
                    s_LastSymbol = bufer.Substring(q_MatchLength, 1);


                    string p_encoded = Convert.ToString(p_LengthFromStart, 2);
                    string q_encoded = Convert.ToString(q_MatchLength, 2);
                    p_encoded = p_encoded.PadLeft(dictionaryPaddingLength, '0');
                    q_encoded = q_encoded.PadLeft(buferPaddingLength, '0');

                    encodedFIO += p_encoded + q_encoded + s_LastSymbol;

                    if (FIOInASCII.Length >= (q_MatchLength + 1))
                    {
                        window = window.Substring(q_MatchLength + 1, window.Length - q_MatchLength - 1) + FIOInASCII.Substring(0, q_MatchLength + 1);
                        FIOInASCII = FIOInASCII.Substring(q_MatchLength + 1, FIOInASCII.Length - q_MatchLength - 1);
                    }
                    else
                    {
                        window = window.Substring(q_MatchLength + 1, window.Length - q_MatchLength - 1) + FIOInASCII;
                        FIOInASCII = "";
                    }

                }

                //Console.WriteLine(encodedFIO);
                Console.WriteLine("Длина закодированного сообщения = " + encodedFIO.Length);
                //Console.WriteLine();

                float encodedFIOLength = (float)encodedFIO.Length;

                string decodedFIO = "";

                window = "";
                window = window.PadLeft(dictionarySize, '0');

                p_LengthFromStart = 0;
                q_MatchLength = 0;
                s_LastSymbol = "";
                string encodedCharset = "";

                while (encodedFIO != "")
                {
                    if (encodedFIO.Length >= dictionaryPaddingLength + buferPaddingLength + 1)
                    {
                        encodedCharset = encodedFIO.Substring(0, dictionaryPaddingLength + buferPaddingLength + 1);
                        encodedFIO = encodedFIO.Substring(dictionaryPaddingLength + buferPaddingLength + 1, encodedFIO.Length - dictionaryPaddingLength - buferPaddingLength - 1);
                    }
                    else
                    {
                        encodedCharset = encodedFIO;
                        encodedFIO = "";
                    }
                    if (encodedCharset.Length >= dictionaryPaddingLength)
                    {
                        p_LengthFromStart = Convert.ToInt32(encodedCharset.Substring(0, dictionaryPaddingLength), 2);
                        q_MatchLength = Convert.ToInt32(encodedCharset.Substring(dictionaryPaddingLength, buferPaddingLength), 2);
                        s_LastSymbol = encodedCharset.Last().ToString(); //Substring(dictionaryPaddingLength+ buferPaddingLength, 1);
                    }
                    else
                    {
                        p_LengthFromStart = Convert.ToInt32(encodedCharset.Substring(0, dictionaryPaddingLength), 2);
                        q_MatchLength = Convert.ToInt32(encodedCharset.Substring(dictionaryPaddingLength, buferPaddingLength), 2);
                        s_LastSymbol = encodedCharset.Last().ToString(); //Substring(dictionaryPaddingLength+ buferPaddingLength, 1);
                    }

                    decodedFIO += window.Substring(0, q_MatchLength + 1);
                    window += window.Substring(p_LengthFromStart, q_MatchLength) + s_LastSymbol;
                    window = window.Substring(q_MatchLength + 1, window.Length - q_MatchLength - 1);
                }
                decodedFIO += window;
                decodedFIO = decodedFIO.Substring(dictionarySize, decodedFIO.Length - dictionarySize);

                sw.Stop();

                //Console.WriteLine(decodedFIO);
                //Console.WriteLine(decodedFIO.Length);

                //Console.WriteLine(baseMessage == decodedFIO);

                Console.WriteLine("Степень сжатия = " + baseMessage.Length / encodedFIOLength);
                Console.WriteLine("Затраченное время = " + sw.Elapsed);
                Console.WriteLine();

            }

            Console.ReadLine();
        }
    }
}
