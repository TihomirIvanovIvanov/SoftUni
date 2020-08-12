using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (students.ContainsKey(input[0]))
                {
                    students[input[0]].Add(double.Parse(input[1]));
                }
                else
                {
                    students[input[0]] = new List<double>
                    {
                        double.Parse(input[1])
                    };
                }
            }

            foreach (var student in students)
            {
                var grades = student.Value.Select(x => x.ToString("F2"));

                Console.WriteLine($"{student.Key} -> {string.Join(' ', grades)} (avg: {student.Value.Average():F2})");
            }
        }
    }
}
