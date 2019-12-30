﻿using SIS.MvcFramework.Identity;

namespace SIS.MvcFramework.ViewEngine
{
    public class ErrorView : IView
    {
        private readonly string errors;

        public ErrorView(string errors)
        {
            this.errors = errors;
        }

        public string GetHtml(object model, Principal user)
        {
            return this.errors;
        }
    }
}
