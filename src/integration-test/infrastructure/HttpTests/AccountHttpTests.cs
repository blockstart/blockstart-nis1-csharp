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
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;
using System.Threading.Tasks;
using io.nem1.sdk.Infrastructure.HttpRepositories;
using io.nem1.sdk.Model.Accounts;
using io.nem1.sdk.Model.Blockchain;
using io.nem1.sdk.Model.Mosaics;
using io.nem1.sdk.Model.Transactions;
using io.nem1.sdk.Model.Transactions.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace IntegrationTest.infrastructure.HttpTests
{
    [TestClass]
    public class AccountHttpTests
    {
        readonly string host = "http://" + Config.Domain + ":7890";

        [TestMethod, Timeout(20000)]
        public async Task GetAccountInfoFromPublicKey()
        {
            var expected = "TACOPEXRLZTUWBQA3UXV66R455L76ENWK6OYITBJ";

            var response = await new AccountHttp(host).GetAccountInfo(new PublicAccount("856f39436e33129afff95b89aca998fa23cd751a6f4d79ce4fb9da9641ecb59c", NetworkType.Types.TEST_NET));

            Assert.AreEqual(expected, response.Address.Plain);
            Assert.AreEqual("TACOPE-XRLZTU-WBQA3U-XV66R4-55L76E-NWK6OY-ITBJ", response.Address.Pretty);
            Assert.AreEqual((ulong)0, response.HarvestedBlocks);
            Assert.AreEqual("856f39436e33129afff95b89aca998fa23cd751a6f4d79ce4fb9da9641ecb59c", response.PublicAccount.PublicKey);
            Assert.AreEqual((ulong)0, response.Importance);

        }

        [TestMethod]
        public async Task GetMosaicsOwned()
        {
            var response = await new AccountHttp(host).MosaicsOwned(Address.CreateFromEncoded("TCTUIF-557ZCQ-OQPW2M-6GH4TC-DPM2ZY-BBL54K-GNHR"));

            Assert.AreEqual("xem", response[0].MosaicName);
            Assert.AreEqual("nem", response[0].NamespaceName);
            Assert.AreEqual("test", response[1].MosaicName);
            Assert.AreEqual("nis1porttest", response[1].NamespaceName);
            Assert.AreEqual((ulong)100000000000, response[1].Amount);


        }

        [TestMethod, Timeout(20000)]
        public async Task GetAccountInfoFromAddress()
        {
            var expected = "TACOPEXRLZTUWBQA3UXV66R455L76ENWK6OYITBJ";

            var response = await new AccountHttp(host).GetAccountInfo(Address.CreateFromEncoded("TACOPEXRLZTUWBQA3UXV66R455L76ENWK6OYITBJ"));

            Assert.AreEqual(expected, response.Address.Plain);

            Assert.AreEqual(expected, response.Address.Plain);
            Assert.AreEqual("TACOPE-XRLZTU-WBQA3U-XV66R4-55L76E-NWK6OY-ITBJ", response.Address.Pretty);
            Assert.AreEqual((ulong)0, response.HarvestedBlocks);
            Assert.AreEqual("856f39436e33129afff95b89aca998fa23cd751a6f4d79ce4fb9da9641ecb59c", response.PublicAccount.PublicKey);
            Assert.AreEqual((ulong)0, response.Importance);
        }

        [TestMethod]
        public async Task GetTransactionWithEncryptedMessage()
        {
            var expected = "57786d3560ae151ec9790c73713379524700bc6a2b34888b26b736c35c8c5e14";

            var response = await new AccountHttp(host).IncomingTransactions(Address.CreateFromEncoded("NB2GO2-AAZDWU-YHG3HM-VC4DHI-X6HBMD-FZXDNE-5FYZ"));

            var tx = (TransferTransaction)response[2];

            Assert.AreEqual("664dccae0a45c03ae83c4ebe42e64cb4a8efbc897a3cb8421a19b1978c48a7b8", tx.TransactionInfo.Hash);
            Assert.AreEqual(tx.Mosaics[0].MosaicName, "fluffs");
            Assert.AreEqual(tx.Mosaics[0].Amount, (ulong)3000000);
            Assert.IsTrue(tx.Message.GetMessageType() == MessageType.Type.ENCRYPTED);
            Assert.AreEqual("ZXCVBN", ((SecureMessage)tx.Message).GetDecodedPayload("523b0b58512cba0da5e8d4fa829e241326cd126bad22a5055a8cb39fdcd1bc00", "57786d3560ae151ec9790c73713379524700bc6a2b34888b26b736c35c8c5e14"));
            Assert.AreEqual(expected, tx.Signer.PublicKey);
            Assert.AreEqual("664dccae0a45c03ae83c4ebe42e64cb4a8efbc897a3cb8421a19b1978c48a7b8", tx.TransactionInfo.Hash);

        }

        [TestMethod]
        public async Task GetTransactionWithHexidecimalMessage()
        {
            var expected = "7b1a93132b8c5b8001a07f973307bee2b37bcd6dc279a59ea98179b238d44e2d";

            var response = await new AccountHttp(host).OutgoingTransactions(new PublicAccount("7b1a93132b8c5b8001a07f973307bee2b37bcd6dc279a59ea98179b238d44e2d", NetworkType.Types.TEST_NET));

            var tx = (TransferTransaction)response[0];
            Assert.AreEqual(tx.Mosaics[0].MosaicName, Xem.MosaicName);
            Assert.AreEqual(tx.Mosaics[0].Amount, (ulong)10000000);
            Assert.IsTrue(tx.Message.GetMessageType() == MessageType.Type.UNENCRYPTED);
            Assert.AreEqual("abcd1234", ((HexMessage)tx.Message).GetStringPayload());
            Assert.AreEqual(expected, tx.Signer.PublicKey);
            Assert.AreEqual("5853eaebe86307bf8a5dbddb5248490cb1f9ca6cb76c4733dab8eea157988f7a", tx.TransactionInfo.Hash);

        }

        [TestMethod, Timeout(20000)]
        public async Task GetIncomingTransactions()
        {
            var expected = "29c4a4aa674953749053c8a35399b37b713dedd5d002cb29b3331e56ff1ea65a";

            var response = await new AccountHttp(host).IncomingTransactions(new PublicAccount("29c4a4aa674953749053c8a35399b37b713dedd5d002cb29b3331e56ff1ea65a", NetworkType.Types.TEST_NET));

            Assert.AreEqual("2ec51d4e2e0a11cd6d3747848e272c51bae213ebfb4d2912b2cb6a8d86d36f86", response[0].TransactionInfo.Hash);
            Assert.AreEqual((ulong)1503213, response[0].TransactionInfo.Height);
            Assert.AreEqual(226994, response[0].TransactionInfo.Id);
            Assert.AreEqual("9d7ea57169a56a1bb821e1abf744610c639d7545f976f09808b68a6ad1415eb0", response[0].Signer.PublicKey);
            Assert.AreEqual((ulong)150000, response[0].Fee);

            var tx = (TransferTransaction)((MultisigTransaction)response[0]).InnerTransaction;

            Assert.IsNotNull(tx.Address.Plain);
            Assert.IsNotNull(tx.Mosaics);

        }

        [TestMethod, Timeout(20000)]
        public async Task GetOutgoingTransactionsWithTransfer()
        {
            var expected = "9d7ea57169a56a1bb821e1abf744610c639d7545f976f09808b68a6ad1415eb0";

            var response = await new AccountHttp(host).OutgoingTransactions(new PublicAccount("eb100d6b2da10fc5359ab35a5801b0e6f0b6cc18d849c0aa78ba1aab2b945dea", NetworkType.Types.TEST_NET));


            var tx = (MultisigTransaction)response[5];
            Assert.AreEqual(((TransferTransaction)tx.InnerTransaction).Mosaics[0].MosaicName, Xem.MosaicName);
            Assert.AreEqual(expected, tx.Signer.PublicKey);
            Assert.AreEqual("b41462f6b28bd8446f45fd90b6bda6d8eb33174b7b0c168b618d63472a815fd2", tx.TransactionInfo.InnerHash);

        }

        [TestMethod, Timeout(20000)]
        public async Task GetOutgoingTransactionsWithImportance()
        {
            var expected = "9d7ea57169a56a1bb821e1abf744610c639d7545f976f09808b68a6ad1415eb0";

            var response = await new AccountHttp(host).OutgoingTransactions(new PublicAccount("eb100d6b2da10fc5359ab35a5801b0e6f0b6cc18d849c0aa78ba1aab2b945dea", NetworkType.Types.TEST_NET));

            var tx = (MultisigTransaction)response[4];
            Assert.AreEqual(((ImportanceTransferTransaction)tx.InnerTransaction).Mode.GetValue(), 1);
            Assert.AreEqual(((ImportanceTransferTransaction)tx.InnerTransaction).TransactionInfo, null);
            Assert.AreEqual("627b03264e51fa12870a923738506c27a20a3bc50051aeb75f545db7d7725060", ((ImportanceTransferTransaction)tx.InnerTransaction).RemoteAccount.PublicKey);
            Assert.AreEqual(expected, tx.Signer.PublicKey);
            Assert.AreEqual("c48c267efe736e8950da4a6ea9fcdc5d7c48f03a3e30965552a4dc51883da486", tx.TransactionInfo.InnerHash);
        }

        [TestMethod]
        public async Task GetMultisigTransactions()
        {
            var expected = "9d7ea57169a56a1bb821e1abf744610c639d7545f976f09808b68a6ad1415eb0";

            var response = await new AccountHttp(host)
                .Transactions(new PublicAccount(
                    "29c4a4aa674953749053c8a35399b37b713dedd5d002cb29b3331e56ff1ea65a",
                    NetworkType.Types.TEST_NET));

            Assert.IsTrue(response[0].Deadline.Ticks > response[0].TransactionInfo.TimeStamp);
            Assert.AreEqual(expected, response[0].Signer.PublicKey);
            Assert.AreEqual(Address.CreateFromEncoded("TATFWN33FARG365IXE3CSKQI7KZZA4OJAVFSZ66D").Plain, Address.CreateFromPublicKey(response[0].Signer.PublicKey, NetworkType.Types.TEST_NET).Plain);

        }
    }
}
