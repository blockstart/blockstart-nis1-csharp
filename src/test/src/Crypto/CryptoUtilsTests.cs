using io.nem1.sdk.Core.Crypto;
using io.nem1.sdk.Core.Crypto.Chaso.NaCl;
using io.nem1.sdk.Model.Transactions;
using io.nem1.sdk.Model.Wallet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Crypto
{
    [TestClass]
    public class CryptoUtilsTests
    {
        [TestMethod]
        public void CanHashTransaction()
        {
            var payload = "01010000010000980d500f06200000007b1a93132b8c5b8001a07f973307bee2b37bcd6dc279a59ea98179b238d44e2da0860100000000001d5e0f062800000054414c49433337443242374b5246484758524a41514f363759574f5557574133364f55343648534700e40b54020000000a00000001000000020000006869";
            var hash = TransactionExtensions.Hasher(payload.FromHex()).ToHexLower();

            Assert.AreEqual(hash, "7ae93e9f851f1916931295de6972cd8d96d8c8865720bc57442a718b3f11eb9d");
        }

        [TestMethod]
        public void ToMobileKey()
        {
            var password = "TestTest";
            var encrypted = CryptoUtils.ToMobileKey(password, "2a91e1d5c110a8d0105aad4683f962c2a56663a3cad46666b16d243174673d90");
            var key = CryptoUtils.FromMobileKey(encrypted, "TestTest");

            Assert.AreEqual(key, "2a91e1d5c110a8d0105aad4683f962c2a56663a3cad46666b16d243174673d90");
        }

        [TestMethod]
        public void DeriveKeyFromPasswordSha()
        {
            var password = "TestTest";
            var count = 20;
            var expectedKey = "8CD87BC513857A7079D182A6E19B370E907107D97BD3F81A85BCEBCC4B5BD3B5";

            var key = CryptoUtils.DerivePassSha(password, count);

            Assert.AreEqual(expectedKey, key.ToHexUpper());
        }

        [TestMethod]
        public void CanEcryptAPrivateKey()
        {
            // password for nano produced simple wallet file
            var password = "simplewallet";

            // key to encrypt
            var privateKey = "9b4ed1b56be9e8106da2ef4fc681db0f9f4c22ccbad5f9bb9d3fbe68a1b20007";

            // iv from nano produced simple wallet file
            var iv = "d590ab155351abdd9c511e8fb46ee7a9";

            // encrypted key from nano produced wallet file
            var encryptedKey = "590c675be30dc85d2512620b0526c5ddb6756adf98ebf827f7c124e9f115a81943b741d71de4397901cdb1b917bf1d65";

            var pass = CryptoUtils.DerivePassSha(password, 20);

            var result = CryptoUtils.AesEncryptor(pass, iv.FromHex(), privateKey.FromHex());
     
            var encKey = new EncryptedPrivateKey(result.ToHexLower());

            Assert.AreEqual(iv, encKey.Iv);
            Assert.AreEqual(encryptedKey, encKey.EncryptedKey);
        }

        [TestMethod]
        public void CanDecryptPrivateKey()
        {
            // password for nano produced simple wallet file
            var password = "simplewallet";

            // private key from nano produced wallet file
            var expectedPrivateKey = "9b4ed1b56be9e8106da2ef4fc681db0f9f4c22ccbad5f9bb9d3fbe68a1b20007";

            // encrypted private key from nano produced wallet file
            var encrypted = "590c675be30dc85d2512620b0526c5ddb6756adf98ebf827f7c124e9f115a81943b741d71de4397901cdb1b917bf1d65";

            // iv from nano produced wallet file
            var iv = "d590ab155351abdd9c511e8fb46ee7a9";

            var pass = CryptoUtils.DerivePassSha(password, 20);

            // Act:
            var decrypted = CryptoUtils.AesDecryptor(pass, iv.FromHex(), encrypted.FromHex()).ToHexLower();
            
            // Assert:
            Assert.AreEqual(expectedPrivateKey, decrypted);
        }


        [TestMethod]
        public void CanEncodeAndDecodePrivateKey()
        {
            var encKey = CryptoUtils.EncodePrivateKey("9b4ed1b56be9e8106da2ef4fc681db0f9f4c22ccbad5f9bb9d3fbe68a1b20007", "simplewallet");

            var key = new EncryptedPrivateKey(encKey);

            var unencrypted = key.Decrypt(new Password("simplewallet"));

            Assert.AreEqual("9b4ed1b56be9e8106da2ef4fc681db0f9f4c22ccbad5f9bb9d3fbe68a1b20007", unencrypted);      
        }
    }
}
