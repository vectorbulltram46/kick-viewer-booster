import sys
import argparse
from src import ViewerBot, ProxyManager, UserAgentRotator

def main():
    parser = argparse.ArgumentParser(description="Kick Viewer Booster - Increase stream views")
    parser.add_argument("url", help="Kick stream URL (e.g., https://kick.com/streamer)")
    parser.add_argument("--views", type=int, default=1, help="Number of view sessions (default: 1)")
    parser.add_argument("--duration", type=int, default=30, help="Watch duration in seconds (default: 30)")
    parser.add_argument("--proxy-file", help="File with proxies (one per line)")
    args = parser.parse_args()

    proxy_manager = ProxyManager(args.proxy_file)
    ua_rotator = UserAgentRotator()

    print(f"Starting {args.views} view(s) for {args.url}")
    print(f"Duration per view: {args.duration}s")
    print(f"Proxies available: {proxy_manager.get_proxy_count()}")

    for i in range(args.views):
        proxy = proxy_manager.get_random_proxy()
        bot = ViewerBot(args.url, proxy=proxy)
        print(f"View {i+1}/{args.views} - {'with proxy' if proxy else 'no proxy'}")
        bot.watch_stream(args.duration)
        print(f"View {i+1} completed")

    print("All views finished.")

if __name__ == "__main__":
    main()