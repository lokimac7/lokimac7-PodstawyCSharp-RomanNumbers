using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            RomanNumbers rn = new RomanNumbers();
            Console.WriteLine(rn.RomanToInt("MCLIV"));
            Console.WriteLine(rn.RomanToInt("MMMDCLXII"));
            Console.WriteLine(rn.RomanToInt("MDCCLXXVIII"));
            Console.WriteLine(rn.RomanToInt("MMDCXXXVII"));

            Console.ReadKey();
        }
    }

    public class RomanNumbers
    {
        public int RomanToInt(string s)
        {
            List<RomanDigit> romanDigits = new List<RomanDigit>
        {
            new RomanDigit{Symbol = 'I', Value = 1},
            new RomanDigit{Symbol = 'V', Value = 5},
            new RomanDigit{Symbol = 'X', Value = 10},
            new RomanDigit{Symbol = 'L', Value = 50},
            new RomanDigit{Symbol = 'C', Value = 100},
            new RomanDigit{Symbol = 'D', Value = 500},
            new RomanDigit{Symbol = 'M', Value = 1000}
        };

            int sum = (romanDigits.Where(x => x.Symbol == s[s.Length -1]).FirstOrDefault()).Value;
            for (int i = s.Length - 2; i >= 0; i--)
            {
                if ((romanDigits.Where(x => x.Symbol == s[i]).FirstOrDefault()).Value >= (romanDigits.Where(x => x.Symbol == s[i + 1]).FirstOrDefault()).Value)
                    sum += (romanDigits.Where(x => x.Symbol == s[i]).FirstOrDefault()).Value;
                else
                    sum -= (romanDigits.Where(x => x.Symbol == s[i]).FirstOrDefault()).Value;
            }
            return sum;
        }
    }

    public class RomanDigit
    {
        public char Symbol { get; set; }
        public int Value { get; set; }
    }
}
