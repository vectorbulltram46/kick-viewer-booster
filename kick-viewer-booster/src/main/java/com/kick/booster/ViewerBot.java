package com.kick.booster;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class ViewerBot {
    private final int threadCount;
    private final String streamUrl;
    private final ExecutorService executor;

    public ViewerBot(int threadCount, String streamUrl) {
        this.threadCount = threadCount;
        this.streamUrl = streamUrl;
        this.executor = Executors.newFixedThreadPool(threadCount);
    }

    public void start() {
        for (int i = 0; i < threadCount; i++) {
            executor.submit(new BrowserTask(streamUrl, "Viewer-" + (i + 1)));
        }
    }

    public void stop() {
        executor.shutdownNow();
        try {
            executor.awaitTermination(5, TimeUnit.SECONDS);
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
        }
    }

    public int getActiveCount() {
        return ((java.util.concurrent.ThreadPoolExecutor) executor).getActiveCount();
    }
}