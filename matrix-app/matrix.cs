using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amakazor.Matrix
{
    class Matrix
    {
        private List<List<long>> matrixList;
        private int LongestElement;

        public Matrix()
        {
            matrixList = new List<List<long>>();
            LongestElement = 0;
        }

        public Matrix(int size)
        {
            matrixList = new List<List<long>>(size);
            for (int i = 0; i < size; i++)
            {
                matrixList.Add(new List<long>(size));

                for (int j = 0; j < size; j++)
                {
                    matrixList[i].Add(0);
                }
            }

            this.LongestElement = CalculateLongestElement();
        }

        public Matrix(int rows, int columns)
        {
            matrixList = new List<List<long>>(rows);
            for (int i = 0; i < rows; i++)
            {
                matrixList.Add(new List<long>(columns));

                for (int j = 0; j < columns; j++)
                {
                    matrixList[i].Add(0);
                }
            }

            this.LongestElement = CalculateLongestElement();
        }

        public void Display()
        {
            if (matrixList.Count > 0)
            {
                Console.Write('\u250C');
                for (int i = 0; i < GetNumberOfColumns() * (LongestElement + 2) + 1; i++)
                {
                    Console.Write(' ');
                }
                Console.Write('\u2510');
                Console.Write('\n');

                foreach (List<long> row in matrixList)
                {
                    Console.Write("\u2502 ");
                    if (row.Count > 0)
                    {
                        foreach (long column in row)
                        {
                            Console.Write((column >= 0 ? " " : "")+column);
                            for (int i = 0; i < (LongestElement - CalculateLongLength(column) + (column >= 0 ? 1 : 2)); i++)
                            {
                                Console.Write(' ');
                            }
                        }
                    }
                    Console.Write("\u2502");
                    Console.Write('\n');
                }

                Console.Write('\u2514');
                for (int i = 0; i < GetNumberOfColumns() * (LongestElement + 2) + 1; i++)
                {
                    Console.Write(' ');
                }
                Console.Write('\u2518');
                Console.Write('\n');
            }
        }

        public int GetNumberOfColumns()
        {
            if (matrixList.Count > 0)
            {
                return matrixList[0].Count;
            }
            else
            {
                return 0;
            }
        }

        public void RandomizeMatrix(int minValue, int maxValue)
        {
            Random random = new Random();

            for (int i = 0; i < matrixList.Count; i++)
            {
                for (int j = 0; j < matrixList[i].Count; j++)
                {
                    matrixList[i][j] = random.Next(minValue, maxValue);
                }
            }

            this.LongestElement = CalculateLongestElement();
        }

        private int CalculateLongestElement()
        {
            int maxLenght = 0;

            foreach (List<long> row in matrixList)
            {
                foreach (long column in row)
                {
                    int temp = CalculateLongLength(column);

                    maxLenght = temp > maxLenght ? temp : maxLenght;
                }
            }

            return maxLenght;
        }


        private int CalculateLongLength(long input)
        {
            return (input != 0 ? ((int)Math.Floor(Math.Log10(Math.Abs(input)) + 1)) + (input < 0 ? 1 : 0) : 1);
        }
    }
}
