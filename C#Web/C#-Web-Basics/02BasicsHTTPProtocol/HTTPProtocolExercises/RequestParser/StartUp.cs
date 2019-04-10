namespace RequestParser
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var validUrlMethods = ReadValidUrls();
            ProccessHttpRequest(validUrlMethods);
        }

        private static void ProccessHttpRequest(Dictionary<string, HashSet<string>> validUrlMethods)
        {
            var request = Console.ReadLine();
            var requestTokens = request.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var requestMethod = requestTokens[0].ToLower();
            var reqeustUrl = requestTokens[1];
            var requstProtocol = requestTokens[2];

            var statusCode = validUrlMethods.ContainsKey(reqeustUrl) &&
                             validUrlMethods[reqeustUrl].Contains(requestMethod) ?
                             HttpStatusCode.OK :
                             HttpStatusCode.NotFound;

            var sb = new StringBuilder();
            sb.AppendLine($"{requstProtocol} {(int)statusCode} {statusCode}")
                .AppendLine($"Content-Length: {statusCode.ToString().Length}")
                .AppendLine($"Content-Type: text/plain" + Environment.NewLine)
                .AppendLine($"{statusCode}");

            Console.WriteLine(sb.ToString().Trim());
        }

        private static Dictionary<string, HashSet<string>> ReadValidUrls()
        {
            var validUrls = new Dictionary<string, HashSet<string>>(); // URL, http method

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputTokens = input.Split('/', StringSplitOptions.RemoveEmptyEntries);
                var path = inputTokens[0];
                var method = inputTokens[1].ToLower();
                var fullPath = '/' + path;

                if (!validUrls.ContainsKey(fullPath))
                {
                    validUrls[fullPath] = new HashSet<string>();
                }

                validUrls[fullPath].Add(method);
            }

            return validUrls;
        }
    }
}