using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RomanNumbersCalculator.Models
{
    internal class RomanNumber : IComparable, ICloneable
    {
        private ushort arabic = 0;
        private string roman = "";
        private readonly static Dictionary<ushort, string> ra = new Dictionary<ushort, string>
    { { 1000, "M" },  { 900, "CM" },  { 500, "D" },  { 400, "CD" },  { 100, "C" },
                      { 90 , "XC" },  { 50 , "L" },  { 40 , "XL" },  { 10 , "X" },
                      { 9  , "IX" },  { 5  , "V" },  { 4  , "IV" },  { 1  , "I" } };

        private static string ToRoman(int number) => ra
            .Where(d => number >= d.Key)
            .Select(d => d.Value + ToRoman(number - d.Key))
            .FirstOrDefault();
        private static ushort ToArabic(string number) => (ushort)(number.Length == 0 ? 0 : ra
            .Where(d => number.StartsWith(d.Value))
            .Select(d => d.Key + ToArabic(number.Substring(d.Value.Length)))
            .First());

        public RomanNumber(ushort number)
        {
            if (number is < 1 or > 3999) throw new RomanNumberException();
            arabic = number;
            roman = ToRoman(number);
        }

        public RomanNumber(string number)
        {
            roman = number;
            arabic = ToArabic(number);
            if (number != new RomanNumber(arabic).ToString()) throw new RomanNumberException();
            if (arabic is < 1 or > 3999) throw new RomanNumberException();
        }

        public static RomanNumber Add(RomanNumber RomanNumber1, RomanNumber RomanNumber2) => new RomanNumber((ushort)(RomanNumber1.arabic + RomanNumber2.arabic));
        public static RomanNumber Sub(RomanNumber RomanNumber1, RomanNumber RomanNumber2) => new RomanNumber((ushort)(RomanNumber1.arabic - RomanNumber2.arabic));
        public static RomanNumber Mul(RomanNumber RomanNumber1, RomanNumber RomanNumber2) => new RomanNumber((ushort)(RomanNumber1.arabic * RomanNumber2.arabic));
        public static RomanNumber Div(RomanNumber RomanNumber1, RomanNumber RomanNumber2) => new RomanNumber((ushort)(RomanNumber1.arabic / RomanNumber2.arabic));

        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber num) return arabic.CompareTo(num.arabic);
            else throw new ArgumentException("Unable to compare this parameter.");
        }
        public object Clone() => MemberwiseClone();
        public override string ToString() => roman;
        public ushort ToUInt16() => arabic;
    }
}
