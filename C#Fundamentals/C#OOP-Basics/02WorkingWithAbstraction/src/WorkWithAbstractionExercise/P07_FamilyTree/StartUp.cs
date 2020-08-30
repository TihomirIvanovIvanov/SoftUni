using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07_FamilyTree
{
    public class StartUp
    {
        public static void Main()
        {
            var people = new List<Person>();
            string searchPersonParam = Console.ReadLine();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End") break;

                if (input.Contains('-'))
                {
                    var tokens = input
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();

                    var parentToken = tokens[0];
                    var childToken = tokens[1];

                    var parent = CreatePerson(parentToken);
                    var child = CreatePerson(childToken);

                    AddParentIfMissing(people, parent);

                    if (parent.Name != null)
                    {
                        people
                            .FirstOrDefault(p => p.Name == parent.Name)
                            .AddChild(child);
                    }
                    else
                    {
                        people
                            .FirstOrDefault(p => p.Birthday == parent.Birthday)
                            .AddChild(child);
                    }
                }
                else
                {
                    var tokents = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var name = $"{tokents[0]} {tokents[1]}";
                    var birthday = tokents[2];
                    var isExistingPerson = false;

                    for (int i = 0; i < people.Count; i++)
                    {
                        if (people[i].Name == name)
                        {
                            people[i].Birthday = birthday;
                            isExistingPerson = true;
                        }

                        if (people[i].Birthday == birthday)
                        {
                            people[i].Name = name;
                            isExistingPerson = true;
                        }

                        people[i].AddChildrenInfo(name, birthday);
                    }

                    if (!isExistingPerson)
                    {
                        people.Add(new Person(name, birthday));
                    }
                }
            }

            PrintParentsAndChildren(people, searchPersonParam);
        }

        private static void PrintParentsAndChildren(List<Person> people, string personParam)
        {
            var person = people
                .FirstOrDefault(p => p.Birthday == personParam || p.Name == personParam);

            var sb = new StringBuilder();

            sb.AppendLine($"{person.Name} {person.Birthday}");
            sb.AppendLine("Parents:");
            people
                .Where(p => p.FindChild(person.Name) != null)
                .ToList()
                .ForEach(p => sb.AppendLine($"{p.Name} {p.Birthday}"));

            sb.AppendLine("Children");
            person
                .Children
                .ToList()
                .ForEach(ch => sb.AppendLine($"{ch.Name} {ch.Birthday}"));

            Console.WriteLine(sb.ToString());
        }

        private static void AddParentIfMissing(List<Person> people, Person parent)
        {
            if ((parent.Name != null && people.Any(p => p.Name == parent.Name)) ||
                (parent.Birthday != null && people.Any(p => p.Birthday == parent.Birthday)))
            {
                return;
            }

            people.Add(parent);
        }

        private static Person CreatePerson(string personParam)
        {
            var person = new Person();

            if (IsDate(personParam))
            {
                person.Birthday = personParam;
            }
            else
            {
                person.Name = personParam;
            }

            return person;
        }

        private static bool IsDate(string personParam)
        {
            return personParam.Contains('/');
        }
    }
}
