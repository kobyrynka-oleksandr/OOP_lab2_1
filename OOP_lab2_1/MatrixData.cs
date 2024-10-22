using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab2_1
{
    public partial class MyMatrix
    {
        protected double[,] matrix;

        public MyMatrix(double[,] matrix)
        {
            this.matrix = matrix;
        }

        public MyMatrix(MyMatrix newMatrix)
        {
            double[,] _matrix = new double[newMatrix.Height, newMatrix.Width];
            
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    _matrix[i, j] = newMatrix[i, j];
                }
            }

            matrix = _matrix;
        }

        public MyMatrix(double[][] jaggedArray)
        {
            if (JaggedIsRectangular(jaggedArray))
            {
                matrix = JuggedArrayTo2DArray(jaggedArray);
            }
            else
            {
                throw new Exception("Jagged array cannot be converted to a rectangular matrix");
            }
        }

        public MyMatrix(string[] stringArray)
        {
            if (StringIsRectangular(stringArray))
            {
                matrix = StringArrayToMatrix(stringArray);
            }
            else
            {
                throw new Exception("String array cannot be converted to a rectangular matrix");
            }
        }
        
        public MyMatrix(string input)
        {
            matrix = StringToMatrix(input);
        }

        private bool JaggedIsRectangular(double[][] jaggedArray)
        {
            if (jaggedArray == null || jaggedArray.Length == 0)
                return false;

            int firstRowLength = jaggedArray[0].Length;

            for (int i = 1; i < jaggedArray.Length; i++)
            {
                if (jaggedArray[i].Length != firstRowLength)
                {
                    return false;
                }
            }
            return true;
        }
        private double[,] JuggedArrayTo2DArray(double[][] jaggedArray)
        {
            int maxRowLength = jaggedArray.Max(row => row.Length);

            double[,] newMatrix = new double[jaggedArray.Length, maxRowLength];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    newMatrix[i, j] = jaggedArray[i][j];
                }
            }

            return newMatrix;
        }
        private bool StringIsRectangular(string[] stringArray)
        {
            if (stringArray == null || stringArray.Length == 0)
                return false;

            int firstRowLength = stringArray[0].Split().Length;

            for (int i = 1; i < stringArray.Length; i++)
            {
                if (stringArray[i].Split().Length != firstRowLength)
                {
                    return false;
                }
            }
            return true;
        }
        private double[,] StringArrayToMatrix(string[] stringArray)
        {
            double[,] newMatrix = new double[stringArray.Length, stringArray[0].Split().Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                string[] row = stringArray[i].Split();

                for (int j = 0; j < row.Length; j++)
                {
                    try
                    {
                        newMatrix[i, j] = double.Parse(row[j]);
                    }
                    catch
                    {
                        throw new Exception("Element is not a number");
                    }
                }
            }

            return newMatrix;
        }
        private double[,] StringToMatrix(string input)
        {
            char[] charSeparatorsForRows = new char[] { '\n', '\r' };
            string[] rows = input.Split(charSeparatorsForRows, StringSplitOptions.RemoveEmptyEntries);

            char[] charSeparators = new char[] { ' ', '\t' };
            string[] firstRowString = rows[0].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            double[] firstRow = Array.ConvertAll(firstRowString, double.Parse);
            int columnsCount = firstRow.Length;

            double[,] newMatrix = new double[rows.Length, columnsCount];

            for (int i = 0; i < rows.Length; i++)
            {
                string[] numbersString = rows[i].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                double[] numbers = Array.ConvertAll(numbersString, double.Parse);

                if (numbers.Length != columnsCount)
                {
                    throw new Exception("String cannot be converted to a rectangular matrix");
                }

                for (int j = 0; j < columnsCount; j++)
                {
                    newMatrix[i, j] = numbers[j];
                }
            }

            return newMatrix;
        }

        public int Height
        {
            get
            {
                return matrix.GetLength(0);
            }
        }
        public int Width
        {
            get
            {
                return matrix.GetLength(1);
            }
        }

        public int getHeight()
        {
            return matrix.GetLength(0);
        }
        public int getWidth()
        {
            return matrix.GetLength(1);
        }

        public double this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1))
                    return matrix[i, j];
                else
                    throw new Exception("Element with this index does not exist");
            }
            set
            {
                if (i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1))
                    matrix[i, j] = value;
                else
                    throw new Exception("Invalid element");
            }
        }
        public double GetElement(int i, int j)
        {
            if (i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1))
                return matrix[i, j];
            else
                throw new Exception("Element with this index does not exist");
        }
        public void SetElement(int i, int j, double value)
        {
            if (i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1))
            {
                matrix[i, j] = value;
                isModified = true;
            }
            else
                throw new Exception("Invalid element");
        }
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j] + "\t");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
        public double[,] GetMatrix
        {
            get
            {
                return matrix;
            }
        }
    }
}
