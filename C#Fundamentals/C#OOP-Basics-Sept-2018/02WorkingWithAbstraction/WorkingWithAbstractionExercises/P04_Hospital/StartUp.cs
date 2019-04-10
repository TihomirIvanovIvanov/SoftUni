namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<Department> departments;
        private static List<Doctor> doctors;

        public static void Main()
        {
            departments = new List<Department>();
            doctors = new List<Doctor>();

            string command;
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var departmentName = commandArgs[0];
                var firstName = commandArgs[1];
                var lastName = commandArgs[2];
                var patient = commandArgs[3];
                var fullName = firstName + lastName;

                var department = GetDepartment(departmentName);
                var doctor = GetDoctor(firstName, lastName);

                bool containsFreeSpace = department
                    .Rooms
                    .Sum(r => r.Patients.Count) < 60;

                if (containsFreeSpace)
                {
                    int targetRoom = 0;

                    doctor.Patients.Add(patient);

                    for (int room = 0; room < department.Rooms.Count; room++)
                    {
                        if (department.Rooms[room].Patients.Count < 3)
                        {
                            targetRoom = room;
                            break;
                        }
                    }
                    department.Rooms[targetRoom].Patients.Add(patient);
                }
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] args = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (args.Length == 1)
                {
                    var department = GetDepartment(args[0]);

                    var roomWithPatients = department
                        .Rooms
                        .Where(r => r.Patients.Count > 0);

                    foreach (var room in roomWithPatients)
                    {
                        foreach (var patient in room.Patients)
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    var department = GetDepartment(args[0]);

                    var theRoom = department
                        .Rooms[room - 1].Patients
                        .OrderBy(r => r);

                    foreach (var name in theRoom)
                    {
                        Console.WriteLine(name);
                    }
                }
                else
                {
                    var firstName = args[0];
                    var lastName = args[1];

                    var doctor = GetDoctor(firstName, lastName);

                    var allDoctorPatients = doctor
                        .Patients
                        .OrderBy(p => p);

                    foreach (var patient in allDoctorPatients)
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
        }

        private static Doctor GetDoctor(string firstName, string lastName)
        {
            var doctor = doctors
                .Where(d => d.FirstName == firstName && d.LastName == lastName)
                .FirstOrDefault();

            if (doctor == null)
            {
                doctor = new Doctor(firstName, lastName);
                doctors.Add(doctor);
            }

            return doctor;
        }

        private static Department GetDepartment(string departmentName)
        {
            var department = departments
                .Where(d => d.Name == departmentName)
                .FirstOrDefault();

            if (department == null)
            {
                department = new Department(departmentName);
                departments.Add(department);

                for (int i = 0; i < 20; i++)
                {
                    department.Rooms.Add(new Room());
                }
            }

            return department;
        }
    }
}