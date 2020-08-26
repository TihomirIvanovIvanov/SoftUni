using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CryptoBlockchain
{
    public class StartUp
    {
        public static void Main()
        {
            var input = string.Empty;
            var result = string.Empty;

            var count = int.Parse(Console.ReadLine());

            var pattern = @"\[[^\[\]{}]*?([0-9]{3,})[^\[\]{}]*?\]|{[^{}\]\[]*?([0-9]{3,})[^{}\]\[]*?}";

            for (int i = 0; i < count; i++)
            {
                var line = Console.ReadLine();
                input = string.Concat(input, line);
            }

            var matches = Regex.Matches(input, pattern);

            for (int i = 0; i < matches.Count; i++)
            {
                var groupNumber = matches[i].Groups[1].ToString() == string.Empty ? 2 : 1;

                var numberLength = matches[i].Groups[groupNumber].ToString().Length;
                if (numberLength % 3 == 0)
                {
                    var totalLength = matches[i].Groups[0].ToString().Length;
                    for (int j = 0; j < numberLength / 3; j++)
                    {
                        var temp = matches[i].Groups[groupNumber].ToString().Skip(3 * j).Take(3);

                        var charCode = string.Concat(temp);
                        var currentCode = int.Parse(charCode);

                        currentCode -= totalLength;

                        result = string.Concat(result, (char)currentCode);
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
