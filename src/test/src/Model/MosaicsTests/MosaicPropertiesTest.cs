//
// Copyright 2018 NEM
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using io.nem1.sdk.Model.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test.Model.MosaicsTests
{
    [TestClass]
    public class MosaicPropertiesTest
    {
        [TestMethod]
        public void ShouldCreateMosaicPropertiesViaConstructor()
        {
            var mosaicProperties = new MosaicProperties(1, 1000, true, true );

            Assert.IsTrue(mosaicProperties.Properties[0].Item2.Equals("1"));
            Assert.IsTrue(mosaicProperties.Properties[1].Item2.Equals("1000"));
            Assert.IsTrue(mosaicProperties.Properties[2].Item2.Equals("True"));
            Assert.IsTrue(mosaicProperties.Properties[3].Item2.Equals("True"));
        }

    }
}
