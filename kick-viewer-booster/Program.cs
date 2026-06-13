using System;
using System.Threading.Tasks;
using KickViewerBooster.Core;

namespace KickViewerBooster
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Kick Viewer Booster v1.0");
            Console.WriteLine("------------------------");

            string channelName = args.Length > 0 ? args[0] : "example_channel";
            int viewerCount = args.Length > 1 ? int.Parse(args[1]) : 10;

            var booster = new ViewerBooster(channelName, viewerCount);
            await booster.StartAsync();

            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
            booster.Stop();
        }
    }
}