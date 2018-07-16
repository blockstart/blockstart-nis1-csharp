using System;
using System.Collections.Generic;
using io.nem1.sdk.Core.Crypto.Chaso.NaCl;
using io.nem1.sdk.Core.Utils;
using io.nem1.sdk.Infrastructure.Buffers;
using io.nem1.sdk.Infrastructure.Buffers.Schema;
using io.nem1.sdk.Infrastructure.Imported.FlatBuffers;
using io.nem1.sdk.Model.Accounts;
using io.nem1.sdk.Model.Blockchain;
using io.nem1.sdk.Model.Network;

namespace io.nem1.sdk.Model.Transactions
{
    

    public class MultisigAggregateModificationTransaction : Transaction
    {
        /// <summary>
        /// Gets the relative change of minimum signatures for the multisig account.
        /// </summary>
        /// <value>The relative change.</value>
        public int RelativeChange { get; }
        /// <summary>
        /// Gets the modifications to be made.
        /// </summary>
        /// <value>The modifications.</value>
        public List<MultisigModification> Modifications { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultisigAggregateModificationTransaction"/> class.
        /// </summary>
        /// <param name="networkType">Type of the network.</param>
        /// <param name="version">The version.</param>
        /// <param name="deadline">The deadline.</param>
        /// <param name="fee">The fee.</param>
        /// <param name="relativeChange">The relative change.</param>
        /// <param name="modifications">The modifications.</param>
        /// <param name="signature">The signature.</param>
        /// <param name="signer">The signer.</param>
        /// <param name="transactionInfo">The transaction information.</param>
        public MultisigAggregateModificationTransaction(NetworkType.Types networkType, int version, Deadline deadline, ulong fee, int relativeChange, List<MultisigModification> modifications, string signature, PublicAccount signer, TransactionInfo transactionInfo)
        {
            TransactionType = TransactionTypes.Types.MultisigAggregateModification;
            Version = version;
            Deadline = deadline;
            NetworkType = networkType;
            Signature = signature;
            Signer = signer;
            TransactionInfo = transactionInfo;
            Fee = fee == 0 ? 500000 : fee;
            RelativeChange = relativeChange;
            Modifications = modifications;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultisigAggregateModificationTransaction"/> class.
        /// </summary>
        /// <param name="networkType">Type of the network.</param>
        /// <param name="version">The version.</param>
        /// <param name="deadline">The deadline.</param>
        /// <param name="fee">The fee.</param>
        /// <param name="relativeChange">The relative change.</param>
        /// <param name="modifications">The modifications.</param>
        public MultisigAggregateModificationTransaction(NetworkType.Types networkType, int version, Deadline deadline, ulong fee, int relativeChange, List<MultisigModification> modifications)
        {
            TransactionType = TransactionTypes.Types.MultisigAggregateModification;
            Version = version;
            Deadline = deadline;
            NetworkType = networkType;
            Fee = fee == 0 ? 500000 : fee;
            RelativeChange = relativeChange;
            Modifications = modifications;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultisigAggregateModificationTransaction"/> class.
        /// </summary>
        /// <param name="networkType">Type of the network.</param>
        /// <param name="version">The version.</param>
        /// <param name="deadline">The deadline.</param>
        /// <param name="fee">The fee.</param>
        /// <param name="modifications">The modifications.</param>
        public MultisigAggregateModificationTransaction(NetworkType.Types networkType, int version, Deadline deadline, ulong fee, List<MultisigModification> modifications)
        {
            TransactionType = TransactionTypes.Types.MultisigAggregateModification;
            Version = version;
            Deadline = deadline;
            NetworkType = networkType;
            Fee = fee == 0 ? 500000 : fee;
            Modifications = modifications;
        }

        /// <summary>
        /// Creates an instance of MultisigAggregateModificationTransaction.
        /// </summary>
        /// <param name="network">The network.</param>
        /// <param name="deadline">The deadline.</param>
        /// <param name="fee">The fee.</param>
        /// <param name="relativeChange">The relative change.</param>
        /// <param name="modifications">The modifications.</param>
        /// <returns>MultisigAggregateModificationTransaction.</returns>
        public static MultisigAggregateModificationTransaction Create(NetworkType.Types network, Deadline deadline, ulong fee, int relativeChange, List<MultisigModification> modifications)
        {
            return new MultisigAggregateModificationTransaction(network, 2, deadline, fee, relativeChange, modifications);
        }

        /// <summary>
        ///  Creates an instance of MultisigAggregateModificationTransaction.
        /// </summary>
        /// <param name="network">The network.</param>
        /// <param name="deadline">The deadline.</param>
        /// <param name="relativeChange">The relative change.</param>
        /// <param name="modifications">The modifications.</param>
        /// <returns>MultisigAggregateModificationTransaction.</returns>
        public static MultisigAggregateModificationTransaction Create(NetworkType.Types network, Deadline deadline, int relativeChange, List<MultisigModification> modifications)
        {
            return new MultisigAggregateModificationTransaction(network, 2, deadline, 500000, relativeChange, modifications);
        }

        /// <summary>
        ///  Creates an instance of MultisigAggregateModificationTransaction.
        /// </summary>
        /// <param name="network">The network.</param>
        /// <param name="deadline">The deadline.</param>
        /// <param name="modifications">The modifications.</param>
        /// <returns>MultisigAggregateModificationTransaction.</returns>
        public static MultisigAggregateModificationTransaction Create(NetworkType.Types network, Deadline deadline, List<MultisigModification> modifications)
        {
            return new MultisigAggregateModificationTransaction(network, 2, deadline, 500000, modifications);
        }

        internal override byte[] GenerateBytes()
        {
            var builder = new FlatBufferBuilder(1);
            var signer = MultisigAggregateModificationBuffer.CreatePublicKeyVector(builder, GetSigner());

            var mods = new Offset<ModificationBuffer>[Modifications.Count];
            for (var index = 0; index < Modifications.Count; index++)
            {
                var cosig = ModificationBuffer.CreateCosignatoryPublicKeyVector(builder, Modifications[index].CosignatoryPublicKey.PublicKey.FromHex());

                ModificationBuffer.StartModificationBuffer(builder);

                ModificationBuffer.AddStructureLength(builder, 0x28);
                ModificationBuffer.AddModificationType(builder, Modifications[index].ModificationType.GetValue());
                ModificationBuffer.AddCosignatoryPublicKeyLen(builder, 32);
                ModificationBuffer.AddCosignatoryPublicKey(builder, cosig);

                mods[index] = ModificationBuffer.EndModificationBuffer(builder);
            }

            var modificationsVector = MultisigAggregateModificationBuffer.CreateModificationsVector(builder, mods);
            
            MultisigAggregateModificationBuffer.StartMultisigAggregateModificationBuffer(builder);

            MultisigAggregateModificationBuffer.AddTransactionType(builder, TransactionType.GetValue());
            MultisigAggregateModificationBuffer.AddVersion(builder, BitConverter.ToInt16(new byte[] { ExtractVersion(Version), 0 }, 0)); 
            MultisigAggregateModificationBuffer.AddNetwork(builder, BitConverter.ToInt16(new byte[] { 0, NetworkType.GetNetwork() }, 0));
            MultisigAggregateModificationBuffer.AddTimestamp(builder, NetworkTime.EpochTimeInMilliSeconds());
            MultisigAggregateModificationBuffer.AddPublicKeyLen(builder, 32); 
            MultisigAggregateModificationBuffer.AddPublicKey(builder, signer);
            MultisigAggregateModificationBuffer.AddFee(builder, Fee);
            MultisigAggregateModificationBuffer.AddDeadline(builder, Deadline.Ticks); 
            MultisigAggregateModificationBuffer.AddNumerOfModifications(builder, Modifications.Count);
            MultisigAggregateModificationBuffer.AddModifications(builder, modificationsVector);
            MultisigAggregateModificationBuffer.AddMinimumCosignatoriesLength(builder, RelativeChange == 0 ? 0 : 0x04);
            if (RelativeChange > 0) MultisigAggregateModificationBuffer.AddRelativeChange(builder, RelativeChange);

            var codedTransfer = MultisigAggregateModificationBuffer.EndMultisigAggregateModificationBuffer(builder);
            builder.Finish(codedTransfer.Value);

            var bytes = new MultisigAggregateModificationSchema().Serialize(builder.SizedByteArray());

            return RelativeChange > 0 ? bytes : bytes.Take(0, bytes.Length - 1); // flatbuffers is appending 0x00 to the stream as a default value due to the missing relative change when its not included in the transaction so im just cutting off the 0x00 as a short term fix. will fix sometime this decade.
        }
    }
}
