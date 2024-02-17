namespace IdnesSeleniumTests.Setup
{
    public class WorkWithElements
    {
        private IWebDriver webDriver = new WebDriverSetup("Chrome").GetBrowser();        

        [SetUp]
        public void SetupTest()
        {
            webDriver.Manage().Window.Maximize();            
        }       
        
        public void WaitForClickableElement_ByCss(string CssSelector)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelector)));
        }

        public void WaitForClickableElement_ById(string IdSelector)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(IdSelector)));
        }

        public void WaitForElement_ByLinkText(string LinkTextSelector)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.LinkText(LinkTextSelector)));
        }

        public void GotoPage(string webUrl)
        {
            webDriver.Navigate().GoToUrl(webUrl);
        }

        public void ClickOnElement_ById(string IdSelector)
        {
            WaitForClickableElement_ById(IdSelector);
            webDriver.FindElement(By.Id(IdSelector)).Click();
        }

        public void ClickOnElement_ByCss(string CssSelector)
        {
            WaitForClickableElement_ByCss(CssSelector);
            webDriver.FindElement(By.CssSelector(CssSelector)).Click();
        }

        public void InputTextToElement_ByCss(string CssSelector, string inputText)
        {
            WaitForClickableElement_ByCss(CssSelector);
            webDriver.FindElement(By.CssSelector(CssSelector)).SendKeys(inputText);
        }

        public void InputTextToElement_ByLinkText(string LinkTextSelector, string inputText)
        {
            WaitForElement_ByLinkText(LinkTextSelector);
            webDriver.FindElement(By.LinkText(LinkTextSelector)).SendKeys(inputText);
        }

        public void MoveMouseToElement_ByCss(string CssSelector)
        {
            WaitForClickableElement_ByCss(CssSelector);
            IWebElement WebElement = webDriver.FindElement(By.CssSelector(CssSelector));
            Actions MouseAction = new Actions(webDriver);
            MouseAction.MoveToElement(WebElement).Perform();
        }

        public void CheckVisibleElement_ByCss(string CssSelector)
        {
            try
            {
                WaitForClickableElement_ByCss(CssSelector);
                IWebElement webElement = webDriver.FindElement(By.CssSelector(CssSelector));
                if (!webElement.Displayed)
                {
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Element is not visible");
                }
            }
            catch (NoSuchElementException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Element not visible");
            }
        }

        public void CheckVisibleElement_ByLinkText(string LinkTextSelector)
        {
            try
            {
                WaitForElement_ByLinkText(LinkTextSelector);
                IWebElement webElement = webDriver.FindElement(By.LinkText(LinkTextSelector));
                if (!webElement.Displayed)
                    {
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Element is not visible");
                    }
            }
            catch (NoSuchElementException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Element not present");
            }
        }       

        public void ClickOnElementIfPresent_ByCss(string CssSelector)
        {
            try
            {
                WaitForClickableElement_ByCss(CssSelector);
                webDriver.FindElement(By.CssSelector(CssSelector)).Click();                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Element not present" + ex.Message);
            }
        }        

        [TestCleanup]
        public void CleanAfterTest()
        {
            try
            {
                webDriver.Quit();
                webDriver.Close();
            }
            catch
            {
                Process[] processes = Process.GetProcessesByName("chromedriver");
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
            
        }

    }
}
