using io.nem1.sdk.Model.Accounts;

namespace io.nem1.sdk.Model.Namespace
{
    /// <summary>
    /// Class NamespaceRootInfo.
    /// </summary>
    /// <seealso cref="io.nem1.sdk.Model.Namespace.NamespaceInfo" />
    public class NamespaceRootInfo : NamespaceInfo
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceRootInfo"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fqn">The FQN.</param>
        /// <param name="height">The height.</param>
        /// <param name="owner">The owner.</param>
        public NamespaceRootInfo(int id, string fqn, ulong height, Address owner) : base(fqn, height, owner)
        {
            Id = id;
        }
    }
}
