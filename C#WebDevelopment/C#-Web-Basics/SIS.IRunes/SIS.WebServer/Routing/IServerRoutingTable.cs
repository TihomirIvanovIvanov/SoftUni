namespace SIS.MvcFramework.Routing
{
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using System;

    public interface IServerRoutingTable
    {
        void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponse> func);

        bool Contains(HttpRequestMethod method, string path);

        Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod requestMethod, string path);
    }
}
