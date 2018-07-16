namespace io.nem1.sdk.Model.Transactions
{
    /// <summary>
    /// Class QueryParams.
    /// </summary>
    public class TransactionQueryParams
    {
        /// <summary>
        /// The hash of the transaction upto which transactions should be returned.
        /// </summary>
        private readonly string _hash;
        /// <summary>
        /// The database identifier upto which transactions should be returned.
        /// </summary>
        private readonly string _id;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionQueryParams"/> class.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <param name="id">The identifier.</param>
        public TransactionQueryParams(string hash = null, string id = null)
        {
            _hash = hash;
            _id = id;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <returns>String.</returns>
        public string GetId() { return _id; }

        /// <summary>
        /// Gets the size of the page.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string GetHash() { return _hash; }
    }
}
