using OOP_lab2_1;
namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void Test_Plus()
        {
            double[,] matrix1 = 
            {
                { 1, 2 },
                { 3, 4 }
            };
            double[,] matrix2 =
            {
                { 5, 6 },
                { 7, 8 }
            };

            double[,] expected = 
            {
                { 6, 8 },
                { 10, 12 }
            };

            MyMatrix matrix_1 = new MyMatrix(matrix1);
            MyMatrix matrix_2 = new MyMatrix(matrix2);
            MyMatrix sumOfMatrices = matrix_1 + matrix_2;

            CollectionAssert.AreEqual(expected, sumOfMatrices.GetMatrix);
        }
        [Test]
        public void Test_Multiply()
        {
            double[,] matrix1 =
            {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            };
            double[,] matrix2 =
            {
                { 8, 10, 12 },
                { 14, 16, 18 }
            };

            double[,] expected =
            {
                { 36, 42, 48 },
                { 80, 94, 108 },
                { 124, 146, 168 }
            };

            MyMatrix matrix_1 = new MyMatrix(matrix1);
            MyMatrix matrix_2 = new MyMatrix(matrix2);
            MyMatrix multiplyOfMatrices = matrix_1 * matrix_2;

            CollectionAssert.AreEqual(expected, multiplyOfMatrices.GetMatrix);
        }
        [Test]
        public void Test_TransponeMe()
        {
            double[,] matrix =
            {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            };
            double[,] expected =
            {
                { 1, 3, 5 },
                { 2, 4, 6 },
            };
            MyMatrix matrix_1 = new MyMatrix(matrix);
            matrix_1.TransponeMe();

            Assert.AreEqual(expected, matrix_1.GetMatrix);
        }
        [Test]
        public void Test_CalcDeterminant()
        {
            double[,] matrix =
            {
                { 4, 23, 12 },
                { 89, 21, 44 },
                { 99, 65, 32 }
            };
            double expected = 70404;
            double delta = 0.001;
            MyMatrix matrix_1 = new MyMatrix(matrix);

            Assert.AreEqual(expected, matrix_1.CalcDeterminant(), delta);
        }
    }
}