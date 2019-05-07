namespace SoftUniDIFramework.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field, AllowMultiple = true)]
    public class Inject : Attribute
    {
    }
}
