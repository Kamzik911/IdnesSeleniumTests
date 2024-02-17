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
            ClickOnElementIfPresent_ByCss("button[class='didomi-components-button didomi-button didomi-button-standard standard-button']");
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

            CheckVisibleElement_ByCss("[class='error']");            
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

        public void GoToZpravodajstviSite()
        {
            GotoPage(IdnesLoginPage);

            DenyAllCookies();

            ClickOnElementIfPresent_ByCss("a[score-id='zpravodaj'][score-place='1']");

            CheckVisibleElement_ByCss("a[title='Zpravodajství']");
        }

        public void GoToKrajeSite()
        {
            GotoPage(IdnesLoginPage);

            DenyAllCookies();

            ClickOnElementIfPresent_ByCss("a[score-id='kraje'][score-place='3']");

            CheckVisibleElement_ByLinkText("Zvolte kraj");
        }

        public void GoToSportSite()
        {
            GotoPage(IdnesLoginPage);

            DenyAllCookies();

            ClickOnElementIfPresent_ByCss("a[score-id='sport'][score-place='4']");

            CheckVisibleElement_ByCss("a[score-id='sport'][title='Sport']");
        }

        public void PortalMenuIsClickable()
        {
            GotoPage(IdnesLoginPage);

            DenyAllCookies();

            ClickOnElement_ByCss("[id='portalmenu-link'][class='icon-menu']");

            CheckVisibleElement_ByCss("[id='portalmenu-link'][class='icon-menu active']");
        }
    }
}