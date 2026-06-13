package com.kick.booster;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;

public class BrowserTask implements Runnable {
    private final String streamUrl;
    private final String viewerName;

    public BrowserTask(String streamUrl, String viewerName) {
        this.streamUrl = streamUrl;
        this.viewerName = viewerName;
    }

    @Override
    public void run() {
        ChromeOptions options = new ChromeOptions();
        options.addArguments("--headless", "--no-sandbox", "--disable-dev-shm-usage");
        WebDriver driver = new ChromeDriver(options);
        try {
            driver.get(streamUrl);
            System.out.println(viewerName + " connected to: " + streamUrl);
            Thread.sleep(60000); // watch for 60 seconds
        } catch (InterruptedException e) {
            System.out.println(viewerName + " disconnected.");
        } finally {
            driver.quit();
        }
    }
}