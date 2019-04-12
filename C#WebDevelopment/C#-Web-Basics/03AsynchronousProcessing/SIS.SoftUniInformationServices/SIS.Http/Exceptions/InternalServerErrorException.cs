namespace SIS.Http.Exceptions
{
    using System;
    using System.Net;

    public class InternalServerErrorException : Exception
    {
        private const string errorMessage = "The Server has encountered an error.";

        public InternalServerErrorException()
            : base(errorMessage)
        {
        }

        public HttpStatusCode StatusCode = HttpStatusCode.BadRequest;
    }
}
