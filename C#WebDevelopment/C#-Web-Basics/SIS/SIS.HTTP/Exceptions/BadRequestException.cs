namespace SIS.HTTP.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        private const string errorMessage = "The Request was malformed or contains unsupported elements.";

        public BadRequestException()
            : this(errorMessage)
        {
        }

        public BadRequestException(string name)
            : base(name)
        {
        }
    }
}
