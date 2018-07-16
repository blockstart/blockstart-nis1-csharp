namespace io.nem1.sdk.Model.Node
{
    /// <summary>
    /// Class NisInfo.
    /// </summary>
    public class NisInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NisInfo"/> class.
        /// </summary>
        /// <param name="currentTime">The current time.</param>
        /// <param name="application">The application.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="version">The version.</param>
        /// <param name="signer">The signer.</param>
        public NisInfo(ulong currentTime, string application, ulong startTime, string version, string signer)
        {
            CurrentTime = currentTime;
            Application = application;
            StartTime = startTime;
            Version = version;
            Signer = signer;
        }

        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <value>The current time.</value>
        public ulong CurrentTime { get; }
        /// <summary>
        /// Gets the application.
        /// </summary>
        /// <value>The application.</value>
        public string Application { get; }
        /// <summary>
        /// Gets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public ulong StartTime { get; }
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        public string Version { get; }
        /// <summary>
        /// Gets the signer.
        /// </summary>
        /// <value>The signer.</value>
        public string Signer { get; }
    }
}
