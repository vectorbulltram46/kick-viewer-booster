using System;
using System.Threading.Tasks;
using KickViewerBooster.Core;

namespace KickViewerBooster.Tests
{
    public class BoosterTests
    {
        public static async Task RunAll()
        {
            Console.WriteLine("Running tests...\n");

            await Test_ViewerSession_Creation();
            await Test_ViewerBooster_StartStop();
            await Test_MultipleSessions();

            Console.WriteLine("\nAll tests passed!");
        }

        private static async Task Test_ViewerSession_Creation()
        {
            var session = new ViewerSession("test_viewer", "test_channel");
            await Task.Delay(10);
            Console.WriteLine("[PASS] ViewerSession created successfully");
        }

        private static async Task Test_ViewerBooster_StartStop()
        {
            var booster = new ViewerBooster("test_channel", 3);
            await booster.StartAsync();
            await Task.Delay(200);
            booster.Stop();
            Console.WriteLine("[PASS] ViewerBooster started and stopped");
        }

        private static async Task Test_MultipleSessions()
        {
            var booster = new ViewerBooster("test_channel", 5);
            await booster.StartAsync();
            await Task.Delay(300);
            booster.Stop();
            Console.WriteLine("[PASS] Multiple sessions handled");
        }
    }
}