using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_9
{
    public static class Additions
    {
        public static void EnterLineToFile(string path, string line)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(line, true);
            }
        }
        public static string TextToArbitraryBase(this string text, Mode mode)
        {
            string result = "";

            foreach (var ch in text)
            {
                string buf = ((int)ch).DecimalToArbitrarySystem((int)mode);
                while (buf.Length < Math.Log(256, (int)mode))
                    buf = buf.Insert(0, "0");
                result += buf;
            }

            return result;
        }
        public static string TextFromArbitraryBase(this string abased, Mode mode)
        {
            string result = "";
            
            for (int i = 0; i < abased.Length; i += (int)Math.Log(256, (int)mode))
            {
                string buf = abased.Substring(i, (int)Math.Log(256, (int)mode));
                int num = buf.ArbitraryToDecimalSystem((int)mode);
                result += (char)num;
            }

            return result;
        }
        public static string DecimalToArbitrarySystem(this int decimalNumber, int radix)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " +
                    Digits.Length.ToString());

            if (decimalNumber == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new String(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }

        public static int ArbitraryToDecimalSystem(this string number, int radix)
        {
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " +
                    Digits.Length.ToString());

            if (String.IsNullOrEmpty(number))
                return 0;

            // Make sure the arbitrary numeral system number is in upper case
            number = number.ToUpperInvariant();

            int result = 0;
            int multiplier = 1;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                char c = number[i];
                if (i == 0 && c == '-')
                {
                    // This is the negative sign symbol
                    result = -result;
                    break;
                }

                int digit = Digits.IndexOf(c);
                if (digit == -1)
                    throw new ArgumentException(
                        "Invalid character in the arbitrary numeral system number",
                        "number");

                result += digit * multiplier;
                multiplier *= radix;
            }

            return result;
        }

        public static string GetSplitedString(this string text, int parts)
        {
            string result = "";
            foreach(var str in text.SplitInParts(parts))
            {
                result += str + " ";
            }
            return result;
        }
        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", nameof(partLength));

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }
    }
}
