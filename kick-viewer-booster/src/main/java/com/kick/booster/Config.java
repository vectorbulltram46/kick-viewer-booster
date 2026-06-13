package com.kick.booster;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

public class Config {
    private final Properties props = new Properties();

    public Config(String path) {
        try (FileInputStream fis = new FileInputStream(path)) {
            props.load(fis);
        } catch (IOException e) {
            System.out.println("Using default config.");
        }
    }

    public int getThreadCount() {
        return Integer.parseInt(props.getProperty("threads", "5"));
    }

    public String getStreamUrl() {
        return props.getProperty("streamUrl", "https://kick.com/example");
    }
}