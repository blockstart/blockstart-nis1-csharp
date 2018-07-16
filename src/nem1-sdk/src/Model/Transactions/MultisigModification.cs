using io.nem1.sdk.Model.Accounts;

namespace io.nem1.sdk.Model.Transactions
{
    /// <summary>
    /// Class MultisigModification.
    /// </summary>
    public class MultisigModification
    {
        /// <summary>
        /// Gets the cosignatory public key.
        /// </summary>
        /// <value>The cosignatory public key.</value>
        public PublicAccount CosignatoryPublicKey { get; }

        /// <summary>
        /// Gets the type of the modification.
        /// </summary>
        /// <value>The type of the modification.</value>
        public CosignatoryModificationType.Types ModificationType { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultisigModification"/> class.
        /// </summary>
        /// <param name="cosignatoryPublicKey">The cosignatory public key.</param>
        /// <param name="modificationType">Type of the modification.</param>
        public MultisigModification(PublicAccount cosignatoryPublicKey, CosignatoryModificationType.Types modificationType)
        {
            CosignatoryPublicKey = cosignatoryPublicKey;
            ModificationType = modificationType;
        }
    }
}
