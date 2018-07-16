// ***********************************************************************
// Assembly         : nem1-sdk
// Author           : kailin
// Created          : 06-01-2018
//
// Last Modified By : kailin
// Last Modified On : 01-31-2018
// ***********************************************************************
// <copyright file="TransactionExtensions.cs" company="Nem.io">
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
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.CompilerServices;
using io.nem1.sdk.Core.Crypto.Chaso.NaCl;
using io.nem1.sdk.Model.Accounts;
using Org.BouncyCastle.Crypto.Digests;

[assembly: InternalsVisibleTo("test")]
[assembly: InternalsVisibleTo("IntegrationTest")]
namespace io.nem1.sdk.Model.Transactions
{
    /// <summary>
    /// Class TransactionExtensions.
    /// </summary>
    internal static class TransactionExtensions
    {
        /// <summary>
        /// Hashes the specified payload.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns>The transaction hash.</returns>
        internal static byte[] Hasher(byte[] payload)
        {
            var hash = new byte[32];
            var sha3Hasher = new KeccakDigest(256);
            sha3Hasher.BlockUpdate(payload, 0, payload.Length);
            sha3Hasher.DoFinal(hash, 0);

            return hash;
        }

        /// <summary>
        /// Signs the transaction.
        /// </summary>
        /// <param name="keyPair">The key pair.</param>
        /// <param name="payload">The payload.</param>
        /// <returns>The signature.</returns>
        internal static byte[] SignTransaction(KeyPair keyPair, byte[] payload)
        {
            var sig = new byte[64];          
            var sk = new byte[64];
            Array.Copy(keyPair.PrivateKey, sk, 32);
            Array.Copy(keyPair.PublicKey, 0, sk, 32, 32);
            Ed25519.crypto_sign2(sig, payload, sk, 32);
            CryptoBytes.Wipe(sk);
         
            return sig;
        }
    }
}
