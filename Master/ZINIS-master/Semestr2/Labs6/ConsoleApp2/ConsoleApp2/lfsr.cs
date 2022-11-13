using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class lfsr
    {
        private String encryptedText;
        private String cleanText;
        private String decryptedText;
        private String key;
        private String randomKey;
        private String textKey;

        public String EncryptedText
        {
            get { return encryptedText; }
            set { encryptedText = value; }
        }
        public String CleanText
        {
            get { return cleanText; }
            set { cleanText = value; }
        }
        public String DecryptedText
        {
            get { return decryptedText; }
            set { decryptedText = value; }
        }
        public String Key
        {
            get { return key; }
            set { key = value; }
        }
        public String RandomKey
        {
            get { return randomKey; }
            set { randomKey = value; }
        }
        public String TextKey
        {
            get { return textKey; }
            set { textKey = value; }
        }

        private String getCharTextKey(int ch)
        {
            String charkey = "";
            int a = 0, len = 7;
            while (len >= 0)
            {
                a = ch % 2;
                ch = ch / 2;
                if (a == 0) charkey = charkey.Insert(0, "0");
                else charkey = charkey.Insert(0, "1");
                len--;
            }


            return charkey;
        }
        private void MakeTextKey(String OurText)
        {
            String buff = "";
            for (int i = 0; i < OurText.Length; i++)
            {
                buff = getCharTextKey((int)OurText[i]);
                textKey = textKey.Insert(i * 8, buff);
                buff = "";
            }
        }
        private int xor(int x, int y)
        {
            if (((x == 0) && (y == 0)) || ((x == 1) && (y == 1))) return 0;
            else return 1;
        }
        private int MakeIt(int[] arr)
        {
            int forret = arr[25];
            int result = xor(arr[25], arr[7]);
            result = xor(result, arr[6]);
            result = xor(result, arr[0]);

            for (int i = 1; i < 26; i++) arr[i - 1] = arr[i];

            arr[25] = result;
            return forret;
        }
        private void CreateKey()
        {
            int[] reg = new int[26];
            for (int i = 0; i < 26; i++) reg[i] = (int)(key[i] - 48);
            for (int i = 0; i < (8 * cleanText.Length); i++)
            {
                if (MakeIt(reg) == 0) randomKey = randomKey.Insert(i, "0");
                else randomKey = randomKey.Insert(i, "1");
            }

        }
        private char BinToInt(int[] arr, int k)
        {
            int sum = 0, raz = 1;
            for (int i = 7; i != -1; i--)
            {
                sum += arr[i + k * 8] * raz;
                raz *= 2;
            }
            return (char)sum;
        }
        private void Encrypt()
        {
            encryptedText = "";
            int[] finalkey = new int[randomKey.Length];
            for (int i = 0; i < randomKey.Length; i++)
                finalkey[i] = xor(randomKey[i] - 48, textKey[i] - 48);

            for (int i = 0; i < cleanText.Length; i++)
            {
                encryptedText = encryptedText.Insert(i, BinToInt(finalkey, i).ToString());
            }

        }
        private void Decrypt()
        {
            decryptedText = "";
            MakeTextKey(encryptedText);
            int[] finalkey = new int[randomKey.Length];
            for (int i = 0; i < randomKey.Length; i++)
                finalkey[i] = xor(randomKey[i] - 48, textKey[i] - 48);

            char ch;
            for (int i = 0; i < encryptedText.Length; i++)
            {
                ch = BinToInt(finalkey, i);
                decryptedText = decryptedText.Insert(i, ch.ToString());
            }
        }

        public lfsr(String _text, int k, String _key)
        {
            textKey = "";
            randomKey = "";
            cleanText = "";
            encryptedText = "";
            if (k == 0) decryptedText = _text;
            else encryptedText = _text;
            cleanText = _text;

            key = _key;
            MakeTextKey(cleanText);
            CreateKey();
            Encrypt();
            Decrypt();
        }

    }
}
