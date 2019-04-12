namespace SIS.Http.Exceptions
{
    using System;
    using System.Net;

    public class BadRequestException : Exception
    {
        private const string errorMessage = "The Request was malformed or contains unsupported elements.";

        public BadRequestException()
            : base(errorMessage)
        {
        }

        public HttpStatusCode StatusCode = HttpStatusCode.BadRequest;
    }
}
