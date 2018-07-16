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
    public class NisHttpTests
    {
        readonly string host = "http://" + Config.Domain + ":7890";

        [TestMethod]
        public async Task GetNisStatus()
        {
            var nisHttp = new NisHttp(host);
            var status = await nisHttp.GetNisStatus();
            Assert.AreEqual(6, status.Code);
        }

        [TestMethod]
        public async Task GetNisHeartBeat()
        {
            var nisHttp = new NisHttp(host);
            var status = await nisHttp.GetNisHeartBeat();
            Assert.AreEqual(1, status.Code);
        }
    }
}
