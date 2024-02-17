using IdnesSeleniumTests.Tests;

namespace IdnesSeleniumTests.BDDTests
{
    [Binding]
    public class UserLoginStepDefinitions : TestMethods
    {
        string UserEmail = "t44899692@gmail.com";
        string UserPass = "581210";        
        string IdnesLoginPage = "https://idnes.cz";

        [Given(@"User go to login page")]
        public void GivenUserGoToLoginPage()
        {
            GotoPage(IdnesLoginPage);
            DenyAllCookies();
        }

        [Given(@"User set valid email")]
        public void GivenUserSetValidEmail()
        {
            ClickOnElement_ById("portalogin-link");
            InputTextToElement_ByCss("input[name='email']", UserEmail);
        }

        [Given(@"User click on continue button")]
        public void GivenUserClickOnContinueButton()
        {
            ClickOnElement_ById("fLogin");
        }

        [Given(@"User set valid password")]
        public void GivenUserSetValidPassword()
        {
            InputTextToElement_ByCss("input[name='pass']", UserPass);
        }

        [When(@"User click on login button")]
        public void WhenUserClickOnLoginButton()
        {
            ClickOnElement_ById("fLoginPass");
        }

        [Then(@"User should by able to login")]
        public void ThenUserShouldByAbleToLogin()
        {
            CheckVisibleElement_ByCss(".icon-login1");
        }
    }
}
