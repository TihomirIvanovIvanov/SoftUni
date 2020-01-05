using System;

namespace SIS.MvcFramework.Attributes.Validation
{
    public class PasswordSisAttribute : ValidationSisAttribute
    {
        public PasswordSisAttribute(string errorMessage = "Error Message")
            : base(errorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            var valueAsString = (string)Convert.ChangeType(value, typeof(string));

            if (valueAsString.Length < 3)
            {
                return false;
            }
            return true;
        }
    }
}
