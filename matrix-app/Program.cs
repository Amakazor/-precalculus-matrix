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
            Fraction frac1 = new Fraction();
            Fraction frac2 = new Fraction(7);
            Fraction frac3 = new Fraction(21,7);
            Fraction frac4 = new Fraction("28.4");
            Fraction frac5 = new Fraction("4/16");
            Fraction frac6 = new Fraction(2.5);

            frac1.Display();
            frac2.Display();
            frac3.Display();
            frac4.Display();
            frac5.Display();
            frac6.Display();

            Console.ReadKey();
        }
    }
}
