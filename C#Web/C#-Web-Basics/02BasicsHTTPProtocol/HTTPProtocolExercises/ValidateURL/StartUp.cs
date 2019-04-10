namespace ValidateURL
{
    using System;
    using System.Net;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var urlInput = Console.ReadLine();
            var decodeUrl = WebUtility.UrlDecode(urlInput);

            try
            {
                var parseUrl = new Uri(decodeUrl);

                // Request URL components
                if (string.IsNullOrWhiteSpace(parseUrl.Scheme) ||
                    string.IsNullOrWhiteSpace(parseUrl.Host) ||
                    string.IsNullOrWhiteSpace(parseUrl.LocalPath) ||
                    !parseUrl.IsDefaultPort)
                {
                    throw new ArgumentException("Invalid URL");
                }

                var sb = new StringBuilder();
                sb.AppendLine($"Protocol: {parseUrl.Scheme}")
                    .AppendLine($"Host: {parseUrl.Host}")
                    .AppendLine($"Port: {parseUrl.Port}")
                    .AppendLine($"Path: {parseUrl.LocalPath}");

                // Optional URL components
                if (!string.IsNullOrWhiteSpace(parseUrl.Query))
                {
                    sb.AppendLine($"Query: {parseUrl.Query.Substring(1)}");
                }

                if (!string.IsNullOrWhiteSpace(parseUrl.Fragment))
                {
                    sb.AppendLine($"Fragment: {parseUrl.Fragment.Substring(1)}");
                }

                Console.WriteLine(sb.ToString().Trim());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
