using System;
using System.Linq;

namespace Algorithms
{
    class Module1Algorithms
    {
        private static int count;
        public static void Run()
        {
            int[,] matrixA =
            {
                { 1, 1 },
                { 1, 1 },
            };
            int[,] matrixB =
            {
                { 2, 2 },
                { 2, 2 },
            };

            int[,] matrixC = Multiply(matrixA, matrixB);

            for (int row = 0; row < matrixC.GetLength(0); row++)
            {
                for (int col = 0; col < matrixC.GetLength(1); col++)
                {
                    Console.Write(matrixC[row, col] + " ");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("Count " + count);
        }
        static int[,] Multiply(int[,] a, int[,] b)
        {
            count++; // 1
            int n = a.GetLength(0);
            count++; // 1
            Console.WriteLine(n);
            int[,] c = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                count++; // for i
                for (int j = 0; j < n; j++)
                {
                    count++; // for j
                    for (int k = 0; k < n; k++)
                    {
                        count++; // for k
                        count++; // 1
                        c[i, j] += a[i, k] * b[k, j];
                    }
                    count++; // for k
                }
                count++; // for j
            }
            count++; // for i
            count++; // for 1
            return c;
        }
    }
}