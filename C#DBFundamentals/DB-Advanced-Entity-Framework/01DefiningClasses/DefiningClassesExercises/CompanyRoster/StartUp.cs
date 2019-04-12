using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                var employeeInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var employee = new Employee(
                    employeeInfo[0],
                    decimal.Parse(employeeInfo[1]),
                    employeeInfo[2],
                    employeeInfo[3]);

                if (employeeInfo.Length > 4)
                {
                    var ageOrEmail = employeeInfo[4];
                    if (ageOrEmail.Contains("@"))
                    {
                        employee.email = ageOrEmail;
                    }
                    else
                    {

                        employee.age = int.Parse(ageOrEmail);
                    }
                }
                if (employeeInfo.Length > 5)
                {
                    employee.age = int.Parse(employeeInfo[5]);
                }
                employees.Add(employee);
            }

            var result = employees
                .GroupBy(e => e.department)
                .Select(e => new
                {
                    Department = e.Key,
                    AverageSalary = e.Average(emp => emp.salary),
                    Employees = e.OrderByDescending(emp => emp.salary)
                })
                .OrderByDescending(emp => emp.AverageSalary)
                .FirstOrDefault();
            Console.WriteLine($"Highest Average Salary: {result.Department}");

            foreach (var emp in result.Employees)
            {
                Console.WriteLine($"{emp.name} {emp.salary:F2} {emp.email} {emp.age}");
            }
        }
    }
}
