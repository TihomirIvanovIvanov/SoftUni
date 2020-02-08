using SIS.MvcFramework;
using System.Globalization;
using System.Threading;

namespace SULS.App
{
    public static class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            WebHost.Start(new StartUp());
        }
    }
}