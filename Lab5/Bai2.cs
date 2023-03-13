// class Bai2
// {
//     static async Task Main(string[] args)
//     {
//         int x1 = 2;
//         int x2 = 3;
//         int x3 = 4;
//         int x4 = 5;
//         int x5 = 6;
//         int x6 = 7;

//         int w = 0;
//         int v = 0;
//         int y = 0;
//         int z = 0;
//         int ans = 0;

//         // Thread 1
//         w = x1 * x2;

//         // Thread 2
//         v = x3 * x4;

//         // Thread 3
//         v = await Task.Run(() => v * x5);

//         // Thread 4
//         z = await Task.Run(() => v * x6);

//         // Thread 5
//         y = await Task.Run(() => w * y);

//         // Thread 6
//         z = await Task.Run(() => w * z);

//         // Thread 7
//         ans = y + z;

//         Console.WriteLine($"The result is {ans}");
//     }
// }
