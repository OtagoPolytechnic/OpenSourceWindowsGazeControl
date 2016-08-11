using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GazeToolBar;

namespace ScollClassTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ScrollControl testscrole = new ScrollControl(100, 20, 50);

            Assert.IsTrue(true);

        }
    }
}
