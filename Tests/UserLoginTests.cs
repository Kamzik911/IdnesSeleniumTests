using IdnesSeleniumTests.Setup;

namespace IdnesSeleniumTests.Tests
{
    [TestClass]
    public class UserLoginTests : MethodsInTests
    {
        string UserEmail = "t44899692@gmail.com";
        string UserPass = "581210";
        string WrongEmail = "WrongEmail@gmail.com";
        string IdnesLoginPage = "https://idnes.cz";        

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
        
        public void EmptyEmail()
        {
            GotoPage(IdnesLoginPage);

            //Click Podrobné nastavení button
            ClickOnElement_ByCss("button[id='didomi-notice-learn-more-button']");

            //Zamítnout vše
            ClickOnElement_ByCss("button[id='didomi-radio-option-disagree-to-all']");

            //Potvrdit moje volby
            ClickOnElement_ByCss("button[class='didomi-components-button didomi-button didomi-components-button--color didomi-button-highlight highlight-button']");

            //Přihlásit button
            ClickOnElement_ById("portalogin-link");

            InputTextToElement_ByCss("input[name='email']", "");
            ClickOnElement_ById("fLogin");

            AssertIfElementIsVisible_ByCss("[class='error']");            
        }
    }
}