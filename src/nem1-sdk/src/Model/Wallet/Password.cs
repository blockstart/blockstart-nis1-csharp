using System;

namespace io.nem1.sdk.Model.Wallet
{
    /// <summary>
    /// Password.
    /// </summary>
    public class Password
    {
        /// <summary>
        /// Gets the password value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Password"/> class.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <exception cref="Exception">Password must be at least 8 characters</exception>
        public Password(string password)
        {
            if (password.Length < 8) throw new Exception("Password must be at least 8 characters");
            Value = password;
        }
    }
}
