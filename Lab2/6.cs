// class Program
// {
//     static void Main()
//     {
//         ThreadPool.QueueUserWorkItem(ThreadProc);
//         ThreadPool.QueueUserWorkItem(ThreadProc, 123);
//         Console.ReadLine();
//     }

//     static void ThreadProc(object? data)
//     {
//         for (int i = 0; i < 10; i++)
//         {
//             Console.WriteLine($"Thread callback: {data}");
//             Thread.Sleep(500);
//         }
//     }
// }
