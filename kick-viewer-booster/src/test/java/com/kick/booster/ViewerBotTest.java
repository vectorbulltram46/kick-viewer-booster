package com.kick.booster;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class ViewerBotTest {
    @Test
    public void testBotInitialization() {
        ViewerBot bot = new ViewerBot(3, "https://kick.com/test");
        assertNotNull(bot);
        assertEquals(0, bot.getActiveCount());
    }

    @Test
    public void testStartAndStop() throws InterruptedException {
        ViewerBot bot = new ViewerBot(2, "https://kick.com/test");
        bot.start();
        Thread.sleep(1000);
        assertTrue(bot.getActiveCount() > 0);
        bot.stop();
        assertEquals(0, bot.getActiveCount());
    }
}