using io.nem1.sdk.Core.Crypto;
using io.nem1.sdk.Core.Crypto.Chaso.NaCl;
using io.nem1.sdk.Core.Utils;

namespace io.nem1.sdk.Model.Wallet
{
    /// <summary>
    /// EncryptedPrivateKey.
    /// </summary>
    public class EncryptedPrivateKey
    {
        /// <summary>
        /// Gets the encrypted key.
        /// </summary>
        /// <value>The encrypted key.</value>
        public string EncryptedKey { get; }

        /// <summary>
        /// Gets the iv.
        /// </summary>
        /// <value>The iv.</value>
        public string Iv { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedPrivateKey"/> class.
        /// </summary>
        /// <param name="ivAndCipher">The iv and cipher.</param>
        public EncryptedPrivateKey(string ivAndCipher)
        {
            Iv = ivAndCipher.FromHex().Take(0, 16).ToHexLower();

            EncryptedKey = ivAndCipher.FromHex().Take(16, ivAndCipher.FromHex().Length - 16).ToHexLower();
        }

        /// <summary>
        /// Decrypts the encrypted key using a specified password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>System.String.</returns>
        public string Decrypt(Password password)
        {
            return CryptoUtils.PasswordToPrivateKey(password.Value, EncryptedKey.FromHex(), Iv.FromHex(), "pass:bip32");
        }
    }
}
