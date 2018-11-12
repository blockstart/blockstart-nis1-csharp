﻿//
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
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using io.nem1.sdk.Infrastructure.HttpRepositories;
using io.nem1.sdk.Model.Accounts;
using io.nem1.sdk.Model.Blockchain;
using io.nem1.sdk.Model.Mosaics;
using io.nem1.sdk.Model.Node;
using io.nem1.sdk.Model.Transactions;
using io.nem1.sdk.Model.Transactions.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTest.infrastructure.Transactions
{
    [TestClass]
    public class TransferTransactionTests
    {
        [TestMethod, Timeout(20000)]
        public async Task AnnounceTransferTransactionWithMosaicWithMessage()
        {
            KeyPair keyPair = KeyPair.CreateFromPrivateKey(Config.PrivateKeyMain);
            ExtendedNodeInfo nodeHttp = await new NodeHttp("http://" + Config.Domain + ":7890").GetExtendedNodeInfo();
      
            TransferTransaction transaction = TransferTransaction.Create(
                NetworkType.Types.TEST_NET,
                new Deadline(1, nodeHttp.NisInfo.CurrentTime),
                Address.CreateFromEncoded("TCXECVMH7XV6XERR7IBJX7RZTEAHPK6SOGRVGUCE"),
                new List<Mosaic> {Mosaic.CreateFromIdentifier("cache:cache", 10, new MosaicProperties(6, 1000000000, false, true))},
                EmptyMessage.Create()
            );

            SignedTransaction signedTransaction = transaction.SignWith(keyPair);
            Console.WriteLine(signedTransaction.Hash);
            Console.WriteLine(transaction.Fee);
            TransactionResponse response = await new TransactionHttp("http://" + Config.Domain + ":7890").Announce(signedTransaction);
           
            Assert.AreEqual("SUCCESS", response.Message);
        }
      
        [TestMethod, Timeout(20000)]
        public async Task AnnounceTransferTransactionWithMosaicWithSecureMessage()
        {
            var keyPair = KeyPair.CreateFromPrivateKey(Config.PrivateKeyMain);
      
            var transaction = TransferTransaction.Create(
                NetworkType.Types.TEST_NET,
                Deadline.CreateHours(2),
                Address.CreateFromEncoded("TAVPDJ-DR3R3X-4FJUKN-PY2IQB-NNRFV2-QR5NJZ-J3WR"),
                new List<Mosaic> { Mosaic.CreateFromIdentifier("cache:cache", 10) },
                SecureMessage.Create("hello2", Config.PrivateKeyMain, "4cc7409929a72019240065c9e53aa339f87ba889238ff9fbe978251fdbb05d9f")
            ).SignWith(keyPair);
      
            var response = await new TransactionHttp("http://" + Config.Domain + ":7890").Announce(transaction);

            Assert.AreEqual("SUCCESS", response.Message);
        }
       
        [TestMethod, Timeout(20000)]
        public async Task AnnounceTransferTransactionWithMultipleMosaicsWithSecureMessage()
        {
            var keyPair =
                KeyPair.CreateFromPrivateKey(Config.PrivateKeyMain);
       
            var transaction = TransferTransaction.Create(
                NetworkType.Types.TEST_NET,
                Deadline.CreateHours(2),
                Address.CreateFromEncoded("TALICE-ROONSJ-CPHC63-F52V6F-Y3SDMS-VAEUGH-MB7C"),
                new List<Mosaic>()
                {
                    Mosaic.CreateFromIdentifier("nem:xem", 1000),
                    //Mosaic.CreateFromIdentifier("nis1porttest:test", 10), TODO: fix multiple mosaic transfer
                },
                SecureMessage.Create("hello2", Config.PrivateKeyMain, "5D8BEBBE80D7EA3B0088E59308D8671099781429B449A0BBCA6D950A709BA068")               
            ).SignWith(keyPair);
       
            var response = await new TransactionHttp("http://" + Config.Domain + ":7890").Announce(transaction);

            Assert.AreEqual("SUCCESS", response.Message);
        }

        [TestMethod, Timeout(20000)]
        public async Task AnnounceTransferTransactionWithMultipleMosaicsWithoutMessage()
        {
            var keyPair =
                KeyPair.CreateFromPrivateKey(Config.PrivateKeyMain);
      
            var transaction = TransferTransaction.Create(
                NetworkType.Types.TEST_NET,
                Deadline.CreateHours(2),
                Address.CreateFromEncoded("TALICE-ROONSJ-CPHC63-F52V6F-Y3SDMS-VAEUGH-MB7C"),
                new List<Mosaic>()
                {                                    
                    Mosaic.CreateFromIdentifier("nem:xem", 10)
                },
                EmptyMessage.Create()        
            ).SignWith(keyPair);
            
            var response = await new TransactionHttp("http://" + Config.Domain + ":7890").Announce(transaction);
               
            Assert.AreEqual("SUCCESS", response.Message);
        }
    }
}
