import random

class ProxyManager:
    def __init__(self, proxy_file: str = None):
        self.proxies = []
        if proxy_file:
            self.load_from_file(proxy_file)

    def load_from_file(self, filepath: str):
        with open(filepath, "r") as f:
            self.proxies = [line.strip() for line in f if line.strip()]

    def add_proxy(self, proxy: str):
        self.proxies.append(proxy)

    def get_random_proxy(self) -> str:
        return random.choice(self.proxies) if self.proxies else None

    def get_proxy_count(self) -> int:
        return len(self.proxies)