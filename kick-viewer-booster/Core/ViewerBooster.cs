using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KickViewerBooster.Core
{
    public class ViewerBooster
    {
        private readonly string _channelName;
        private readonly int _targetViewers;
        private readonly List<ViewerSession> _sessions;
        private CancellationTokenSource? _cts;

        public ViewerBooster(string channelName, int targetViewers)
        {
            _channelName = channelName;
            _targetViewers = targetViewers;
            _sessions = new List<ViewerSession>();
        }

        public async Task StartAsync()
        {
            _cts = new CancellationTokenSource();
            Console.WriteLine($"Starting booster for channel '{_channelName}' with {_targetViewers} viewers...");

            for (int i = 0; i < _targetViewers; i++)
            {
                var session = new ViewerSession($"Viewer_{i + 1}", _channelName);
                _sessions.Add(session);
                _ = session.ConnectAsync(_cts.Token);
                await Task.Delay(100); // Stagger connections
            }

            Console.WriteLine("All viewers connecting...");
        }

        public void Stop()
        {
            _cts?.Cancel();
            Console.WriteLine("Stopped all viewer sessions.");
        }
    }
}