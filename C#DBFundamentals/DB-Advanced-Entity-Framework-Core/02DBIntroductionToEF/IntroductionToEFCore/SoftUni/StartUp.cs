using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                //GetEmployeesFullInformation(dbContext);
                //GetEmployeesWithSalaryOver50000(dbContext);
                //GetEmployeesFromResearchAandDevelopment(dbContext);
                //GetAddingANewAddressAndUpdatingEmployee(dbContext);
                //GetEmployeeAndProjects(dbContext);
                //GetAddressesByTown(dbContext);
                //GetEmployee147(dbContext);
                //GetDepartmentsWithMoreThan5Employees(dbContext);
                //FindLatest10Projects(dbContext);
                //IncreaseSalaries(dbContext);
                //FindEmployeesByFirstNameStartWithSA(dbContext);
                //DeleteProjectById(dbContext);

                var townName = Console.ReadLine();
                RemoveTowns(dbContext, townName);
            }
        }

        private static void RemoveTowns(SoftUniContext dbContext, string townName)
        {
            dbContext.Employees
                .Where(e => e.Address.Town.Name == townName)
                .ToList()
                .ForEach(e => e.AddressId = null);

            var addressesCount = dbContext.Addresses
                .Where(a => a.Town.Name == townName)
                .Count();

            dbContext.Addresses
                .Where(a => a.Town.Name == townName)
                .ToList()
                .ForEach(a => dbContext.Addresses.Remove(a));

            dbContext.Towns
                .Remove(dbContext.Towns
                    .FirstOrDefault(t => t.Name == townName));

            dbContext.SaveChanges();

            Console.WriteLine($"{addressesCount} {(addressesCount == 1 ? "address" : "addresses")} in {townName} {(addressesCount == 1 ? "was" : "were")} deleted");
        }

        private static void DeleteProjectById(SoftUniContext dbContext)
        {
            var project = dbContext.Projects.First(p => p.ProjectId == 2);

            dbContext.EmployeesProjects
                .ToList()
                .ForEach(ep => dbContext.EmployeesProjects.Remove(ep));
            dbContext.Projects.Remove(project);

            dbContext.SaveChanges();

            dbContext.Projects
                .Take(10)
                .ToList()
                .ForEach(p => Console.WriteLine(p.Name));
        }

        private static void FindEmployeesByFirstNameStartWithSA(SoftUniContext dbContext)
        {
            dbContext.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    e.JobTitle,
                    Salary = $" (${e.Salary:F2})",
                })
                .OrderBy(e => e.Name)
                .ToList()
                .ForEach(e => Console.WriteLine($"{e.Name} - {e.JobTitle} - {e.Salary}"));
        }

        private static void IncreaseSalaries(SoftUniContext dbContext)
        {
            dbContext.Employees
                .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                .Contains(e.Department.Name))
                .ToList()
                .ForEach(e => e.Salary *= 1.12m);

            dbContext.SaveChanges();

            var employees = dbContext.Employees
                .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                .Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    Salary = $" (${e.Salary:F2})",
                })
                .ToList();

            foreach (var e in employees)
            {
                Console.WriteLine(e.Name + e.Salary);
            }

        }

        private static void FindLatest10Projects(SoftUniContext dbContext)
        {
            var projects = dbContext.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                })
                .ToList();

            foreach (var p in projects)
            {
                Console.WriteLine(p.Name + Environment.NewLine);
                Console.WriteLine(p.Description + Environment.NewLine);
                Console.WriteLine(p.StartDate + Environment.NewLine);
            }
        }

        private static void GetDepartmentsWithMoreThan5Employees(SoftUniContext dbContext)
        {
            var departments = dbContext.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    EmployeeName = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle,
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
                })
                .ToList();

            foreach (var d in departments)
            {
                Console.WriteLine($"{d.Name} - {d.ManagerName}");

                foreach (var emp in d.EmployeeName)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }

                Console.WriteLine("----------");
            }
        }

        private static void GetEmployee147(SoftUniContext dbContext)
        {
            var employee = dbContext.Employees
                .Include(ep => ep.EmployeesProjects)
                .ThenInclude(p => p.Project)
                .FirstOrDefault(e => e.EmployeeId == 147);

            Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var p in employee.EmployeesProjects.OrderBy(p => p.Project.Name))
            {
                Console.WriteLine(p.Project.Name);
            }
        }

        private static void GetAddressesByTown(SoftUniContext dbContext)
        {
            var addresses = dbContext.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    a.Town.Name,
                    a.Employees,
                })
                .OrderByDescending(e => e.Employees.Count)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var a in addresses)
            {
                Console.WriteLine($"{a.AddressText}, {a.Name} - {a.Employees.Count} employees");
            }
        }

        private static void GetEmployeeAndProjects(SoftUniContext dbContext)
        {
            var employeeProjects = dbContext.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(e => e.Project)
                .Where(e => e.EmployeesProjects.Any(ep =>
                    ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003
                ))
                .Take(30)
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects.Select(ep => new
                    {
                        ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue ?
                                  ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) :
                                  "not finished"
                    }).ToList()
                })
                .ToList();

            foreach (var e in employeeProjects)
            {
                Console.WriteLine(e.Name + e.ManagerName);
                foreach (var p in e.Projects)
                {
                    Console.WriteLine($" --{p.Name} - {p.StartDate} - {p.EndDate}");
                }
            }
        }

        private static void GetAddingANewAddressAndUpdatingEmployee(SoftUniContext dbContext)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            var setEmployeeAddress = dbContext.Employees.First(e => e.LastName == "Nakov");
            setEmployeeAddress.Address = address;

            dbContext.SaveChanges();

            var employees = dbContext.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            foreach (var e in employees)
            {
                Console.WriteLine(e);
            }
        }

        private static void GetEmployeesFromResearchAandDevelopment(SoftUniContext dbContext)
        {
            var employees = dbContext.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    DepartmentName = e.Department.Name,
                    e.Salary,
                })
                .ToList();

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.Name} from {e.DepartmentName} - ${e.Salary:F2}");
            }
        }

        private static void GetEmployeesWithSalaryOver50000(SoftUniContext dbContext)
        {
            var employeeNames = dbContext.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => e.FirstName)
                .ToList();

            foreach (var name in employeeNames)
            {
                Console.WriteLine(name);
            }
        }

        private static void GetEmployeesFullInformation(SoftUniContext dbContext)
        {
            var employees = dbContext.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName} {e.MiddleName}",
                    e.JobTitle,
                    Salary = $"{e.Salary:F2}",
                })
                .ToList();

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.Name} {e.JobTitle} {e.Salary}");
            }
        }
    }
}
