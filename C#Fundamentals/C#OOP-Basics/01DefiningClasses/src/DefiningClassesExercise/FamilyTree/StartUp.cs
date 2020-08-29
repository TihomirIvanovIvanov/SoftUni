using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FamilyTree
{
    public class StartUp
    {
        public static void Main()
        {
            var people = new List<Person>();
            var storePeople = new List<string>();
            var person = Console.ReadLine();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var info = Regex.Split(input, " - ");

                if (info.Length == 1)
                {
                    var lastIndexOfSpace = input.LastIndexOf(" ", StringComparison.Ordinal);

                    var name = input.Substring(0, lastIndexOfSpace);
                    var birthday = input.Substring(lastIndexOfSpace + 1);

                    var newPerson = new Person(name, birthday);

                    people.Add(newPerson);
                }
                else
                {
                    storePeople.Add(input);
                }
            }

            foreach (var storePerson in storePeople)
            {
                Person parent;
                Person children;

                var info = Regex.Split(storePerson, " - ");

                if (info[0].Contains('/') && info[1].Contains('/'))
                {
                    var parentBirthday = info[0];
                    var childrenBirthday = info[1];

                    parent = people
                        .First(p => p.Birthday == parentBirthday);

                    children = people
                        .First(ch => ch.Birthday == childrenBirthday);
                }
                else if (info[0].Contains('/') || info[1].Contains('/'))
                {
                    var name = string.Empty;
                    var birthday = string.Empty;

                    if (info[0].Contains('/'))
                    {
                        birthday = info[0];
                        name = info[1];

                        parent = people
                            .First(p => p.Birthday == birthday);

                        children = people
                            .First(ch => ch.Name == name);
                    }
                    else
                    {
                        birthday = info[1];
                        name = info[0];

                        children = people
                            .First(ch => ch.Birthday == birthday);

                        parent = people
                            .First(p => p.Name == name);
                    }
                }
                else
                {
                    var parentName = info[0];
                    var childrenName = info[1];

                    parent = people
                        .First(p => p.Name == parentName);

                    children = people
                        .First(ch => ch.Name == childrenName);
                }

                if (!parent.Children.Contains(children))
                {
                    parent.Children.Add(children);
                }

                if (!children.Parents.Contains(parent))
                {
                    children.Parents.Add(parent);
                }
            }

            Person ourPerson;

            if (person.Contains('/'))
            {
                ourPerson = people.First(p => p.Birthday == person);
            }
            else
            {
                ourPerson = people.First(p => p.Name == person);
            }

            var result = new StringBuilder();

            result.AppendLine(ourPerson.ToString());

            result.AppendLine("Parents:");
            foreach (var parent in ourPerson.Parents)
            {
                result.AppendLine(parent.ToString());
            }

            result.AppendLine("Children:");
            foreach (var child in ourPerson.Children)
            {
                result.AppendLine(child.ToString());
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}
