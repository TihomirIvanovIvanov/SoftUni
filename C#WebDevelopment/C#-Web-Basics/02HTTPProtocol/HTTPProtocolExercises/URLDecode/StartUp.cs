namespace URLDecode
{
    using System;
    using System.Net;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            Console.WriteLine(WebUtility.UrlDecode(input));
        }
    }
}
