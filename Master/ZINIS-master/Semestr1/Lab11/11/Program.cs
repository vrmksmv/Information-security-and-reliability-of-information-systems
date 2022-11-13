using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    public class SymbolWithCode
    {
        public SymbolWithCode(char s, int cnt, double p, string c)
        {
            this.symbol = s;
            this.count = cnt;
            this.probalility = p;
            this.code = c;
            this.section_a = 0;
            this.section_b = 0;
        }
        public char symbol;
        public int count;
        public double probalility;
        public string code;
        public double section_a;
        public double section_b;

        public static void ShowSymbolsWithCodes(List<SymbolWithCode> symbolsWithCodes)
        {
            foreach (var symbolWithCode in symbolsWithCodes)
            {
                Console.WriteLine("{0} {1} {2} {3} [ {4} - {5} ]",
                                  symbolWithCode.symbol,
                                  symbolWithCode.count,
                                  symbolWithCode.probalility,
                                  symbolWithCode.code,
                                  symbolWithCode.section_a,
                                  symbolWithCode.section_b
                                  );
            }
            Console.WriteLine();
        }

        public static List<SymbolWithCode> AddSymbolsOfLine(List<SymbolWithCode> symbolsWithCodes, string line)
        {
            foreach (var character in line)
            {
                if (symbolsWithCodes.Find(x => x.symbol == character) == null)
                {
                    symbolsWithCodes.Add(new SymbolWithCode(character, 1, 0, ""));
                }
                else
                {
                    symbolsWithCodes.Where(x => x.symbol == character).ToList().ForEach(x => x.count++);
                }
            }
            return symbolsWithCodes;
        }
    }
    class Program
    {
        public static List<SymbolWithCode> AddCodes(List<SymbolWithCode> symbolsWithCodes)
        {
            int counter = 0;
            double probability = 0;
            List<SymbolWithCode> firstPartOfSymbolsWithCodes = new List<SymbolWithCode>();
            List<SymbolWithCode> secondPartOfSymbolsWithCodes = new List<SymbolWithCode>();

            while (probability < (symbolsWithCodes.Sum(x => x.probalility) / 2))
            {
                probability += symbolsWithCodes[counter].probalility;
                counter++;
            }
            if (counter > 1)
                counter--;
            for (int i = 0; i < counter; i++)
            {
                symbolsWithCodes[i].code += "0";
                firstPartOfSymbolsWithCodes.Add(symbolsWithCodes[i]);
            }
            for (int i = counter; i < symbolsWithCodes.Count; i++)
            {
                symbolsWithCodes[i].code += "1";
                secondPartOfSymbolsWithCodes.Add(symbolsWithCodes[i]);
            }
            if (symbolsWithCodes.Count > 1)
            {
                firstPartOfSymbolsWithCodes = AddCodes(firstPartOfSymbolsWithCodes);
                secondPartOfSymbolsWithCodes = AddCodes(secondPartOfSymbolsWithCodes);

                firstPartOfSymbolsWithCodes.AddRange(secondPartOfSymbolsWithCodes);

                symbolsWithCodes = firstPartOfSymbolsWithCodes;
            }

            return symbolsWithCodes;
        }
        static void Main(string[] args)
        {

            string[] names = { "молоко", "водоворотоподобный", "водоворотоподобныйсамообороноспособность" };
            foreach (var name in names)
            {

                List<SymbolWithCode> symbolsWithCodes = new List<SymbolWithCode>();
                symbolsWithCodes = SymbolWithCode.AddSymbolsOfLine(symbolsWithCodes, name);
                SymbolWithCode.ShowSymbolsWithCodes(symbolsWithCodes);

                double sumChars = symbolsWithCodes.Sum(x => x.count);

                for (int i = 0; i < symbolsWithCodes.Count; i++)
                {
                    symbolsWithCodes[i].probalility = symbolsWithCodes[i].count / sumChars;
                }
                symbolsWithCodes = symbolsWithCodes.OrderBy(x => x.probalility).ToList();
                SymbolWithCode.ShowSymbolsWithCodes(symbolsWithCodes);

                double b = 0;
                for (int i = 0; i < symbolsWithCodes.Count; i++)
                {
                    symbolsWithCodes[i].section_a = b;
                    b += symbolsWithCodes[i].probalility;
                    symbolsWithCodes[i].section_b = b;
                }
                SymbolWithCode.ShowSymbolsWithCodes(symbolsWithCodes);


                double L = 0, H = 0, L0 = 0, H0 = 0, L1 = 0, H1 = 0;
                double sec_a, sec_b;
                L0 = symbolsWithCodes.Find(x => x.symbol == name[0]).section_a;
                H0 = symbolsWithCodes.Find(x => x.symbol == name[0]).section_b;
                for (int i = 1; i < name.Length; i++)
                {
                    sec_a = symbolsWithCodes.Find(x => x.symbol == name[i]).section_a;
                    sec_b = symbolsWithCodes.Find(x => x.symbol == name[i]).section_b;

                    L1 = L0 + (H0 - L0) * sec_a;
                    H1 = L0 + (H0 - L0) * sec_b;

                    L0 = L1;
                    H0 = H1;
                    //Console.WriteLine(H1 - L1);
                    Console.WriteLine("[{0} - {1}]", L1, H1);
                }
                Console.WriteLine("Нижняя граница, являющаяся итогом кодирования = {0}", L1);

                string newName = "";
                SymbolWithCode newSymbol;
                for (int i = 0; i < name.Length; i++)
                {
                    newSymbol = symbolsWithCodes.Find(x => (L1 <= x.section_b) && (L1 >= x.section_a));
                    //newSymbol = symbolsWithCodes.Find(x => (L1 <= x.section_b));
                    sec_a = newSymbol.section_a;
                    sec_b = newSymbol.section_b;
                    newName += newSymbol.symbol;

                    L1 = (L1 - sec_a) / (sec_b - sec_a);
                }
                Console.WriteLine("Декодированное сообщение - {0}", newName);
            }
        }
    }
}
