﻿
namespace IdnesSeleniumTests.Setup
{
    public class WebDriverSetup
    {
        public IWebDriver webDriver;

        public WebDriverSetup(string browser)
        {
            if (browser == "Chrome")
            {
                webDriver = new ChromeDriver();
            }
            else if (browser == "Edge")
            {
                webDriver = new EdgeDriver();
            }
            else
            {
                webDriver = new ChromeDriver();
            }
        }

        public IWebDriver GetBrowser()
        {
            return webDriver;
        }
    }
}
