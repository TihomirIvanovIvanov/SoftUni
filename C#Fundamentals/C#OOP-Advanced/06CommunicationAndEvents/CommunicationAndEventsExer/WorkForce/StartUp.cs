using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        JobsList jobs = new JobsList();
        IList<IEmployee> employees = new List<IEmployee>();

        string[] input = Console.ReadLine().Split();

        while (!input[0].Equals("End"))
        {
            switch (input[0])
            {
                case "Job":
                    Job currentJob = new Job(input[1], int.Parse(input[2]), employees.FirstOrDefault(e => e.Name.Equals(input[3])));
                    jobs.Add(currentJob);
                    currentJob.JobDone += jobs.OnJobDone;
                    break;
                case "StandardEmployee":
                    StandartEmployee standartEmployee = new StandartEmployee(input[1]);
                    employees.Add(standartEmployee);
                    break;
                case "PartTimeEmployee":
                    PartTimeEmployee parttimeEmployee = new PartTimeEmployee(input[1]);
                    employees.Add(parttimeEmployee);
                    break;
                case "Pass":
                    foreach (Job job in jobs.ToArray())
                    {
                        job.Update();
                    }

                    break;
                case "Status":
                    foreach (Job job in jobs)
                    {
                        Console.WriteLine(job);
                    }
                    break;
            }
            input = Console.ReadLine().Split();
        }
    }
}