using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace KickViewerBooster.Core
{
    public class ViewerSession
    {
        private readonly string _id;
        private readonly string _channelName;
        private readonly HttpClient _httpClient;
        private bool _isConnected;

        public ViewerSession(string id, string channelName)
        {
            _id = id;
            _channelName = channelName;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
        }

        public async Task ConnectAsync(CancellationToken token)
        {
            string url = $"https://kick.com/{_channelName}";
            Console.WriteLine($"[{_id}] Connecting to {url}...");

            try
            {
                var response = await _httpClient.GetAsync(url, token);
                _isConnected = response.IsSuccessStatusCode;
                Console.WriteLine($"[{_id}] Status: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{_id}] Error: {ex.Message}");
            }
        }

        public void Disconnect()
        {
            _httpClient.Dispose();
            _isConnected = false;
        }
    }
}