namespace SIS.Http.Responses.Contacts
{
    using Headers.Contracts;
    using Headers;
    using System.Net;

    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }

        IHttpHeaderCollection Headers { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();
    }
}
