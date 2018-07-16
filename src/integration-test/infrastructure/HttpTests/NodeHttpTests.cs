using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using io.nem1.sdk.Infrastructure.HttpRepositories;
using io.nem1.sdk.Model.Blockchain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTest.infrastructure.HttpTests
{
    [TestClass]
    public class NodeHttpTests
    {
        readonly string host = "http://" + Config.Domain + ":7890";

        [TestMethod]
        public async Task GetNodeActiveList()
        {
            var nodeHttp = await new NodeHttp(host).GetActiveNodeList();

            if (nodeHttp[0].Host == "37.61.200.170")
            {
                Assert.AreEqual(1, nodeHttp[0].Features);
                Assert.AreEqual("", nodeHttp[0].Application);
                Assert.AreEqual("37.61.200.170", nodeHttp[0].Host);
                Assert.AreEqual("TCSTORZFCDEPBSHVG3IYJB2YBQR2CPJXESSISB5N", nodeHttp[0].Name);
                Assert.AreEqual(NetworkType.Types.TEST_NET, nodeHttp[0].Network);
                Assert.AreEqual("Oracle Corporation (1.8.0_161) on Windows Server 2012 R2", nodeHttp[0].Platform);
                Assert.AreEqual("7890", nodeHttp[0].Port);
                Assert.AreEqual("http", nodeHttp[0].Protocol);
                Assert.AreEqual("e927d00de512e9de70097b31752a65b54deab3fff51b891a1efedb8af0320525", nodeHttp[0].PublicKey);
                Assert.AreEqual("0.6.93-BETA", nodeHttp[0].Version);
            }
            else if (nodeHttp[0].Host == "188.68.50.161")
            {
                Assert.AreEqual(1, nodeHttp[0].Features);
                Assert.AreEqual("", nodeHttp[0].Application);
                Assert.AreEqual("188.68.50.161", nodeHttp[0].Host);
                Assert.AreEqual("TA6TEX5NDFXIJGKPDY64RLWA5TXUZ4NPORVJZIF5", nodeHttp[0].Name);
                Assert.AreEqual(NetworkType.Types.TEST_NET, nodeHttp[0].Network);
                Assert.AreEqual("Oracle Corporation (1.8.0_121) on Linux", nodeHttp[0].Platform);
                Assert.AreEqual("7890", nodeHttp[0].Port);
                Assert.AreEqual("http", nodeHttp[0].Protocol);
                Assert.AreEqual("40515e7039dde3336134c8826be921a6e419b18b1a6c9bee27d90ac2aca90dd2", nodeHttp[0].PublicKey);
                Assert.AreEqual("0.6.93-BETA", nodeHttp[0].Version);
            }
            else if (nodeHttp[0].Host == "80.93.182.146")
            {
                Assert.AreEqual(1, nodeHttp[0].Features);
                Assert.AreEqual("", nodeHttp[0].Application);
                Assert.AreEqual("80.93.182.146", nodeHttp[0].Host);
                Assert.AreEqual("hxr.team", nodeHttp[0].Name);
                Assert.AreEqual(NetworkType.Types.TEST_NET, nodeHttp[0].Network);
                Assert.AreEqual("Oracle Corporation (1.8.0_144) on Linux", nodeHttp[0].Platform);
                Assert.AreEqual("7890", nodeHttp[0].Port);
                Assert.AreEqual("http", nodeHttp[0].Protocol);
                Assert.AreEqual("1e412cb4dda9d33cafaa0c8b575e8d073824b0b7a3073c98d1f17314a357350a", nodeHttp[0].PublicKey);
                Assert.AreEqual("0.6.95-BETA", nodeHttp[0].Version);
            }
        }

        [TestMethod]
        public async Task GetMaxHeight()
        {
            var nodeHttp = await new NodeHttp(host).GetActiveNodeMaxHeight();
            Assert.IsTrue(1 < nodeHttp);
        }

        [TestMethod]
        public async Task GetExtendedNodeInfo()
        {
            var nodeHttp = await new NodeHttp(host).GetExtendedNodeInfo();
            Assert.IsTrue(nodeHttp.NodeInfo.Network == NetworkType.Types.TEST_NET);
        }

        [TestMethod]
        public async Task GetNodeListAll() // figure out why only the queried node meta data comes back as nulls/0's
        {
            var nodeHttp = await new NodeHttp(host).GetNodePeerListAll();
            //Assert.IsTrue(nodeHttp.Active[0].Network == NetworkType.Types.TEST_NET);
        }

        [TestMethod]
        public async Task GetNodeInfo()
        {
            var nodeHttp = await new NodeHttp(host).GetNodeInfo();

            Assert.AreEqual("104.128.226.60", nodeHttp.Host);
            Assert.AreEqual("", nodeHttp.Application);
            Assert.AreEqual("Hi, I am BigAlice2", nodeHttp.Name);
            Assert.AreEqual(NetworkType.Types.TEST_NET, nodeHttp.Network);
            Assert.AreEqual("Oracle Corporation (1.8.0_40) on Linux", nodeHttp.Platform);
            Assert.AreEqual("7890", nodeHttp.Port);
            Assert.AreEqual("http", nodeHttp.Protocol);
            Assert.AreEqual("147eb3e4fccb655c03f4b6b12fc145f6a740c9334a8f3c59131dffd1fd42a996", nodeHttp.PublicKey);

        }
    }
}
