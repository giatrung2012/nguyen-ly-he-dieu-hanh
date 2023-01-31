// class Program
// {
//     static void Main(string[] args)
//     {
//         int[,] matrixA = new int[,]
//         {
//                 {1, 2, 3},
//                 {4, 5, 6}
//         };

//         int[,] matrixB = new int[,]
//         {
//                 {7, 8},
//                 {9, 10},
//                 {11, 12}
//         };

//         int[,] result = MultiplyMatrices(matrixA, matrixB);
//         PrintMatrix(result);
//     }

//     private static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
//     {
//         int rowsA = matrixA.GetLength(0);
//         int columnsA = matrixA.GetLength(1);
//         int columnsB = matrixB.GetLength(1);
//         int[,] result = new int[rowsA, columnsB];

//         Parallel.For(0, rowsA, i =>
//         {
//             for (int j = 0; j < columnsB; j++)
//             {
//                 int sum = 0;
//                 for (int k = 0; k < columnsA; k++)
//                 {
//                     sum += matrixA[i, k] * matrixB[k, j];
//                 }
//                 result[i, j] = sum;
//             }
//         });

//         return result;
//     }

//     private static void PrintMatrix(int[,] matrix)
//     {
//         int rows = matrix.GetLength(0);
//         int columns = matrix.GetLength(1);

//         for (int i = 0; i < rows; i++)
//         {
//             for (int j = 0; j < columns; j++)
//             {
//                 Console.Write(matrix[i, j] + " ");
//             }
//             Console.WriteLine();
//         }
//     }
// }