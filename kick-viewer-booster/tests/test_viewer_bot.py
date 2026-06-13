import unittest
from unittest.mock import patch, MagicMock
from src.viewer_bot import ViewerBot

class TestViewerBot(unittest.TestCase):
    @patch("src.viewer_bot.webdriver.Chrome")
    def test_setup_driver(self, mock_chrome):
        bot = ViewerBot("https://kick.com/test")
        bot._setup_driver()
        mock_chrome.assert_called_once()
        self.assertIsNotNone(bot.driver)

    @patch("src.viewer_bot.webdriver.Chrome")
    def test_watch_stream(self, mock_chrome):
        mock_driver = MagicMock()
        mock_chrome.return_value = mock_driver
        bot = ViewerBot("https://kick.com/test")
        bot.watch_stream(duration=1)
        mock_driver.get.assert_called_with("https://kick.com/test")
        mock_driver.quit.assert_called_once()

    def test_run_multiple(self):
        bot = ViewerBot("https://kick.com/test")
        with patch.object(bot, "watch_stream") as mock_watch:
            bot.run_multiple(count=3, duration=1)
            self.assertEqual(mock_watch.call_count, 3)

if __name__ == "__main__":
    unittest.main()