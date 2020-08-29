using System;
using System.Collections.Generic;

namespace StudentSystem
{
    public class StudentSystem
    {
        private readonly Dictionary<string, Student> students;

        public StudentSystem()
        {
            this.students = new Dictionary<string, Student>();
        }

        public void ParseCommand(string command)
        {
            var commandArgs = command.Split();

            switch (commandArgs[0])
            {
                case "Create":
                    AddStudent(commandArgs);
                    break;
                case "Show":
                    ShowStudent(commandArgs);
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }

        private void ShowStudent(string[] commandArgs)
        {
            var name = commandArgs[1];

            if (students.ContainsKey(name))
            {
                var student = students[name];
                Console.WriteLine(student);
            }
        }

        private void AddStudent(string[] commandArgs)
        {
            var name = commandArgs[1];

            if (!students.ContainsKey(name))
            {
                var age = int.Parse(commandArgs[2]);
                var grade = double.Parse(commandArgs[3]);

                var student = new Student(name, age, grade);
                students.Add(name, student);
            }
        }
    }
}
