using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdnesSeleniumTests.Tests
{
    [TestClass]
    public class PortalMenuTests : TestMethods
    {
        [TestMethod ("Portal menu available")]
        public void PortalMenuIsClickable_Pass()
        {
            PortalMenuIsClickable();
        }
    }
}
