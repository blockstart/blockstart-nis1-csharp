using io.nem1.sdk.Model.Wallet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Model.Wallet
{
    [TestClass]
    public class EncryptedPrivateKeyTests
    {
        [TestMethod]
        public void CreateEncryptedKeyFromConstructor()
        {
            var key = new EncryptedPrivateKey("4344645752e57065f814b51713d05810b6edb40bae6d099f099775bc828e36961f7fbb5e3ee62236714ad1e980ac8986bd4ed690f576abb5268ba0915ae575e7");
            
            Assert.AreEqual("4344645752e57065f814b51713d05810", key.Iv);
            Assert.AreEqual("b6edb40bae6d099f099775bc828e36961f7fbb5e3ee62236714ad1e980ac8986bd4ed690f576abb5268ba0915ae575e7", key.EncryptedKey);
        }

        [TestMethod]
        public void DecreyptEncryptedKey()
        {
            var privateKeyEncrypted = new EncryptedPrivateKey("4344645752e57065f814b51713d05810b6edb40bae6d099f099775bc828e36961f7fbb5e3ee62236714ad1e980ac8986bd4ed690f576abb5268ba0915ae575e7");
            var privateKeyDecrypted = privateKeyEncrypted.Decrypt(new Password("password"));
            Assert.AreEqual("e85467d94fdf70b5713d3b3b083597e0962f38843feb10259158a3fa6dc444b6", privateKeyDecrypted);
        }
    }
}
