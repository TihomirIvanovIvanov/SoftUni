﻿namespace SIS.HTTP.Requests
{
    using Common;
    using Contracts;
    using Cookies;
    using Cookies.Contracts;
    using Enums;
    using Exceptions;
    using Headers;
    using Headers.Contracts;
    using Sessions.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpSession Session { get; set; }

        private bool IsValidRequestLine(string[] requestLineParams)
        {
            if (requestLineParams.Length != 3 || requestLineParams[2] != GlobalConstants.HttpOneProtocolFragment)
            {
                return false;
            }

            return true;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            CoreValidator.ThrowIfNullOrEmpty(queryString, nameof(queryString));

            return true; //TODO: REGEX QUERY STRING
        }

        private bool HasQueryString()
        {
            return this.Url.Split('?').Length > 1;
        }

        private IEnumerable<string> ParsePlainRequestHeaders(string[] requestLines)
        {
            for (int i = 1; i < requestLines.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(requestLines[i]))
                {
                    yield return requestLines[i];
                }
            }
        }

        private void ParseRequestMethod(string[] requestLineParams)
        {
            var parseResult = HttpRequestMethod.TryParse(requestLineParams[0], true, out HttpRequestMethod method);

            if (!parseResult)
            {
                throw new BadRequestException(
                    string.Format(GlobalConstants.UnsuppertedHttpMethodExceptionMessage,
                    requestLineParams[0]));
            }

            this.RequestMethod = method;
        }

        private void ParseRequestUrl(string[] requestLineParams)
        {
            this.Url = requestLineParams[1];
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url.Split('?')[0];
        }

        private void ParseRequestHeaders(string[] plainHeaders)
        {
            plainHeaders.Select(plainHeader => plainHeader.Split(new[] { ": " },
                StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(headerKeyValuePair => this.Headers.AddHeader(new HttpHeader(headerKeyValuePair[0], headerKeyValuePair[1])));
        }

        private void ParseRequestQueryParameters()
        {
            if (this.HasQueryString())
            {
                this.Url.Split('?', '#')[1]
                    .Split('&')
                    .Select(plainQueryParameter => plainQueryParameter.Split('='))
                    .ToList()
                    .ForEach(queryParameterKeyValuePair =>
                        this.QueryData.Add(queryParameterKeyValuePair[0], queryParameterKeyValuePair[1]));
            }
        }

        private void ParseRequestFormDataParameters(string requestBody)
        {
            if (string.IsNullOrEmpty(requestBody) == false)
            {
                //TODO: Parse multiple parameters by name
                var paramPairs = requestBody
                    .Split('&')
                    .Select(plainQueryParameter => plainQueryParameter.Split('='))
                    .ToList();

                foreach (var paramPair in paramPairs)
                {
                    var key = paramPair[0];
                    var value = paramPair[1];

                    if (this.FormData.ContainsKey(key) == false)
                    {
                        this.FormData.Add(key, new HashSet<string>());
                    }

                    ((ISet<string>)this.FormData[key]).Add(value);
                }
            }
        }

        private void ParseRequestParameters(string requestBody)
        {
            this.ParseRequestQueryParameters();
            this.ParseRequestFormDataParameters(requestBody); // TODO: Split
        }

        private void ParseCookies()
        {
            if (this.Headers.ContainsHeader(HttpHeader.Cookie))
            {
                var value = this.Headers.GetHeader(HttpHeader.Cookie).Value;
                var unparsedCookies = value.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var unparsedCookie in unparsedCookies)
                {
                    var cookieKeyValuePair = unparsedCookie.Split(new[] { '=' }, 2);

                    var httpCookie = new HttpCookie(cookieKeyValuePair[0], cookieKeyValuePair[1], false);

                    this.Cookies.AddCookie(httpCookie);
                }
            }
        }

        private void ParseRequest(string requestString)
        {
            var splitRequestString = requestString
                .Split(new[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);

            var requestLineParams = splitRequestString[0].Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLineParams))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLineParams);
            this.ParseRequestUrl(requestLineParams);
            this.ParseRequestPath();

            this.ParseRequestHeaders(this.ParsePlainRequestHeaders(splitRequestString).ToArray());
            this.ParseCookies();

            this.ParseRequestParameters(splitRequestString[splitRequestString.Length - 1]);
        }
    }
}
