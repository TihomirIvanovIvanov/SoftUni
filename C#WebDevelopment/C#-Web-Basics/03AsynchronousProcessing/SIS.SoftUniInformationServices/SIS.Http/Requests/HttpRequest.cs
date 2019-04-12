namespace SIS.Http.Requests
{
    using Common;
    using Contacts;
    using Enum;
    using Exceptions;
    using Headers;
    using Headers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private void ParseRequest(string requestString)
        {
            var splitRequestContent = requestString
                .Split(Environment.NewLine, StringSplitOptions.None);

            var requestLine = splitRequestContent[0]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidateRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            var requestHasBody = splitRequestContent.Length > 1;
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1], requestHasBody);
        }

        private void ParseRequestParameters(string bodyParameters, bool requestHasBody)
        {
            this.ParseQueryParameters(this.Url);
            if (requestHasBody)
            {
                this.ParseFormDataParameters(bodyParameters);
            }
        }

        private void ParseFormDataParameters(string bodyParameters)
        {
            var formDataKeyValuePairs = bodyParameters
                .Split('&', StringSplitOptions.RemoveEmptyEntries);
            ExtractRequestParameters(formDataKeyValuePairs, this.FormData);
        }

        private void ExtractRequestParameters(string[] parameterKeyValuePairs, Dictionary<string, object> parametersCollection)
        {
            foreach (var parameterKeyValuePair in parameterKeyValuePairs)
            {
                var keyValuePair = parameterKeyValuePair.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (keyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }

                var parameterKey = keyValuePair[0];
                var parameterValue = keyValuePair[1];

                // parameterKey -> {parameterKey, parameterValue} ?
                // should we overwrite?
                parametersCollection[parameterKey] = parameterValue;
            }
        }

        private void ParseQueryParameters(string url)
        {
            var queryParameters = this.Url?
                .Split(new char[] { '?', '#' })
                .Skip(1)
                .ToArray()[0];

            if (string.IsNullOrEmpty(queryParameters))
            {
                throw new BadRequestException();
            }

            var queryKeyValuePairs = queryParameters
                .Split('&', StringSplitOptions.RemoveEmptyEntries);

            ExtractRequestParameters(queryKeyValuePairs, this.QueryData);
        }

        private void ParseHeaders(string[] requestHeaders)
        {
            if (!requestHeaders.Any())
            {
                throw new BadRequestException();
            }

            foreach (var requestHeader in requestHeaders)
            {
                if (string.IsNullOrEmpty(requestHeader))
                {
                    return;
                }

                var splitRequestHeader = requestHeader.Split(": ", StringSplitOptions.RemoveEmptyEntries);

                var requestHeaderKey = splitRequestHeader[0];
                var requestHeaderValue = splitRequestHeader[1];

                this.Headers.Add(new HttpHeader(requestHeaderKey, requestHeaderValue));
            }
        }

        private void ParseRequestPath()
        {
            var path = this.Url?.Split('?').FirstOrDefault();

            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }

            this.Path = path;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (string.IsNullOrEmpty(requestLine[1]))
            {
                throw new BadRequestException();
            }

            this.Url = requestLine[1];

        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var parseResult = Enum.TryParse<HttpRequestMethod>(requestLine[0], out var parsedRequestMethod);

            if (!parseResult)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = parsedRequestMethod;
        }

        private bool IsValidateRequestLine(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            if (requestLine.Length == 3 && requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }

            return false;
        }
    }
}