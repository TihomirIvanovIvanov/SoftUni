namespace Mankind
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var studentInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var workerInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var studentFirstName = studentInput[0];
                var studentLastName = studentInput[1];
                var studentFacultyNumber = studentInput[2];

                var student = new Student(studentFirstName, studentLastName, studentFacultyNumber);

                var workerFirstName = workerInput[0];
                var workerLastName = workerInput[1];
                var workerWeekSalary = decimal.Parse(workerInput[2]);
                var workerHoursPerDay = decimal.Parse(workerInput[3]);

                var worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}