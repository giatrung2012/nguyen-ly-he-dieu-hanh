// class Bai1
// {
//     static Semaphore semaphore = new Semaphore(1, 1);
//     static int na = 0;
//     static int nb = 0;

//     static void Main()
//     {
//         Thread threadA = new Thread(ThreadA);
//         Thread threadB = new Thread(ThreadB);

//         threadA.Start();
//         threadB.Start();

//         threadA.Join();
//         threadB.Join();

//         Console.ReadLine();
//     }

//     static void ThreadA()
//     {
//         for (int i = 1; i <= 100; i++)
//         {
//             semaphore.WaitOne();

//             na = na + 1;
//             Console.Write("na= " + na + "\t");

//             semaphore.Release();

//             Thread.Sleep(100);
//         }
//     }

//     static void ThreadB()
//     {
//         while (true)
//         {
//             semaphore.WaitOne();

//             nb = nb + 1;
//             Console.Write("nb= " + nb + "\t");

//             if (nb == 100)
//             {
//                 semaphore.Release();
//                 break;
//             }

//             Thread.Sleep(100);

//             if (na >= nb && na <= nb + 10)
//             {
//                 semaphore.Release();
//             }
//             else
//             {
//                 nb = nb - 1;
//                 semaphore.Release();
//                 Thread.Sleep(100);
//             }
//         }
//     }
// }
