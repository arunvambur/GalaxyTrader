using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GalaxyTrader
{
    /// <summary>
    /// Represents galactic unit of measurement
    /// </summary>
    public class GalacticUnit
    {
        string val;
        string fraction;

        public string Value
        {
            get { return val; }
            set
            {
                Validate(value);
                val = value.ToUpper();
            }
        }

        public string Fraction
        {
            get { return fraction; }
            set
            {
                Validate(value);
                fraction = value.ToUpper();
            }
        }

        public GalacticUnit()
        {
            val = string.Empty;
        }

        public GalacticUnit(string _val)
        {
            if (Validate(_val)) val = _val;
        }

        public GalacticUnit(string _val, string _fraction)
        {
            if (Validate(_val)) val = _val;
            if (Validate(_fraction)) fraction = _fraction;
        }

        public GalacticUnit(int _val)
        {
            if (_val >= 4000)
                throw new ArgumentOutOfRangeException("_val", _val, "Value is >= 4000");

            val = ToGalacticUnit(_val);
        }

        public GalacticUnit(int _val, int _fraction)
        {
            if (_val >= 4000)
                throw new ArgumentOutOfRangeException("_val", _val, "Value should not be >= 4000");

            if (_fraction >= 4000)
                throw new ArgumentOutOfRangeException("_fraction", _fraction, "Fraction should not be >= 4000");

            val = ToGalacticUnit(_val);
            fraction = ToGalacticUnit(_fraction);
        }

        private bool Validate(string _val)
        {
            if (string.IsNullOrEmpty(_val)) return false;

            if(!Regex.Match(_val.ToUpper(), "^(I|V|X|L|C|D|M)+$", RegexOptions.Singleline).Success)
                throw new ArithmeticException("Invalid unit");

            return true;
        }

        private string ToGalacticUnit(int _val)
        {
            string[] thouLetters = { "", "M", "MM", "MMM" };
            string[] hundLetters = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] tensLetters = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] onesLetters = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            string result = "";
            int arabic = _val;

            // Pull out thousands.
            int num;
            num = arabic / 1000;
            result += thouLetters[num];
            arabic %= 1000;

            // Handle hundreds.
            num = arabic / 100;
            result += hundLetters[num];
            arabic %= 100;

            // Handle tens.
            num = arabic / 10;
            result += tensLetters[num];
            arabic %= 10;

            // Handle ones.
            result += onesLetters[arabic];

            return result;
        }

        private int ToValue(char ch)
        {
            switch(ch)
            {
                case 'I':
                case 'i':
                    return 1;
                case 'V':
                case 'v':
                    return 5;
                case 'X':
                case 'x':
                    return 10;
                case 'L':
                case 'l':
                    return 50;
                case 'C':
                case 'c':
                    return 100;
                case 'D':
                case 'd':
                    return 500;
                case 'M':
                case 'm':
                    return 1000;
                default:
                    throw new ArgumentException("Invalid parameter", "ch");
            }
        }

        public int ToArabic()
        {
            if (string.IsNullOrEmpty(val)) return 0;


            int total = 0;
            int last_value = 0;
            for (int i = val.Length - 1; i >= 0; i--)
            {
                int new_value = ToValue(val[i]);

                // See if we should add or subtract.
                if (new_value < last_value)
                    total -= new_value;
                else
                {
                    total += new_value;
                    last_value = new_value;
                }
            }

            // Return the result.
            return total;
        }

        public static GalacticUnit operator +(GalacticUnit a, GalacticUnit b)
        {
            return new GalacticUnit(a.ToArabic() + b.ToArabic());
        }

        public static GalacticUnit operator -(GalacticUnit a, GalacticUnit b)
        {
            return new GalacticUnit(a.ToArabic() - b.ToArabic());
        }

        public static GalacticUnit operator *(GalacticUnit a, GalacticUnit b)
        {
            return new GalacticUnit(a.ToArabic() * b.ToArabic());
        }

        public static GalacticUnit operator /(GalacticUnit a, GalacticUnit b)
        {
            return new GalacticUnit(a.ToArabic() / b.ToArabic());
        }
    }
}
