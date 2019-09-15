using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone.Tests
{
    [TestClass]
    public class ReaderTests
    {
        [TestMethod]
        public void Read_ValidData_ReturnsTuplesInList()
        {
            string lineData = $"10:00 London{Environment.NewLine}";
            lineData += "18:00 Arizona";

            IReader<string> reader = new Reader();
            IList<Tuple<string, string>> timezoneList = reader.Read(lineData);

            Assert.IsTrue(timezoneList.Count > 0);
        }

        [TestMethod]
        public void Read_InvalidData_ReturnsEmptyList()
        {
            string lineData = $"Invalid text line";

            IReader<string> reader = new Reader();
            IList<Tuple<string, string>> timezoneList = reader.Read(lineData);

            Assert.IsTrue(timezoneList.Count == 0);
        }

        [TestMethod]
        public void Read_NullInputFile_ReturnsEmptyList()
        {
            string lineData = null;

            IReader<string> reader = new Reader();
            IList<Tuple<string, string>> timezoneList = reader.Read(lineData);

            Assert.IsTrue(timezoneList.Count == 0);
        }
    }
}
