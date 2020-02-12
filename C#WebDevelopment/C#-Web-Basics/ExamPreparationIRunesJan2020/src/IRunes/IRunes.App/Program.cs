namespace IRunes.App
{
    using SIS.MvcFramework;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    public static class Program
    {
        public static async Task Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            await WebHost.StartAsync(new Startup());
        }
    }
}
