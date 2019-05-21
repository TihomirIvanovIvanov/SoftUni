namespace SIS.HTTP.Exceptions
{
    using System;
    using System.Net;

    public class InternalServerErrorException : Exception
    {
        private const string InternalServerErrorExceptionDefaultMessage = "The Server has encountered an error.";

        public InternalServerErrorException()
            : base(InternalServerErrorExceptionDefaultMessage)
        { 
        }

        public HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;
    }
}
