using SIS.MvcFramework;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCards
{
    public static class Program
    {
        public static async Task Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            await WebHost.StartAsync(new Startup());
        }
    }
}
