namespace SIS.HTTP.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static string Capitalize(this string input)
        {
            return Char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
