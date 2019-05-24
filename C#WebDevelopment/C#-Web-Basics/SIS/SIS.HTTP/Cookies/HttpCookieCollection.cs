﻿namespace SIS.HTTP.Cookies
{
    using Common;
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly Dictionary<string, HttpCookie> httpCookies;

        public HttpCookieCollection()
        {
            this.httpCookies = new Dictionary<string, HttpCookie>();
        }

        public void AddCookie(HttpCookie httpCookie)
        {
            CoreValidator.ThrowIfNull(httpCookie, nameof(httpCookie));

            this.httpCookies.Add(httpCookie.Key, httpCookie);
        }

        public bool ContainsCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.httpCookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.httpCookies[key];
        }

        public bool HasCookies()
        {
            return this.httpCookies.Count != 0;
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            return this.httpCookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var cookie in this.httpCookies.Values)
            {
                sb.Append($"Set-Cookie: {cookie}").Append(GlobalConstants.HttpNewLine);
            }

            return sb.ToString();
        }
    }
}
