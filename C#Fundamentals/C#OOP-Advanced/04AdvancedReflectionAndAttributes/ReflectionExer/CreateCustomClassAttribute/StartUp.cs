namespace CreateCustomClassAttribute
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var classType = typeof(Weapon);
            var attribute = classType.GetCustomAttributes(false);

            foreach (var attr in attribute)
            {
                var classAttr = attr as ClassAttribute;

                if (classAttr != null)
                {
                    string command;
                    while ((command = Console.ReadLine()) != "END")
                    {
                        switch (command)
                        {
                            case "Author":
                                Console.WriteLine($"Author: {classAttr.Author}");
                                break;
                            case "Revision":
                                Console.WriteLine($"Revision: {classAttr.Revision}");
                                break;
                            case "Description":
                                Console.WriteLine($"Class description: {classAttr.Description}");
                                break;
                            case "Reviewers":
                                Console.WriteLine($"Reviewers: {string.Join(", ", classAttr.Reviewers)}");
                                break;
                        }
                    }
                }
            }
        }
    }
}
