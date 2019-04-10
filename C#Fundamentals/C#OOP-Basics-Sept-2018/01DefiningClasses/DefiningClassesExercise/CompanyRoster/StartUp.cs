namespace CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbersOfEmployees = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();

            for (int i = 0; i < numbersOfEmployees; i++)
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

            foreach (var employee in topDepartment.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }

            //var numbersOfEmployee = int.Parse(Console.ReadLine());
            //var employees = new List<Employee>();

            //for (int i = 0; i < numbersOfEmployee; i++)
            //{
            //    var employeeInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //    string name = employeeInfo[0];
            //    decimal salary = decimal.Parse(employeeInfo[1]);
            //    string position = employeeInfo[2];
            //    string department = employeeInfo[3];

            //    var currentEmployee = new Employee(name, salary, position, department);

            //    if (employeeInfo.Length == 5)
            //    {
            //        var age = 0;
            //        var isNumber = int.TryParse(employeeInfo[4], out age);

            //        if (isNumber)
            //        {
            //            currentEmployee.Age = age;
            //        }
            //        else
            //        {
            //            currentEmployee.Email = employeeInfo[4];
            //        }
            //    }
            //    else if (employeeInfo.Length == 6)
            //    {
            //        currentEmployee.Email = employeeInfo[4];
            //        currentEmployee.Age = int.Parse(employeeInfo[5]);
            //    }

            //    employees.Add(currentEmployee);
            //}

            //var highestAvgSalaryDepartment = employees
            //                                .GroupBy(e => e.Department)
            //                                .Select(d => new
            //                                {
            //                                    Department = d.Key,
            //                                    AvgSalary = d.Average(emp => emp.Salary),
            //                                    Employees = d.OrderByDescending(emp => emp.Salary)
            //                                })
            //                                .OrderByDescending(d => d.AvgSalary)
            //                                .FirstOrDefault();

            //Console.WriteLine($"Highest Average Salary: {highestAvgSalaryDepartment.Department}");

            //foreach (var employee in highestAvgSalaryDepartment.Employees)
            //{
            //    Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            //}
        }
    }
}