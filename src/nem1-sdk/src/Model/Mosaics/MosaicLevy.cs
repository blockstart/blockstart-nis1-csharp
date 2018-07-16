using io.nem1.sdk.Model.Accounts;

namespace io.nem1.sdk.Model.Mosaics
{
    /// <summary>
    /// Class MosaicLevy.
    /// </summary>
    public class MosaicLevy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MosaicLevy"/> class.
        /// </summary>
        /// <param name="mosaic">The mosaic.</param>
        /// <param name="feeType">Type of the fee.</param>
        /// <param name="recipient">The recipient.</param>
        public MosaicLevy(Mosaic mosaic, int feeType, Address recipient)
        {
            Mosaic = mosaic;
            FeeType = feeType;
            LevyRecipient = recipient;
        }

        /// <summary>
        /// Gets the levy recipient.
        /// </summary>
        /// <value>The levy recipient.</value>
        public Address LevyRecipient { get; }
        /// <summary>
        /// Gets the mosaic.
        /// </summary>
        /// <value>The mosaic.</value>
        public Mosaic Mosaic { get; }
        /// <summary>
        /// Gets the type of the fee.
        /// </summary>
        /// <value>The type of the fee.</value>
        public int FeeType { get; }
    }
}
