// class Program {
//     static void Main() {
//         Thread t = new Thread(MethodA);
//         t.Start();
//         MethodB();
//     }

//     static void MethodA() {
//         Thread.Sleep(500);
//         for (int i = 0; i < 100; i++)
//         {
//             Console.Write("0");
//         }
//     }

//     static void MethodB() {
//         for (int i = 0; i < 100; i++)
//         {
//             Console.Write("1");
//         }
//     }
// }