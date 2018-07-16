using System;
using System.Text;
using io.nem1.sdk.Core.Crypto.Chaso.NaCl;
using io.nem1.sdk.Infrastructure.Buffers;
using io.nem1.sdk.Infrastructure.Buffers.Schema;
using io.nem1.sdk.Infrastructure.Imported.FlatBuffers;
using io.nem1.sdk.Model.Accounts;
using io.nem1.sdk.Model.Blockchain;
using io.nem1.sdk.Model.Network;

namespace io.nem1.sdk.Model.Transactions
{
    public class CosignatureTransaction : Transaction
    {
        /// <summary>
        /// Get the hash of the transaction to sign.
        /// </summary>
        /// <value>The other hash.</value>
        public string OtherHash { get; }

        /// <summary>
        /// Gets the multisig address.
        /// </summary>
        /// <value>The multisig address.</value>
        public Address MultisigAddress { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CosignatureTransaction"/> class.
        /// </summary>
        /// <param name="networkType">Type of the network.</param>
        /// <param name="version">The version.</param>
        /// <param name="deadline">The deadline.</param>
        /// <param name="fee">The fee.</param>
        /// <param name="hash">The hash of the transaction to sign.</param>
        /// <param name="multisigAddress">The multisig address.</param>
        /// <param name="signature">The signature.</param>
        /// <param name="signer">The signer.</param>
        /// <param name="transactionInfo">The transaction information.</param>
        public CosignatureTransaction(NetworkType.Types networkType, int version, Deadline deadline, ulong fee, string hash, Address multisigAddress, string signature, PublicAccount signer, TransactionInfo transactionInfo)
        {
            TransactionType = TransactionTypes.Types.SignatureTransaction;
            Version = version;
            Deadline = deadline;
            NetworkType = networkType;
            Signature = signature;
            Signer = signer;
            TransactionInfo = transactionInfo;
            Fee = fee == 0 ? 150000 : fee;
            OtherHash = hash;
            MultisigAddress = multisigAddress;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CosignatureTransaction"/> class.
        /// </summary>
        /// <param name="networkType">Type of the network.</param>
        /// <param name="version">The version.</param>
        /// <param name="deadline">The deadline.</param>
        /// <param name="fee">The fee.</param>
        /// <param name="hash">The hash of the transaction to sign.</param>
        /// <param name="multisigAddress">The multisig address.</param>
        public CosignatureTransaction(NetworkType.Types networkType, int version, Deadline deadline, ulong fee, string hash, Address multisigAddress)
        {
            TransactionType = TransactionTypes.Types.SignatureTransaction;
            Version = version;
            Deadline = deadline;
            NetworkType = networkType;
            Fee = fee == 0 ? 150000 : fee;
            OtherHash = hash;
            MultisigAddress = multisigAddress;
        }

        /// <summary>
        /// Creates the specified network.
        /// </summary>
        /// <param name="network">The network.</param>
        /// <param name="deadline">The deadline.</param>
        /// <param name="fee">The fee.</param>
        /// <param name="hash">The hash of the transaction to sign.</param>
        /// <param name="multisigAddress">The multisig address.</param>
        /// <returns>CosignatureTransaction.</returns>
        /// <example>
        /// This sample shows how to use the static CosignatureTransaction <see>
        ///         <cref>Create</cref>
        ///     </see>
        ///     method. 
        /// var signatureTransaction = CosignatureTransaction.Create(
        ///         NetworkType.Types.TEST_NET,
        ///         Deadline.CreateHours(1), 
        ///         1000000,
        ///         "59f5f7cbbdaa996b8d3c45ce814280aab3b5d322a98fe95c00ae516cf436172d", 
        ///         multisigAccount.Address
        /// );
        /// 
        /// </example>
        public static CosignatureTransaction Create(NetworkType.Types network, Deadline deadline, ulong fee, string hash, Address multisigAddress)
        {
            return new CosignatureTransaction(network, 1, deadline, fee, hash, multisigAddress);
        }

        /// <summary>
        /// Creates the specified network.
        /// </summary>
        /// <param name="network">The network.</param>
        /// <param name="deadline">The deadline.</param>
        /// <param name="hash">The hash of the transaction to sign.</param>
        /// <param name="multisigAddress">The multisig address.</param>
        /// <returns>CosignatureTransaction.</returns>
        /// <example>
        /// This sample shows how to use the static CosignatureTransaction <see>
        ///         <cref>Create</cref>
        ///     </see>
        ///     method. 
        /// var signatureTransaction = CosignatureTransaction.Create(
        ///         NetworkType.Types.TEST_NET,
        ///         Deadline.CreateHours(1), 
        ///         "59f5f7cbbdaa996b8d3c45ce814280aab3b5d322a98fe95c00ae516cf436172d", 
        ///         multisigAccount.Address
        /// );
        /// 
        /// </example>
        public static CosignatureTransaction Create(NetworkType.Types network, Deadline deadline, string hash, Address multisigAddress)
        {
            return new CosignatureTransaction(network, 1, deadline, 0, hash, multisigAddress);
        }

        internal override byte[] GenerateBytes()
        {
            var builder = new FlatBufferBuilder(1);
            var signer = SignatureTransactionBuffer.CreatePublicKeyVector(builder, GetSigner());
            var hash = SignatureTransactionBuffer.CreateHashVector(builder, OtherHash.FromHex());
            var address = SignatureTransactionBuffer.CreateMultisigAddressVector(builder, Encoding.UTF8.GetBytes(MultisigAddress.Plain));

            SignatureTransactionBuffer.StartSignatureTransactionBuffer(builder);

            SignatureTransactionBuffer.AddTransactionType(builder, TransactionType.GetValue()); 
            SignatureTransactionBuffer.AddVersion(builder, BitConverter.ToInt16(new byte[] { ExtractVersion(Version), 0 }, 0)); 
            SignatureTransactionBuffer.AddNetwork(builder, BitConverter.ToInt16(new byte[] { 0, NetworkType.GetNetwork() }, 0)); 
            SignatureTransactionBuffer.AddTimestamp(builder, NetworkTime.EpochTimeInMilliSeconds()); 
            SignatureTransactionBuffer.AddPublicKeyLen(builder, 32); 
            SignatureTransactionBuffer.AddPublicKey(builder, signer); 
            SignatureTransactionBuffer.AddFee(builder, Fee); 
            SignatureTransactionBuffer.AddDeadline(builder, Deadline.Ticks); 
            SignatureTransactionBuffer.AddHashObjLength(builder, 0x24); 
            SignatureTransactionBuffer.AddSha3HashLength(builder, 0x20); 
            SignatureTransactionBuffer.AddHash(builder, hash); 
            SignatureTransactionBuffer.AddAddressLength(builder, 0x28); 
            SignatureTransactionBuffer.AddMultisigAddress(builder, address); 

            var result = SignatureTransactionBuffer.EndSignatureTransactionBuffer(builder);
            builder.Finish(result.Value);

            return new SignatureTransactionSchema().Serialize(builder.SizedByteArray());
        }
    }
}
