using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amakazor
{
    class Fraction : ILoggingInterface
    {
        private long Numerator;
        private long Denominator;

        public Fraction() : this(0, 1, false) { }
        public Fraction(bool logging) : this(0, 1, logging) { }
        public Fraction(long numerator) : this(numerator, 1, false) { }
        public Fraction(long numerator, bool logging) : this(numerator, 1, logging) { }
        public Fraction(long numerator, long denominator) : this(numerator, denominator, false) { }
        public Fraction(long numerator, long denominator, bool logging)
        {
            EnableLogging = logging;

            Numerator = numerator;
            Denominator = denominator;
            Normalize();
        }
        public Fraction(string toConvert) : this(toConvert, false) { }
        public Fraction(string toConvert, bool logging)
        {
            EnableLogging = logging;
            ConvertFromString(toConvert);
            Normalize();
        }
        public Fraction(double toConvert) : this(toConvert, false) { }
        public Fraction(double toConvert, bool logging)
        {
            EnableLogging = logging;
            ConvertFromDouble(toConvert);
            Normalize();
        }

        public void ConvertFromString(string toConvert)
        {
            ArgumentException notConvertible = new ArgumentException("String not convertible", "toConvert");
            char decimalSeparator = Convert.ToChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (toConvert.Contains('/'))
            {
                if (toConvert.IndexOf('/') == toConvert.LastIndexOf('/'))
                {
                    string sNumerator = toConvert.Substring(0, toConvert.IndexOf('/'));
                    string sDenominator = toConvert.Substring(toConvert.IndexOf('/')+1, toConvert.Length - 2);

                    if (long.TryParse(sNumerator, out long tNumerator) && long.TryParse(sDenominator, out long tDenominator))
                    {
                        Numerator = tNumerator;
                        Denominator = tDenominator;
                    }
                    else throw notConvertible;
                }
                else throw notConvertible;
            }
            else if (toConvert.Contains('.'))
            {
                if (toConvert.IndexOf('.') == toConvert.LastIndexOf('.'))
                {
                    if ('.' != decimalSeparator)
                    {
                        toConvert = toConvert.Replace('.', ',');
                    }

                    if (double.TryParse(toConvert, out double dToConvert))
                    {
                        ConvertFromDouble(dToConvert);
                    }
                    else throw notConvertible;
                }
                else throw notConvertible;
            }
            else if (toConvert.Contains(','))
            {
                if (toConvert.IndexOf(',') == toConvert.LastIndexOf(','))
                {
                    if (',' != decimalSeparator)
                    {
                        toConvert = toConvert.Replace(',', '.');
                    }

                    if (double.TryParse(toConvert, out double dToConvert))
                    {
                        ConvertFromDouble(dToConvert);
                    }
                    else throw notConvertible;
                }
                else throw notConvertible;
            }
            else
            {
                if (long.TryParse(toConvert, out long tNumerator))
                {
                    Numerator = tNumerator;
                    Denominator = 1;
                }
                else throw notConvertible;
            }
        }

        public void ConvertFromDouble(double toConvert)
        {
            long tDenominator = 1;

            while ((toConvert % 1) != 0)
            {
                toConvert *= 10;
                tDenominator *= 10;
            }

            Numerator = (int)toConvert;
            Denominator = tDenominator;
        }

        public void Display()
        {
            Console.WriteLine(Numerator + "/" + Denominator);
        }

        public void Normalize()
        {
            long GCD = GetGCD(Numerator, Denominator);
            Numerator   /= GCD;
            Denominator /= GCD;
        }

        public bool EnableLogging { get; set; }

        public void Log(string message)
        {
            if (EnableLogging)
            {
                ConsoleColor CurrentColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = CurrentColor;
            }
        }

        private long GetGCD(long a, long b)
        {
            return b == 0 ? a : GetGCD(b, a % b);
        }
    }
}
