﻿namespace SIS.HTTP.Headers
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        public readonly IDictionary<string, HttpHeader> httpHeaders;

        public HttpHeaderCollection()
        {
            this.httpHeaders = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));
            this.httpHeaders.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return this.ContainsHeader(key);
        }

        public HttpHeader GetHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return this.httpHeaders[key];
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.httpHeaders.Values.Select(header => header.ToString()));
        }
    }
}
