using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab2_1
{
    public partial class MyMatrix
    {
        protected double determinant;
        private bool isModified = true;

        public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.Height != matrix2.Height || matrix1.Width != matrix2.Width)
            {
                throw new Exception("Matrices must be of the same size");
            }
            else
            {
                double[,] sumOfMatrix = new double[matrix1.Height, matrix1.Width];
                
                for (int i = 0; i < matrix1.Height; i++)
                {
                    for (int j = 0; j < matrix1.Width; j++)
                    {
                        sumOfMatrix[i, j] = matrix1.GetElement(i, j) + matrix2.GetElement(i, j);
                    }
                }
                return new MyMatrix(sumOfMatrix);
            }
        }
        public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
        {
            int rowsA = matrix1.Height;
            int colsA = matrix1.Width;
            int rowsB = matrix2.Height;
            int colsB = matrix2.Width;

            if (colsA != rowsB)
            {
                throw new InvalidOperationException("Matrix dimensions do not match for multiplication.");
            }

            double[,] result = new double[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return new MyMatrix(result);
        }
        private double[,] GetTransponedArray()
        {
            double[,] transponedArray = new double[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < transponedArray.GetLength(0); i++)
            {
                for (int j = 0; j < transponedArray.GetLength(1); j++)
                {
                    transponedArray[i, j] = matrix[j, i];
                }
            }
            return transponedArray;
        }
        public MyMatrix GetTransponedCopy()
        {
            return new MyMatrix(GetTransponedArray());
        }
        public void TransponeMe()
        {
            this.matrix = GetTransponedArray();
        }
        public double CalcDeterminant()
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new Exception("Matrix must be square");

            if (!isModified)
            {
                return determinant;
            }

            int n = matrix.GetLength(0);
            determinant = 1;

            double[,] newMatrix = (double[,])matrix.Clone();
            for (int i = 0; i < n; i++)
            {
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(newMatrix[k, i]) > Math.Abs(newMatrix[maxRow, i]))
                    {
                        maxRow = k;
                    }
                }

                if (maxRow != i)
                {
                    SwapRows(newMatrix, i, maxRow);
                    determinant *= -1;
                }

                if (newMatrix[i, i] == 0)
                {
                    bool foundNonZero = false;
                    for (int m = i + 1; m < n; m++)
                    {
                        if (newMatrix[m, i] != 0)
                        {
                            SwapRows(newMatrix, i, m);
                            determinant *= -1;
                            foundNonZero = true;
                            break;
                        }
                    }

                    if (!foundNonZero)
                    {
                        return 0;
                    }
                }

                for (int k = i + 1; k < n; k++)
                {
                    double factor = newMatrix[k, i] / newMatrix[i, i];
                    for (int j = i; j < n; j++)
                    {
                        newMatrix[k, j] -= factor * newMatrix[i, j];
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                determinant *= newMatrix[i, i];
            }

            return determinant;
        }
        static void SwapRows(double[,] matrix, int row1, int row2)
        {
            int n = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                double temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }
    }
}
