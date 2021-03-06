﻿using SIS.MvcFramework;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace SulsApp
{
    public static class Program
    {
        public static async Task Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            await WebHost.StartAsync(new Startup());
        }
    }
}
