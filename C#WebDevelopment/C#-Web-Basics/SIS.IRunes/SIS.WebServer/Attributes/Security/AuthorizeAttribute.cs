namespace SIS.MvcFramework.Attributes.Security
{
    using HTTP.Common;
    using Identity;
    using System;

    public class AuthorizeAttribute : Attribute
    {
        private readonly string authority;

        public AuthorizeAttribute(string authority = GlobalConstants.authorized)
        {
            this.authority = authority;
        }

        private bool IsLoggedIn(Principal principal)
        {
            return principal != null;
        }

        public bool IsInAuthority(Principal principal)
        {
            if (!this.IsLoggedIn(principal))
            {
                return this.authority == GlobalConstants.anonymous;
            }

            return this.authority == GlobalConstants.authorized || principal.Roles.Contains(this.authority.ToLower());
        }
    }
}
