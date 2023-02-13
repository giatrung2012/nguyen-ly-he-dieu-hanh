// namespace ExclusivePriorityDispatch
// {
//     class Bai3p1
//     {
//         static void Main(string[] args)
//         {
//             List<Job> jobs = new List<Job>()
//             {
//                 new Job("Job1", 10, 1),
//                 new Job("Job2", 5, 2),
//                 new Job("Job3", 15, 3),
//                 new Job("Job4", 20, 1)
//             };

//             Console.WriteLine("Exclusive Priority Dispatch:");
//             Console.WriteLine("Job\tBurst Time\tPriority");

//             // Sort the jobs based on priority
//             jobs.Sort((x, y) => x.Priority.CompareTo(y.Priority));

//             int totalTime = 0;
//             foreach (var job in jobs)
//             {
//                 totalTime += job.BurstTime;
//                 Console.WriteLine(job.Name + "\t" + job.BurstTime + "\t\t" + job.Priority);
//             }

//             Console.WriteLine("\nTotal time taken: " + totalTime);
//         }
//     }

//     class Job
//     {
//         public string Name { get; set; }
//         public int BurstTime { get; set; }
//         public int Priority { get; set; }

//         public Job(string name, int burstTime, int priority)
//         {
//             Name = name;
//             BurstTime = burstTime;
//             Priority = priority;
//         }
//     }
// }