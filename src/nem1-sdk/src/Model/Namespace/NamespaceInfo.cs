using io.nem1.sdk.Model.Accounts;

namespace io.nem1.sdk.Model.Namespace
{
    /// <summary>
    /// NamespaceInfo.
    /// </summary>
    public class NamespaceInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceInfo"/> class.
        /// </summary>
        /// <param name="fqn">The FQN.</param>
        /// <param name="height">The height.</param>
        /// <param name="owner">The owner.</param>
        public NamespaceInfo(string fqn, ulong height, Address owner)
        {
            Name = fqn;
            Height = height;
            Owner = owner;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; internal set; }
        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public ulong Height { get; internal set; }
        /// <summary>
        /// Gets the owner.
        /// </summary>
        /// <value>The owner.</value>
        public Address Owner { get; internal set; }
    }
}
