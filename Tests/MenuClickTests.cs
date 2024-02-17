namespace IdnesSeleniumTests.Tests
{
    [TestClass]
    public class MenuClickTests : TestMethods
    {
        [TestMethod("ZpravodajstviMenu")]
        public void GoToZpravodajstviSite_Pass()
        {
            GoToZpravodajstviSite();
        }

        [TestMethod("KrajeMenu")]
        public void GoToKrajeSite_Pass()
        {
            GoToKrajeSite();
        }

        [TestMethod("SportMenu")]
        public void GoToSportSite_Pass()
        {
            GoToSportSite();
        }
    }
}
