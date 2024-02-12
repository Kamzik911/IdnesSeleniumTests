using IdnesSeleniumTests.Setup;

namespace IdnesSeleniumTests.Tests
{
    [TestClass]
    public class TestMethods : WorkWithElements
    {
        string UserEmail = "t44899692@gmail.com";
        string UserPass = "581210";
        string WrongEmail = "WrongEmail@gmail.com";
        string IdnesLoginPage = "https://idnes.cz";        

        public void DenyAllCookies()
        {
            //Click Podrobné nastavení button
            ClickOnElementIfPresent_ByCss("button[id='didomi-notice-learn-more-button']");

            //Zamítnout vše
            ClickOnElementIfPresent_ByCss("button[id='didomi-radio-option-disagree-to-all']");

            //Potvrdit moje volby
            ClickOnElementIfPresent_ByCss("button[class='didomi-components-button didomi-button didomi-components-button--color didomi-button-highlight highlight-button']");
        }

        public void UserLoginSuccess()
        {
            GotoPage(IdnesLoginPage);

            DenyAllCookies();

            //Přihlásit button
            ClickOnElement_ById("portalogin-link");

            //Input right email address
            InputTextToElement_ByCss("input[name='email']", UserEmail);
            ClickOnElement_ById("fLogin");

            //Input right password
            InputTextToElement_ByCss("input[name='pass']", UserPass);
            ClickOnElement_ById("fLoginPass");

            CheckVisibleElement_ByCss(".icon-login1");
        }

        public void UserLogoutSuccess()
        {
            UserLoginSuccess();

            //Můj účet button
            ClickOnElementIfPresent_ByCss(".icon-login1");

            //Odhlásit button
            ClickOnElementIfPresent_ByCss("a[onclick='navigator.credentials && navigator.credentials.preventSilentAccess && navigator.credentials.preventSilentAccess()']");

            CheckVisibleElement_ByCss(".icon-login0");

        }

        public void InputBlankEmail()
        {
            GotoPage(IdnesLoginPage);

            DenyAllCookies();

            //Přihlásit button
            ClickOnElement_ById("portalogin-link");

            InputTextToElement_ByCss("input[name='email']", "");
            ClickOnElement_ById("fLogin");

            AssertIfElementIsVisible_ByCss("[class='error']");            
        }        

        public void InputBlankPassword()
        {
            GotoPage(IdnesLoginPage);

            DenyAllCookies();

            //Přihlásit button
            ClickOnElement_ById("portalogin-link");

            //Input right email address
            InputTextToElement_ByCss("input[name='email']", UserEmail);
            ClickOnElement_ById("fLogin");

            //Input blank password
            InputTextToElement_ByCss("input[name='pass']", "");
            ClickOnElement_ById("fLoginPass");

            CheckVisibleElement_ByCss(".error");
        }
    }
}