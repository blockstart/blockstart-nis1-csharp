using io.nem1.sdk.Model.Wallet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Model.Wallet
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
