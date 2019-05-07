namespace SoftUniDIFramework.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field, AllowMultiple = true)]
    public class Named : Attribute
    {
        public Named(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
