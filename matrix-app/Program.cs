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
            Matrix m1 = new Matrix(4, 6, true);
            m1.RandomizeMatrix(-10, 10);
            m1.Display();

            Matrix m2 = new Matrix(true);
            m2.Copy(m1);
            m2.Display();

            Matrix m3 = new Matrix(3, true);
            m3.RandomizeMatrix(-10, 10);
            m3.Display();

            Matrix m4 = new Matrix(m3, true);
            m4.Display();
            m4.RandomizeMatrix(-10, 10);

            m3.Display();
            m4.Display();

            Matrix m5 = new Matrix(5, 5, true);
            Matrix m6 = new Matrix(5, 5, true);

            m5.RandomizeMatrix(-5, 5);
            System.Threading.Thread.Sleep(10);
            m6.RandomizeMatrix(-5, 5);

            Matrix m7 = m5 + m6;

            m5.Display();
            m6.Display();
            m7.Display();
            
            m5 = new Matrix(5, 5, true);
            m6 = new Matrix(5, 5, true);

            m5.RandomizeMatrix(-5, 5);
            System.Threading.Thread.Sleep(10);
            m6.RandomizeMatrix(-5, 5);

            m7 = m5 - m6;

            m5.Display();
            m6.Display();
            m7.Display();

            Console.ReadKey();
        }
    }
}
