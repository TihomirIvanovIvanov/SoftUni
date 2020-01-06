namespace SIS.MvcFramework.Attributes.Validation
{
    public class RequiredSisAttribute : ValidationSisAttribute
    {
        public RequiredSisAttribute()
        { 
        }

        public RequiredSisAttribute(string errorMessage = "Error Message")
            : base(errorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            return value != null;
        }
    }
}
