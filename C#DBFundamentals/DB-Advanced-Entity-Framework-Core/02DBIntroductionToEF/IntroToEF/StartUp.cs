using IntroToEF.Data;
using IntroToEF.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace IntroToEF
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                //EmployeesFullInformation(context);
                //EmployeesWithSalaryOver50K(context);
                //EmployeesFromResearchAndDevelopment(context);
                //AddingANewAddressAndUpdatingEmployee(context);
                //EmployeesAndProjects(context);
                //AddressesByTown(context);
                //Employee147(context);
                DepartmentsWithMoreThan5Employees(context);
            }
        }

        private static void DepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var dep = context.Departments
                .Include(e => e.Employees)
                .Where(e => e.Employees.Count() > 5)
                .Select(m => new
                {
                    m.Name,
                    m.Manager,
                    m.Employees
                })
                .OrderBy(e => e.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList();

            foreach (var d in dep)
            {
                Console.WriteLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}");

                foreach (var emp in d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }

                Console.WriteLine("----------");
            }
        }

        private static void Employee147(SoftUniContext context)
        {
            var emp147 = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(p => p.Project)
                .FirstOrDefault(e => e.EmployeeId == 147);

            if (emp147 != null)
            {
                Console.WriteLine($"{emp147.FirstName} {emp147.LastName} - {emp147.JobTitle}");
                foreach (var ep in emp147.EmployeesProjects.OrderBy(p => p.Project.Name))
                {
                    Console.WriteLine(ep.Project.Name);
                }
            }
        }

        private static void AddressesByTown(SoftUniContext context)
        {
            var employeeAddress = context.Addresses
                    .Select(e => new
                    {
                        e.AddressText,
                        e.Town.Name,
                        e.Employees
                    })
                    .OrderByDescending(g => g.Employees.Count())
                    .ThenBy(a => a.Name)
                    .ThenBy(a => a.AddressText)
                    .Take(10).ToList();

            foreach (var adr in employeeAddress)
            {
                Console.WriteLine($"{adr.AddressText}, {adr.Name} - {adr.Employees.Count()} employees");
            }
        }

        private static void EmployeesAndProjects(SoftUniContext context)
        {
            var emp = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .Where(e => e.EmployeesProjects.Any
                (p => p.Project.StartDate.Year >= 2001
                   && p.Project.StartDate.Year <= 2003))
                .Take(30)
                .Select(ep => new
                {
                    ep.FirstName,
                    ep.LastName,
                    ep.Manager,
                    ep.EmployeesProjects
                }).ToList();

            string format = "M/d/yyyy h:mm:ss tt";

            foreach (var e in emp)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} - Manager: {e.Manager.FirstName} {e.Manager.LastName}");
                foreach (var ep in e.EmployeesProjects)
                {
                    var startDate = ep.Project.StartDate.ToString(format, CultureInfo.InvariantCulture);

                    var endDate = ep.Project.EndDate.ToString();

                    if (String.IsNullOrWhiteSpace(endDate))
                    {
                        endDate = "not finished";
                    }
                    else
                    {
                        endDate = ep.Project.EndDate.Value.ToString(format, CultureInfo.InvariantCulture);
                    }
                    Console.WriteLine($"--{ep.Project.Name} - {startDate} - {endDate}");
                }
            }
        }

        private static void AddingANewAddressAndUpdatingEmployee(SoftUniContext context)
        {
            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var setEmployeeAddress = context.Employees
                .First(e => e.LastName == "Nakov");

            if (setEmployeeAddress != null)
            {
                setEmployeeAddress.Address = newAddress;
            }

            context.SaveChanges();

            var employeeAddress = context
                    .Employees
                    .OrderByDescending(e => e.AddressId)
                    .Take(10)
                    .Select(e => e.Address.AddressText);

            foreach (var ea in employeeAddress)
            {
                Console.WriteLine(ea);
            }
        }

        private static void EmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var emp = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepName = e.Department.Name,
                    e.Salary
                }).ToList();

            foreach (var e in emp)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} from {e.DepName} - ${e.Salary:F2}");
            }


        }

        private static void EmployeesWithSalaryOver50K(SoftUniContext context)
        {
            var employees = context.Employees
                    .Where(e => e.Salary > 50000)
                    .OrderBy(e => e.FirstName)
                    .Select(e => e.FirstName);

            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
        }

        private static void EmployeesFullInformation(SoftUniContext context)
        {
            var emp = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    Salary = $"{e.Salary:F2}"
                }).ToList();

            foreach (var e in emp)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary}");
            }
        }
    }
}