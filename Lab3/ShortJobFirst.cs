// namespace ShortJobFirst
// {
//     class ShortJobFirst
//     {
//         static void Main(string[] args)
//         {
//             List<Job> jobs = new List<Job>()
//             {
//                 new Job("Job1", 10),
//                 new Job("Job2", 5),
//                 new Job("Job3", 15),
//                 new Job("Job4", 20)
//             };

//             Console.WriteLine("Short Job First (SJF):");
//             Console.WriteLine("Job\tBurst Time");

//             // Sort the jobs based on burst time
//             jobs.Sort((x, y) => x.BurstTime.CompareTo(y.BurstTime));

//             int totalTime = 0;
//             foreach (var job in jobs)
//             {
//                 totalTime += job.BurstTime;
//                 Console.WriteLine(job.Name + "\t" + job.BurstTime);
//             }

//             Console.WriteLine("\nTotal time taken: " + totalTime);
//         }
//     }

//     class Job
//     {
//         public string Name { get; set; }
//         public int BurstTime { get; set; }

//         public Job(string name, int burstTime)
//         {
//             Name = name;
//             BurstTime = burstTime;
//         }
//     }
// }