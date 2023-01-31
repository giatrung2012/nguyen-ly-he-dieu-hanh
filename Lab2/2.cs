// class Student
// {
//     public string? Name { get; set; }
//     public DateTime BirthDay { get; set; }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Thread t1 = new Thread(Print);
//         t1.Start(new Student()
//         {
//             Name = "Yin",
//             BirthDay = new DateTime(1989, 10, 17)
//         });
//         Console.Read();
//     }

//     static void Print(object obj)
//     {
//         Student st = (Student)obj;
//         Console.Write(st.Name + "\t" + st.BirthDay.ToShortDateString());
//     }
// }
