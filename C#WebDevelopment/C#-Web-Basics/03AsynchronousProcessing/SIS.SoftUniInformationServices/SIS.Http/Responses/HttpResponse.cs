namespace SIS.Http.Responses
{
    using Common;
    using Extentions;
    using Headers;
    using Headers.Contracts;
    using Responses.Contacts;
    using System.Linq;
    using System.Net;
    using System.Text;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse() { }

        public HttpResponse(HttpStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.StatusCode = statusCode;
            this.Content = new byte[0];
        }

        public HttpStatusCode StatusCode { get; }

        public IHttpHeaderCollection Headers { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .AppendLine($"{this.Headers}")
                .AppendLine();

            return result.ToString();
        }
    }
}
