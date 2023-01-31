// class Program
// {
//     static Thread[] arrThread = new Thread[27];
//     static bool isValid = false;
//     static int[,] sudoku = new int[9, 9] {
//         {6, 2, 4, 5, 3, 9, 1, 8, 7},
//         {5, 1, 9, 7, 2, 8, 6, 3, 4},
//         {8, 7, 7, 6, 1, 4, 2, 9, 5},
//         {1, 4, 3, 8, 6, 5, 7, 2, 9},
//         {9, 5, 8, 2, 4, 7, 3, 6, 1},
//         {7, 6, 2, 3, 9, 1, 4, 5, 8},
//         {3, 7, 1, 9, 5, 6, 8, 4, 2},
//         {4, 9, 6, 1, 8, 2, 5, 7, 3},
//         {2, 8, 5, 4, 7, 3, 9, 1, 6}
//     };

//     static void Main(string[] args)
//     {
//         int i, j, z, index = 0;

//         for (i = 0; i < 9; i++)
//         {
//             arrThread[index] = new Thread(CheckRow);
//             arrThread[index++].Start(i);
//         }

//         for (j = 0; j < 9; j++)
//         {
//             arrThread[index] = new Thread(CheckColumn);
//             arrThread[index++].Start(j);
//         }

//         for (z = 0; z < 9; z++)
//         {
//             int r = (z / 3) * 3, c = (z % 3) * 3;
//             arrThread[index] = new Thread(Check3x3);
//             arrThread[index++].Start(new Tuple<int, int>(r, c));
//         }

//         foreach (Thread t in arrThread)
//         {
//             t.Join();
//         }

//         Console.WriteLine(isValid ? "Sudoku Valid!!" : "Sudoku Invalid!!");
//         Console.ReadLine();
//     }

//     static void CheckColumn(object col)
//     {
//         int column = (int)col;
//         for (int i = 0; i < 9; i++)
//         {
//             for (int j = i + 1; j < 9; j++)
//             {
//                 if (sudoku[i, column] < 1 || sudoku[i, column] > 9 || sudoku[i, column] == sudoku[j, column])
//                 {
//                     Console.WriteLine("Invalid in column: " + column);
//                     isValid = false;
//                     return;
//                 }
//             }
//         }
//     }

//     static void CheckRow(object row)
//     {
//         int r = (int)row;
//         for (int i = 0; i < 9; i++)
//         {
//             for (int j = i + 1; j < 9; j++)
//             {
//                 if (sudoku[r, i] < 1 || sudoku[r, i] > 9 || sudoku[r, i] == sudoku[r, j])
//                 {
//                     Console.WriteLine("Invalid in row: " + r);
//                     isValid = false;
//                     return;
//                 }
//             }
//         }
//     }

//     static void Check3x3(object coords)
//     {
//         Tuple<int, int> t = (Tuple<int, int>)coords;
//         int r = t.Item1, c = t.Item2;

//         List<int> values = new List<int>();
//         for (int i = r; i < r + 3; i++)
//         {
//             for (int j = c; j < c + 3; j++)
//             {
//                 if (sudoku[i, j] < 1 || sudoku[i, j] > 9 || values.Contains(sudoku[i, j]))
//                 {
//                     Console.WriteLine("Invalid in 3x3: " + r + ", " + c);
//                     isValid = false;
//                     return;
//                 }
//                 values.Add(sudoku[i, j]);
//             }
//         }
//     }
// }