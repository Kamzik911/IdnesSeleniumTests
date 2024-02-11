using System.Diagnostics;

namespace IdnesSeleniumTests.Setup
{
    public class MethodsInTests
    {
        IWebDriver webDriver = new WebDriverSetup("Chrome").GetBrowser();        

        [SetUp]
        public void SetupTest()
        {
            webDriver.Manage().Window.Maximize();
        }

        public void GotoPage(string webUrl)
        {
            webDriver.Navigate().GoToUrl(webUrl);
        }

        public void ClickOnElement_ById(string IdSelector)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(IdSelector)));
            webDriver.FindElement(By.Id(IdSelector)).Click();
        }
        public void ClickOnElement_ByCss(string CssSelector)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelector)));
            webDriver.FindElement(By.CssSelector(CssSelector)).Click();
        }

        public void InputTextToElement_ByCss(string CssSelector, string inputText)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelector)));
            webDriver.FindElement(By.CssSelector(CssSelector)).SendKeys(inputText);
        }
        public void InputTextToElement_ByName(string nameSelector, string inputText)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(nameSelector)));
            webDriver.FindElement(By.ClassName(nameSelector)).SendKeys(inputText);
        }

        public bool CheckIfElemetIsPresent_ByCss(string CssSelector)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelector)));
                IWebElement element = webDriver.FindElement(By.CssSelector(CssSelector));
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false; //Element not
            }
        }

        public void AssertIfElementIsVisible_ByCss(string CssSelector)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelector)));
                IWebElement element = webDriver.FindElement(By.CssSelector(CssSelector));
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(element.Displayed);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Element is visible" + ex.Message);
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
