using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class Program
    {
        static string following = "following";

        static string followers = "followers";

        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                var elems = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var user = elems[0];
                var command = elems[1];
                var targetUser = elems[2];

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(user))
                    {
                        vloggers.Add(user, new Dictionary<string, SortedSet<string>>());
                        vloggers[user].Add(following, new SortedSet<string>());
                        vloggers[user].Add(followers, new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    var isSamePerson = user == targetUser;

                    if (vloggers.ContainsKey(user) && vloggers.ContainsKey(targetUser) && !isSamePerson)
                    {
                        vloggers[user][following].Add(targetUser);
                        vloggers[targetUser][followers].Add(user);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedVloggers = vloggers
                .OrderByDescending(v => v.Value[followers].Count)
                .ThenBy(v => v.Value[following].Count);

            var counter = 1;

            foreach (var vlogger in sortedVloggers)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value[followers].Count} followers, {vlogger.Value[following].Count} following");

                if (counter == 1)
                {
                    foreach (var followerName in vlogger.Value[followers])
                    {
                        Console.WriteLine($"*  {followerName}");
                    }
                }

                counter++;
            }
        }
    }
}
