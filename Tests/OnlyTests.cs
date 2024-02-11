namespace IdnesSeleniumTests.Tests
{
    public class OnlyTests : UserLoginTests
    {
        [TestMethod("LoginSuccess")]
        public void UserLogin_Pass()
        {
            UserLoginSuccess();
        }

        [TestMethod("InputWrongEmail")]
        public void ImputWrongEmail_Pass()
        {
            EmptyEmail();
        }
    }
}
