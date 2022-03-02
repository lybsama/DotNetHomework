using System;
namespace Problem04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int m, n, num;
            string M, N, Num;
            Console.WriteLine("请输入数组行列数：");
            M = Console.ReadLine();
            m = int.Parse(M);
            N = Console.ReadLine();
            n = int.Parse(N);
            int[,] matrix = new int[m, n];
            Console.WriteLine("请输入数组：");
            for (int i = 0; i < m; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    Num = Console.ReadLine();
                    num = int.Parse(Num);
                    matrix[i, j] = num;
                }

            }
            var res = isToeplitzMatrix(matrix);
            Console.WriteLine(res);
        }
        static bool isToeplitzMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i + 1, j + 1] != matrix[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}