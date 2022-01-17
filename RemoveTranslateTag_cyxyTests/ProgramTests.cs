using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveTranslateTag_cyxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RemoveTranslateTag_cyxy.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var origin =
                File.ReadAllText(
                    @"C:\Users\DEEPBIO-RONEL\SOURCE_CODE\articletag\RemoveTranslateTag_cyxyTests\origin.html");
            var processed = Program.Process(origin);
            File.WriteAllText(@"C:\Users\DEEPBIO-RONEL\SOURCE_CODE\articletag\RemoveTranslateTag_cyxyTests\processed.html",processed);
        }
    }
}