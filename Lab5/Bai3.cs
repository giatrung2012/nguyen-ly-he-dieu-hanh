// class Bai3
// {
//     static int[]? X;
//     static int n;

//     static int evenSum = 0;
//     static int oddSum = 0;
//     static int totalSum = 0;

//     static void Main(string[] args)
//     {
//         Console.Write("Enter the number of elements in the array: ");
//         n = Convert.ToInt32(Console.ReadLine());

//         X = new int[n];

//         for (int i = 0; i < n; i++)
//         {
//             Console.Write($"Enter element {i + 1}: ");
//             X[i] = Convert.ToInt32(Console.ReadLine());
//         }

//         Thread ThreadA = new Thread(new ThreadStart(SumEven));
//         Thread ThreadB = new Thread(new ThreadStart(SumOdd));
//         Thread ThreadC = new Thread(new ThreadStart(SumTotal));

//         ThreadA.Start();
//         ThreadB.Start();
//         ThreadC.Start();

//         ThreadA.Join();
//         ThreadB.Join();
//         ThreadC.Join();

//         Console.WriteLine($"Sum of even elements: {evenSum}");
//         Console.WriteLine($"Sum of odd elements: {oddSum}");
//         Console.WriteLine($"Total sum: {totalSum}");
//     }

//     static void SumEven()
//     {
//         for (int i = 0; i < n; i++)
//         {
//             if (X[i] % 2 == 0)
//             {
//                 evenSum += X[i];
//             }
//         }
//     }

//     static void SumOdd()
//     {
//         for (int i = 0; i < n; i++)
//         {
//             if (X[i] % 2 != 0)
//             {
//                 oddSum += X[i];
//             }
//         }
//     }

//     static void SumTotal()
//     {
//         totalSum = evenSum + oddSum;
//     }
// }
