namespace OOP_lab2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //double[][] matrix2 = new double[4][];
            //matrix2[0] = new double[] { 1, 2 };
            //matrix2[1] = new double[] { 3, 4 };
            //matrix2[2] = new double[] { 5, 6 };
            //matrix2[3] = new double[] { 7, 8 };

            string[] matrix2 = new string[3];
            matrix2[0] = "23 12 54";
            matrix2[1] = "66 11 99";
            matrix2[2] = "7 83 44";
            MyMatrix matrix1_2 = new MyMatrix(matrix2);

            StreamReader sr = new StreamReader("C:\\C# Projects\\OOP_lab2_1\\1.txt");
            string matrix1 = sr.ReadToEnd();
            sr.Close();
            MyMatrix matrix1_1 = new MyMatrix(matrix1);
            //Console.WriteLine(matrix1_1);

            //matrix1_1.TransponeMe();
            //Console.WriteLine(matrix1_1);

            //Console.WriteLine(matrix1_1);
            //Console.WriteLine();
            //Console.WriteLine(matrix1_2);
            Console.WriteLine(matrix1_1);
            Console.WriteLine(matrix1_2);
            //MyMatrix sumOfMatrix = matrix1_1 + matrix1_2;
            MyMatrix multiplicationOfMatrices = matrix1_1 * matrix1_2;
            //Console.WriteLine(sumOfMatrix);
            Console.WriteLine(multiplicationOfMatrices);

            Console.WriteLine();
            Console.WriteLine("Determinant m1:" + matrix1_1.CalcDeterminant());
            Console.WriteLine("Determinant m2:" + matrix1_2.CalcDeterminant());

            //matrix1_1[0, 0] = 100;
            //Console.WriteLine(matrix1_1);
            //matrix1_1.TransponeMe();
            //Console.WriteLine(matrix1_1);

            //MyMatrix matrix1_3 = new MyMatrix(matrix3);
            //Console.WriteLine(matrix1_3);
            //Console.WriteLine(matrix1_3.CalcDeterminant());
            //matrix1_3.SetElement(1, 1, 200);
            //Console.WriteLine(matrix1_3.CalcDeterminant());

        }
    }
}
