using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void DisplayTime_NullTimeParameter_NoNullExceptionThrown()
        {
            IParser parser = new Parser();

            try
            {
                Assert.ThrowsException<NullReferenceException>(() => parser.DisplayTime(null, "London"));
            }

            catch (AssertFailedException ex)
            {
                Assert.IsTrue(ex.Message.Contains("No exception thrown"));
            }
        }

        [TestMethod]
        public void DisplayTime_NullTimezoneParameter_NoNullExceptionThrown()
        {
            IParser parser = new Parser();

            try
            {
                Assert.ThrowsException<NullReferenceException>(() => parser.DisplayTime("09:00", null));
            }

            catch (AssertFailedException ex)
            {
                Assert.IsTrue(ex.Message.Contains("No exception thrown"));
            }
        }

        [TestMethod]
        public void DisplayTime_AllParametersNull_NoNullExceptionThrown()
        {
            IParser parser = new Parser();

            try
            {
                Assert.ThrowsException<NullReferenceException>(() => parser.DisplayTime(null, null));
            }

            catch (AssertFailedException ex)
            {
                Assert.IsTrue(ex.Message.Contains("No exception thrown"));
            }
        }
    }
}
