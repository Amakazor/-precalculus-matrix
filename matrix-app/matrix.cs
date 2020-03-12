using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amakazor;

namespace Amakazor
{
    class Matrix : ILoggingInterface
    {
        private List<List<long>> matrixList;
        private int LongestElement;

        public Matrix() : this(0, 0, false) { }
        public Matrix(bool Logging) : this(0, 0, Logging) { }
        public Matrix(int size) : this(size, size, false) { }
        public Matrix(int size, bool Logging) : this(size, size, Logging) { }
        public Matrix(int rows, int columns) : this(rows, columns, false) { }
        public Matrix(int rows, int columns, bool Logging)
        {
            EnableLogging = Logging;
            InitializeRect(rows, columns);
        }
        public Matrix(Matrix toCopy) : this(toCopy, false) { }
        public Matrix(Matrix toCopy, bool Logging)
        {
            EnableLogging = Logging;
            Copy(toCopy);
            EnableLogging = Logging;
        }

        private void InitializeRect(int rows, int columns)
        {
            Log("Constructing matrix...");
            matrixList = new List<List<long>>(rows);
            for (int i = 0; i < rows; i++)
            {
                matrixList.Add(new List<long>(columns));

                for (int j = 0; j < columns; j++)
                {
                    matrixList[i].Add(0);
                }
            }

            LongestElement = CalculateLongestElement();
            Log("Matrix constructed.");
        }

        public bool EnableLogging { get; set; }

        public void Copy(Matrix toCopy, bool isNew = false)
        {
            Log("Copying other matrix...");
            int otherRows = toCopy.GetNumberOfRows();
            int otherColumns = toCopy.GetNumberOfColumns();

            List<List<long>> otherMatrixList = toCopy.MatrixList;

            if (!isNew)
            {
                if (matrixList != null)
                {
                    matrixList.Clear();
                }

                EnableLogging = toCopy.EnableLogging;
            }

            InitializeRect(otherRows, otherColumns);
            
            for (int i = 0; i < otherRows; i++)
            {
                for (int j = 0; j < otherColumns; j++)
                {
                    matrixList[i][j] = otherMatrixList[i][j];
                }
            }

            LongestElement = CalculateLongestElement();
            Log("Other matrix copied.");
        }

        public void Display()
        {
            Log("Displaying matrix...");
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
                            for (int i = 0; i < (LongestElement - CalculateElementLength(column) + (column >= 0 ? 1 : 2)); i++)
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
            Log("Matrix displayed.");
        }

        public int GetNumberOfRows()
        {
            return matrixList.Count;
        }

        public int GetNumberOfColumns()
        {
            if (GetNumberOfRows() > 0)
            {
                return matrixList[0].Count;
            }
            else
            {
                return 0;
            }
        }

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

        public List<List<long>> MatrixList
        {
            get
            {
                return matrixList;
            }
        }

        public void RandomizeMatrix(int minValue, int maxValue)
        {
            Log("Randomizing matrix...");
            Random random = new Random();

            for (int i = 0; i < matrixList.Count; i++)
            {
                for (int j = 0; j < matrixList[i].Count; j++)
                {
                    matrixList[i][j] = random.Next(minValue, maxValue);
                }
            }

            LongestElement = CalculateLongestElement();
            Log("Matrix randomized.");
        }

        private int CalculateLongestElement()
        {
            int maxLenght = 0;

            foreach (List<long> row in matrixList)
            {
                foreach (long column in row)
                {
                    int temp = CalculateElementLength(column);

                    maxLenght = temp > maxLenght ? temp : maxLenght;
                }
            }

            return maxLenght;
        }

        private int CalculateElementLength(long input)
        {
            return (input != 0 ? ((int)Math.Floor(Math.Log10(Math.Abs(input)) + 1)) + (input < 0 ? 1 : 0) : 1);
        }
    }
}
