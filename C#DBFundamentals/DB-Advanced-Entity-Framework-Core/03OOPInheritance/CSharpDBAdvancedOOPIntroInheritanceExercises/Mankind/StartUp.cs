using System;

namespace Mankind
{
    public class StartUp
    {
        public static void Main()
        {
            string[] student = Console.ReadLine().Split();
            string studFirstName = student[0];
            string studLastName = student[1];
            string facultyNumber = student[2];

            string[] worker = Console.ReadLine().Split();
            string workFirstName = worker[0];
            string workLastName = worker[1];
            var weekSalary = decimal.Parse(worker[2]);
            var workHours = double.Parse(worker[3]);

            try
            {
                var students = new Student(studFirstName, studLastName, facultyNumber);
                var workers = new Worker(workFirstName, workLastName, weekSalary, workHours);

                Console.WriteLine(students);
                Console.WriteLine(workers);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
