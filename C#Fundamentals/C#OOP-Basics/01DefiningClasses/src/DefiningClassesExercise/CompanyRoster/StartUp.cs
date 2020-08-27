using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var name = inputArgs[0];
                var salary = decimal.Parse(inputArgs[1]);
                var position = inputArgs[2];
                var department = inputArgs[3];

                var employee = new Employee(name, salary, position, department);

                if (inputArgs.Length == 5)
                {
                    if (int.TryParse(inputArgs[4], out int result))
                    {
                        employee.Age = result;
                    }
                    else
                    {
                        employee.Email = inputArgs[4];
                    }
                }
                else if (inputArgs.Length == 6)
                {
                    var age = int.Parse(inputArgs[5]);
                    employee.Email = inputArgs[4];
                    employee.Age = age;
                }
                employees.Add(employee);
            }

            var topDepartment = employees
                .GroupBy(e => e.Department)
                .OrderByDescending(e => e.Average(s => s.Salary))
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");

            foreach (var emp in topDepartment.OrderByDescending(d => d.Salary))
            {
                Console.WriteLine($"{emp.Name} {emp.Salary:F2} {emp.Email} {emp.Age}");
            }
        }
    }
}
