using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarkByLearnedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkByLearnedData.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetKeywordRegexTest()
        {
            var keyword = "H2N‐C6‐5′TTGGTGGTGGTGGTTGTGGTGGTGGTGG‐3′‐OH";
            var output = Program.GetKeywordRegex(keyword);
        }
    }
}

namespace MarkByLearnedDataTests
{
    class ProgramTests
    {
    }
}
