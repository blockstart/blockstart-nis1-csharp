using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using io.nem1.sdk.Infrastructure.HttpRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTest.infrastructure.HttpTests
{
    [TestClass]
    public class NamespaceMosaicHttpTests
    {
        readonly string host = "http://" + Config.Domain + ":7890";

        [TestMethod]
        public async Task GetNamespaceInfo()
        {
            var namespaceMosaicHttp = await new NamespaceMosaicHttp(host).NamespaceInfo("testlevy");
            
            Assert.AreEqual("TCTUIF557ZCQOQPW2M6GH4TCDPM2ZYBBL54KGNHR", namespaceMosaicHttp.Owner.Plain);
            Assert.AreEqual("testlevy", namespaceMosaicHttp.Name);
            Assert.AreEqual((ulong)1183544, namespaceMosaicHttp.Height);
        }

        [TestMethod]
        public async Task GetNamespaceRootInfo()
        {
            var namespaceMosaicHttp = await new NamespaceMosaicHttp(host).NamespaceRootInfoPage();

            Assert.AreEqual(2481, namespaceMosaicHttp[0].Id);
            Assert.AreEqual("TCJPZUBD5Y5FBZYAZYYUE5ADSF6MCLDGD43V6KVZ", namespaceMosaicHttp[0].Owner.Plain);
            Assert.AreEqual("kryptosports", namespaceMosaicHttp[0].Name);
            Assert.AreEqual((ulong)1546124, namespaceMosaicHttp[0].Height);
        }

        [TestMethod]
        public async Task GetNamespaceMosaics()
        {
            var mosaics = await new NamespaceMosaicHttp(host).GetNamespaceMosaics("testlevy");

            Assert.AreEqual("TCTUIF557ZCQOQPW2M6GH4TCDPM2ZYBBL54KGNHR", mosaics[0].Creator.Address.Plain);
            Assert.AreEqual("test", mosaics[0].Description);
            Assert.AreEqual(2853, mosaics[0].Id);
            Assert.AreEqual("testlevy:nis1porttest", mosaics[0].MosaicId.FullName);
            Assert.AreEqual(6, mosaics[0].Properties.Divisibility);
            Assert.IsTrue(mosaics[0].Properties.Mutable);
            Assert.IsTrue(mosaics[0].Properties.Transferable);
        }
    }
}
