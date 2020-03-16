using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amakazor;

namespace matrix_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction frac1 = new Fraction(true);
            frac1.Display();

            Fraction frac2 = new Fraction(7, true);
            frac2.Display();

            Fraction frac3 = new Fraction(21,7, true);
            frac3.Display();

            Fraction frac4 = new Fraction("28.4", true);
            frac4.Display();

            Fraction frac5 = new Fraction("4/16", true);
            frac5.Display();

            Fraction frac6 = new Fraction(2.5, true);
            frac6.Display();

            Console.ReadKey();
        }
    }
}
