using System;
using System.Text.RegularExpressions;
using io.nem1.sdk.Core.Crypto.Chaso.NaCl;
using Newtonsoft.Json.Linq;

namespace io.nem1.sdk.Model.Transactions
{
    /// <summary>
    /// Class SignedMultisigTransaction.
    /// </summary>
    /// <seealso cref="io.nem1.sdk.Model.Transactions.SignedTransaction" />
    public class SignedMultisigTransaction : SignedTransaction
    {
        /// <summary>
        /// Gets the inner transaction hash.
        /// </summary>
        /// <value>The inner transaction hash.</value>
        public string InnerTransactionHash { get; }

        internal SignedMultisigTransaction(string payload, string signature, string hash, string innerHash, string signer, TransactionTypes.Types transactionType) : base(payload, signature, hash, signer, transactionType)
        {
            if (hash.Length != 64 || !Regex.IsMatch(hash, @"\A\b[0-9a-fA-F]+\b\Z")) throw new ArgumentException("Invalid hash.");
            TransactionType = transactionType;
            Payload = payload;
            Hash = hash;
            Signer = signer;
            TransactionPacket = JObject.Parse("{\"data\":\"" + payload + "\",\"signature\":\"" + signature + "\"}");
            InnerTransactionHash = innerHash;
        }

        /// <summary>
        /// Static creates a new instance of the <see cref="SignedTransaction"/> class.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <param name="hash">The hash.</param>
        /// <param name="signer">The signer.</param>
        /// <param name="transactionType">The transaction type.</param>
        /// <returns><see cref="SignedTransaction"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// payload
        /// or
        /// hash
        /// or
        /// signer
        /// </exception>
        /// <exception cref="ArgumentException">
        /// invalid hash length
        /// or
        /// invalid signer length
        /// </exception>
        public static SignedMultisigTransaction Create(byte[] payload, byte[] signature, byte[] hash, byte[] innerHash, byte[] signer, TransactionTypes.Types transactionType)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));
            if (signature == null) throw new ArgumentNullException(nameof(signature));
            if (hash == null) throw new ArgumentNullException(nameof(hash));
            if (hash.Length != 32) throw new ArgumentException("invalid hash length");
            if (signer == null) throw new ArgumentNullException(nameof(signer));
            if (signer.Length != 32) throw new ArgumentException("invalid signer length");

            return new SignedMultisigTransaction(payload.ToHexLower(), signature.ToHexLower(), hash.ToHexLower(), innerHash.ToHexLower(), signer.ToHexLower(), transactionType);
        }
    }
}
