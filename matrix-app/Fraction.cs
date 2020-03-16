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

            Log("Constructing fraction...");
            Numerator = numerator;
            Denominator = denominator;
            Normalize();
            Log("Fraction constructed.");
        }
        public Fraction(string toConvert) : this(toConvert, false) { }
        public Fraction(string toConvert, bool logging)
        {
            EnableLogging = logging;

            Log("Constructing fraction...");
            ConvertFromString(toConvert);
            Normalize();
            Log("Fraction constructed.");
        }
        public Fraction(double toConvert) : this(toConvert, false) { }
        public Fraction(double toConvert, bool logging)
        {
            EnableLogging = logging;

            Log("Constructing fraction...");
            ConvertFromDouble(toConvert);
            Normalize();
            Log("Fraction constructed.");
        }

        public void ConvertFromString(string toConvert)
        {
            Log("Converting fraction from string...");
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
                        Log("String represents fraction separated by \"/\" symbol.");
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
                        Log("String represents double.");
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
                        Log("String represents double.");
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
                    Log("String represents integer.");
                    Numerator = tNumerator;
                    Denominator = 1;
                }
                else throw notConvertible;
            }

            Log("Converted fraction from string.");
        }

        public void ConvertFromDouble(double toConvert)
        {
            Log("Converting fraction from double...");
            long tDenominator = 1;

            while ((toConvert % 1) != 0)
            {
                toConvert *= 10;
                tDenominator *= 10;
            }

            Numerator = (int)toConvert;
            Denominator = tDenominator;
            Log("Converted fraction from double.");
        }

        public void Display()
        {
            Log("Displaying fraction...");
            Console.WriteLine(Numerator + "/" + Denominator);
            Log("Fraction displayed.");
        }

        public void Normalize()
        {
            Log("Normalizing fraction...");
            long GCD = GetGCD(Numerator, Denominator);
            Log("Found greatest common divisor. It is " + GCD);
            Numerator   /= GCD;
            Denominator /= GCD;
            Log("Fraction normalized.");
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
