package com.kick.booster;

public class Main {
    public static void main(String[] args) {
        Config config = new Config("config.properties");
        ViewerBot bot = new ViewerBot(config.getThreadCount(), config.getStreamUrl());
        bot.start();
        System.out.println("Viewer booster running. Active viewers: " + bot.getActiveCount());
        Runtime.getRuntime().addShutdownHook(new Thread(bot::stop));
    }
}