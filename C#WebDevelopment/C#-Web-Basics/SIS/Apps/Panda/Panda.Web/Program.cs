using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
//using Panda.Web.ViewModels;
using Panda.Models;
using SIS.MvcFramework;
using SIS.MvcFramework.Extensions;
using SIS.MvcFramework.Mapping;

namespace Panda.Web
{
    public static class Program
    {
        public static void Main()
        {
            WebHost.Start(new Startup());
        }
    }
}
