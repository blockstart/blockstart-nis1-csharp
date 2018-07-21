using System.Text;
using System.Text.RegularExpressions;
using io.nem1.sdk.Model.Wallet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Tests.Model.Wallet
{
    [TestClass]
    public class ReadSimpleWalletTest
    {
        [TestMethod]
        public void ReadWallet()
        {
            var original = "{\"privateKey\":\"\",\"name\":\"simplewallet\",\"accounts\":{\"0\":{\"brain\":true,\"algo\":\"pass:bip32\",\"encrypted\":\"590c675be30dc85d2512620b0526c5ddb6756adf98ebf827f7c124e9f115a81943b741d71de4397901cdb1b917bf1d65\",\"iv\":\"d590ab155351abdd9c511e8fb46ee7a9\",\"address\":\"NCDDOQ5H24ST45P5HL3JMZK4HNRWPXVFBA5TW7AF\",\"label\":\"Primary\",\"network\":104,\"child\":\"d1ac27f8574cb157171f14b5fd26ebc124e3837b486d97217c9d85ac8ac63099\"}}}";

            var wlt = WalletAdapter(original);
          
            Assert.AreEqual("simplewallet", wlt.Name);
        }

        [TestMethod]
        public void WriteWallet()
        {
            var original = JsonConvert.DeserializeObject<WalletObject>("{\"privateKey\":\"\",\"name\":\"simplewallet\",\"accounts\":{\"account\":[{\"brain\":true,\"algo\":\"pass:bip32\",\"encrypted\":\"590c675be30dc85d2512620b0526c5ddb6756adf98ebf827f7c124e9f115a81943b741d71de4397901cdb1b917bf1d65\",\"iv\":\"d590ab155351abdd9c511e8fb46ee7a9\",\"address\":\"NCDDOQ5H24ST45P5HL3JMZK4HNRWPXVFBA5TW7AF\",\"label\":\"Primary\",\"network\":104,\"child\":\"d1ac27f8574cb157171f14b5fd26ebc124e3837b486d97217c9d85ac8ac63099\"}]}}");

            var expected = "{\"privateKey\":\"\",\"name\":\"simplewallet\",\"accounts\":{\"0\":{\"brain\":true,\"algo\":\"pass:bip32\",\"encrypted\":\"590c675be30dc85d2512620b0526c5ddb6756adf98ebf827f7c124e9f115a81943b741d71de4397901cdb1b917bf1d65\",\"iv\":\"d590ab155351abdd9c511e8fb46ee7a9\",\"address\":\"NCDDOQ5H24ST45P5HL3JMZK4HNRWPXVFBA5TW7AF\",\"label\":\"Primary\",\"network\":104,\"child\":\"d1ac27f8574cb157171f14b5fd26ebc124e3837b486d97217c9d85ac8ac63099\"}}}";

            var newString = WalletAdapter(original);

            Assert.AreEqual(expected, newString);
        }

        protected static WalletObject WalletAdapter(string json)
        {
            var newString = Regex.Replace(json, "{\"\\d\":{", "{\"account\":[{");
            
            newString = newString.Insert(newString.Length - 2, "]");

            return JsonConvert.DeserializeObject<WalletObject>(newString);
        }

        protected static string WalletAdapter(WalletObject wlt)
        {
            var newString = JsonConvert.SerializeObject(wlt);

            return FindAndReplace(newString);
        }

        private static string FindAndReplace(string toSearchInside)
        {
            toSearchInside = toSearchInside.Replace("[", "");
            toSearchInside = toSearchInside.Replace("]", "");
            string toMatch = "{\"account\":{";

            var matches = Regex.Matches(toSearchInside, toMatch);

            string result = toSearchInside;

            for (int i =0; i < matches.Count; i++)
                result = Replace(result, matches[i].Index, matches[i].Length, "{\"" + i + "\":{");
            return result;
        }

        private static string Replace(string s, int index, int length, string replacement)
        {
            var builder = new StringBuilder();
            builder.Append(s.Substring(0, index));
            builder.Append(replacement);
            builder.Append(s.Substring(index + length));
            return builder.ToString();
        }
    }
}
