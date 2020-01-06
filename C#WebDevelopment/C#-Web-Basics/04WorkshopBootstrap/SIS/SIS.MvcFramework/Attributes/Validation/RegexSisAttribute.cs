using System;
using System.Text.RegularExpressions;

namespace SIS.MvcFramework.Attributes.Validation
{
    public class RegexSisAttribute : ValidationSisAttribute
    {
        private readonly string pattern;

        public RegexSisAttribute(string pattern, string errorMessage = "Error Message")
            : base(errorMessage)
        {
            this.pattern = pattern;
        }

        public override bool IsValid(object value)
        {
            var valueAsString = (string)Convert.ChangeType(value, typeof(string));

            return Regex.IsMatch(valueAsString, this.pattern);
        }
    }
}
