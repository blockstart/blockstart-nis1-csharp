namespace io.nem1.sdk.Model.Transactions
{
    /// <summary>
    /// Class TransactionInfo.
    /// </summary>
    public class TransactionInfo
    {
        /// <summary>
        /// Gets the height at which the transaction was included in a block.
        /// </summary>
        /// <value>The height.</value>
        public ulong Height { get; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; }

        /// <summary>
        /// Gets the hash.
        /// </summary>
        /// <value>The hash.</value>
        public string Hash { get; }

        /// <summary>
        /// Gets the inner hash.
        /// </summary>
        /// <value>The inner hash.</value>
        public string InnerHash { get; }

        /// <summary>
        /// Gets the time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        public int TimeStamp { get; }

        /// <summary>
        /// Gets a value indicating whether the transaction is a multisig transaction.
        /// </summary>
        /// <value><c>true</c> if this instance is multisig; otherwise, <c>false</c>.</value>
        public bool IsMultisig => InnerHash != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionInfo"/> class.
        /// </summary>
        /// <param name="height">The height.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="hash">The hash.</param>
        /// <param name="timeStamp">The time stamp.</param>
        /// <param name="innerHash">The inner hash.</param>
        internal TransactionInfo(ulong height, int id, string hash, int timeStamp, string innerHash)
        {
            Height = height;
            Id = id;
            Hash = hash;
            InnerHash = innerHash;
            TimeStamp = timeStamp;
        }

        /// <summary>
        /// Creates a new multisig instance of TransactionInfo.
        /// </summary>
        /// <param name="height">The height.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="hash">The hash.</param>
        /// <param name="timeStamp">The time stamp.</param>
        /// <param name="innerHash">The inner hash.</param>
        /// <returns>TransactionInfo.</returns>
        public static TransactionInfo CreateMultisig(ulong height, int id, string hash, int timeStamp, string innerHash)
        {
            return new TransactionInfo(height, id, hash, timeStamp, innerHash);
        }

        /// <summary>
        /// Creates a new instance of TransactionInfo.
        /// </summary>
        /// <param name="height">The height.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="hash">The hash.</param>
        /// <param name="timeStamp">The time stamp.</param>
        /// <returns>TransactionInfo.</returns>
        public static TransactionInfo Create(ulong height, int id, string hash, int timeStamp)
        {
            return new TransactionInfo(height, id, hash, timeStamp, null);
        }
    }
}
