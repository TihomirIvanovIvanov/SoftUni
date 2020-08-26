using System;
using System.Collections.Generic;
using System.Linq;

namespace Tagram
{
    public class StartUp
    {
        public static void Main()
        {
            var dict = new Dictionary<string, Dictionary<string, long>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var userTokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                if (userTokens[0].Contains("ban"))
                {
                    var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var usernameToBan = tokens[1];
                    if (dict.ContainsKey(usernameToBan))
                    {
                        dict.Remove(usernameToBan);
                        continue;
                    }
                }

                var name = userTokens[0];
                var tag = userTokens[1];
                var likes = long.Parse(userTokens[2]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new Dictionary<string, long>());
                }
                if (!dict[name].ContainsKey(tag))
                {
                    dict[name].Add(tag, likes);
                }
                else
                {
                    dict[name][tag] += likes;
                }
            }

            foreach (var kvp in dict.OrderByDescending(kvp => kvp.Value.Values.Sum())
                                        .ThenBy(kvp => kvp.Value.Keys.Count))
            {
                var user = kvp.Key;
                Console.WriteLine(user);
                foreach (var l in kvp.Value)
                {
                    var tag = l.Key;
                    var likes = l.Value;
                    Console.WriteLine($"- {tag}: {likes}");
                }
            }
        }
    }
}
