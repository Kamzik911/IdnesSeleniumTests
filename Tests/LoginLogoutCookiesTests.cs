namespace IdnesSeleniumTests.Tests
{
    [TestClass]
    public class LoginLogoutCookiesTests : TestMethods
    {
        [TestMethod("Success login")]
        public void UserLogin_Pass()
        {
            UserLoginSuccess();
        }

        [TestMethod("Success logout")]
        public void UserLogout_Pass()
        {
            UserLogoutSuccess();
        }

        [TestMethod("Input empty email")]
        public void InputBlankEmailAddress_Pass()
        {
            InputBlankEmail();
        }
        
        [TestMethod("Input empty password")]
        public void InputBlankPassword_Pass()
        {
            InputBlankPassword();
        }       
    }
}
