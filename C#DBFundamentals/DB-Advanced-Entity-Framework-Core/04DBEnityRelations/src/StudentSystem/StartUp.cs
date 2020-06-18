using StudentSystem.Data;
using StudentSystem.Data.Models;
using System;

namespace StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new StudentSystemContext();
            dbContext.Database.EnsureCreated();
            Seed(dbContext);
        }

        private static void Seed(StudentSystemContext dbContext)
        {
            var students = new[]
            {
                new Student
                {
                    Name = "Pesho",
                    BirthDay = DateTime.UtcNow.AddYears(-20),
                    PhoneNumber = "123",
                    RegistratedOn = DateTime.UtcNow,
                },
                new Student
                {
                    Name = "Gosho",
                    BirthDay = DateTime.UtcNow.AddYears(-30),
                    PhoneNumber = "456",
                    RegistratedOn = DateTime.UtcNow,
                },
            };

            dbContext.AddRange(students);

            var couses = new[]
            {
                new Course
                {
                    Name = "C#",
                    Description = "C# desc",
                    StartDate = DateTime.UtcNow,
                    Price = 250.00m,
                    EndDate = DateTime.UtcNow.AddMonths(4),
                },
                new Course
                {
                    Name = "C# Web",
                    Description = "web desc",
                    StartDate = DateTime.UtcNow,
                    Price = 350.00m,
                    EndDate = DateTime.UtcNow.AddMonths(6),
                },
                new Course
                {
                    Name = "C# Database Advanced",
                    Description = "db desc",
                    StartDate = DateTime.UtcNow,
                    Price = 150.00m,
                    EndDate = DateTime.UtcNow.AddMonths(2),
                },
            };

            dbContext.AddRange(couses);

            var resources = new[]
            {
                new Resource
                {
                    Course = couses[0],
                    Name = "oop",
                    ResourceType = ResourceType.Presentation,
                    Url = "src/resources/oop",
                },
                new Resource
                {
                    Course = couses[1],
                    Name = "web",
                    ResourceType = ResourceType.Video,
                    Url = "src/resources/web",
                },
            };

            dbContext.Resources.AddRange(resources);

            var homeworks = new[]
            {
                new Homework
                {
                    Content = "entities ralations homework",
                    ContentType = ContentType.Zip,
                    Course = couses[2],
                    Student = students[0],
                    SubmissionTime = DateTime.UtcNow.AddHours(3),
                },
                new Homework
                {
                    Content = "entities ralations classwork",
                    ContentType = ContentType.Pdf,
                    Course = couses[1],
                    Student = students[1],
                    SubmissionTime = DateTime.UtcNow.AddHours(1),
                },
            };

            dbContext.Homeworks.AddRange(homeworks);

            dbContext.SaveChanges();
        }
    }
}
