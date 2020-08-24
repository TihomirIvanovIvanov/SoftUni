using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicketTrouble
{
    public class StartUp
    {
        private static string targetCountry;

        private static string targetCity;

        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            targetCountry = input[0];
            targetCity = input[1];

            var pattern = new Regex(@"((?<bracket>{)|\[)[^{[]*?(?(bracket)\[|{)(?<country>[A-Z]{3}) (?<city>[A-Z]{2})(?(bracket)\]|})[^[{]*?(?(bracket)\[|{)(?<letter>[A-Z])(?<number>[0-9]{2}|[0-9]{1})(?(bracket)\]|})[^]}]*?(?(bracket)}|\])");

            var allTickets = Console.ReadLine();

            var matches = pattern.Matches(allTickets);
            var validTickets = new List<string>();

            foreach (Match match in matches)
            {
                var country = match.Groups["country"].Value;
                var city = match.Groups["city"].Value;
                var letter = match.Groups["letter"].Value;
                var number = match.Groups["number"].Value;

                if (country == targetCountry && city == targetCity)
                {
                    if (validTickets.Contains(number))
                    {
                        var index = validTickets.IndexOf(number);
                        Print(validTickets[index - 1] + validTickets[index], letter + number);
                        Environment.Exit(0);
                    }
                    else
                    {
                        validTickets.Add(letter);
                        validTickets.Add(number);
                    }
                }
            }
            Print(validTickets[0] + validTickets[1], validTickets[2] + validTickets[3]);
        }

        private static void Print(string firstSeat, string secondSeat)
        {
            Console.WriteLine($"You are traveling to {targetCountry} {targetCity} on seats {firstSeat} and {secondSeat}.");
        }
    }
}
