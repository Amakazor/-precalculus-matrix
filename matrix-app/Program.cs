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


            Console.ReadKey();
        }
    }
}
