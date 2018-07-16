using System;
using System.Collections.Generic;
using System.Text;
using io.nem1.sdk.Model.Wallet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test.src.Model.Wallet
{
    public class PasswordTest
    {
        [TestMethod]
        public void CreatePassword()
        {
            var pass = new Password("TestTest");

            Assert.AreEqual("TestTest", pass.Value);
        }
    }
}
