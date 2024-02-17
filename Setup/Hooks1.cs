using IdnesSeleniumTests.BDDTests;
using IdnesSeleniumTests.Tests;

namespace IdnesSeleniumTests.Setup
{
    [Binding]
    public class Hooks1 : TestMethods
    {        
        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            
        }
    }
}