using IdnesSeleniumTests.Setup;
using OpenQA.Selenium;

namespace IdnesSeleniumTests.Tests
{
    [TestClass]
    public class UserLogin : MethodsInTests
    {
        public string UserEmail = "t44899692@gmail.com";
        public string UserPass = "581210";
        string IdnesLoginPage = "https://idnes.cz";

        [TestMethod ("LoginTest")]
        public void UserLogin_Pass()
        {
            UserLoginSuccess();
        }

        public void UserLoginSuccess()
        {
            GotoPage(IdnesLoginPage);

            //Přihlásit button
            ClickOnElement_ById("portalogin-link");
            
            InputTextToElement_ByCss("input[name='email']", UserEmail);
            ClickOnElement_ById("fLogin");            
            
            InputTextToElement_ByCss("input[name='pass']", UserPass);
            ClickOnElement_ById("fLoginPass");

            CheckIfElemetIsPresent_ByCss(".icon-login1");
        }


    }
}