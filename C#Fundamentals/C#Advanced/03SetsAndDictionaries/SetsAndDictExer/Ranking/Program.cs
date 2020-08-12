using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var students = new Dictionary<string, Dictionary<string, int>>();

            string input;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                var elements = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                var contestName = elements[0];
                var contestPassword = elements[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, contestPassword);
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var elements = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                var contestName = elements[0];
                var contestPassword = elements[1];
                var username = elements[2];
                var currentPoints = int.Parse(elements[3]);

                if (contests.ContainsKey(contestName) && contests[contestName] == contestPassword)
                {
                    if (!students.ContainsKey(username))
                    {
                        students.Add(username, new Dictionary<string, int>());
                    }

                    if (!students[username].ContainsKey(contestName))
                    {
                        students[username].Add(contestName, currentPoints);
                    }

                    if (students[username][contestName] < currentPoints)
                    {
                        students[username][contestName] = currentPoints;
                    }
                }
            }

            var topStudent = students
                .OrderByDescending(s => s.Value.Sum(sum => sum.Value))
                .FirstOrDefault();

            var bestPoints = topStudent
                .Value
                .Sum(s => s.Value);

            Console.WriteLine($"Best candidate is {topStudent.Key} with total {bestPoints} points.");

            Console.WriteLine("Ranking:");

            var sortedStudents = students.OrderBy(s => s.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var kvp in sortedStudents)
            {
                Console.WriteLine(kvp.Key);

                foreach (var contest in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
