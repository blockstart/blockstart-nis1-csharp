using io.nem1.sdk.Model.Mosaics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test.Model.MosaicsTests
{
    [TestClass]
    public class MosaicIdTest
    {

        [TestMethod]
        public void CreateAMosaicIdFromMosaicNameViaConstructor()
        {
            MosaicId mosaicId = new MosaicId("nem:xem");
            Assert.AreEqual(mosaicId.FullName, "nem:xem");
            Assert.AreEqual(mosaicId.Name, "xem");

        }
    }
}
