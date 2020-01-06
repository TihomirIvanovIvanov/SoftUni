using System;

namespace SIS.MvcFramework.Attributes.Validation
{
    public class StringLengthSisAttribute : ValidationSisAttribute
    {
        private readonly int minLength;

        private readonly int maxLength;

        public StringLengthSisAttribute(int minLength, int maxLength, string errorMessage = "Error Message")
            : base(errorMessage)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        public override bool IsValid(object value)
        {
            var valueAsString = (string)Convert.ChangeType(value, typeof(string));

            if (valueAsString.Length >= this.minLength && valueAsString.Length <= this.maxLength)
            {
                return true;
            }
            return false;
        }
    }
}
