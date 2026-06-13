import time
import random
from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.common.by import By
from fake_useragent import UserAgent

class ViewerBot:
    def __init__(self, stream_url: str, proxy: str = None):
        self.stream_url = stream_url
        self.proxy = proxy
        self.driver = None

    def _setup_driver(self):
        options = Options()
        options.add_argument("--headless")
        options.add_argument("--no-sandbox")
        options.add_argument("--disable-dev-shm-usage")
        ua = UserAgent()
        options.add_argument(f"user-agent={ua.random}")
        if self.proxy:
            options.add_argument(f"--proxy-server={self.proxy}")
        self.driver = webdriver.Chrome(options=options)

    def watch_stream(self, duration: int = 60):
        self._setup_driver()
        try:
            self.driver.get(self.stream_url)
            time.sleep(random.randint(5, 10))
            play_button = self.driver.find_element(By.TAG_NAME, "video")
            play_button.click()
            time.sleep(duration)
        finally:
            self.driver.quit()

    def run_multiple(self, count: int = 5, duration: int = 30):
        for _ in range(count):
            self.watch_stream(duration)
            time.sleep(random.uniform(1, 3))