using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using io.nem1.sdk.Core.Crypto.Chaso.NaCl;
using io.nem1.sdk.Core.Utils;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Security;

namespace io.nem1.sdk.Core.Crypto
{

    internal static class CryptoUtils
    {
        internal static string PasswordToPrivateKey(string password, byte[] cipherText, byte[] iv, string algo)
        {
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("missing argument");
            if (String.IsNullOrEmpty(algo)) throw new ArgumentException("missing argument");
            if (cipherText == null) throw new ArgumentException("missing argument");
            if (iv == null) throw new ArgumentException("missing argument");

            if (algo == "pass:bip32")
            { // Wallets from PRNG
                return DecodePrivateKey(password, iv, cipherText);
            }
            throw new Exception("invalid algo");

        }

        internal static string ToMobileKey(string password, string privateKey)
        {
            var random = new SecureRandom();

            var salt = new byte[256 / 8];
            random.NextBytes(salt);

            var maker = new Rfc2898DeriveBytes(password, salt, 2000);
            var key = maker.GetBytes(256 / 8);
           
            var ivData = new byte[16];
            random.NextBytes(ivData);

            return salt.ToHexLower() + AesEncryptor(key, ivData, privateKey.FromHex()).ToHexLower();
        }

        internal static string FromMobileKey(string payload, string password)
        {
            var salt = payload.FromHex().Take(32).ToArray();
            var iv = payload.FromHex().Take(32, 16);
            var cypher = payload.FromHex().Take(48, payload.FromHex().Length - 48);

            var maker = new Rfc2898DeriveBytes(password, salt, 2000);
            var key = maker.GetBytes(256 / 8);

            return AesDecryptor(key, iv, cypher).ToHexLower();

        }

        #region Asymetric Encoding

        internal static string AsymetricEncode(string text, string secretKey, string publicKey)
        {
            var random = new SecureRandom();

            var salt = new byte[32];
            random.NextBytes(salt);

            var ivData = new byte[16];
            random.NextBytes(ivData);

            return _Encode(
                secretKey.FromHex(),
                publicKey.FromHex(),
                text,
                ivData,
                salt);
        }

        internal static string AsymetricDecode(string text, string secretKey, string publicKey)
        {
            return _Decode(
                secretKey.FromHex(),
                publicKey.FromHex(),
                text.FromHex());
        }

        internal static string _Encode(byte[] privateKey, byte[] publicKey, string payload, byte[] iv, byte[] salt)
        {
            var shared = new byte[32];

            Ed25519.key_derive(
                shared,
                salt,
                privateKey,
                publicKey);

            return salt.ToHexLower() + AesEncryptor(shared, iv, Encoding.UTF8.GetBytes(payload)).ToHexLower();
        }

        internal static string _Decode(byte[] privateKey, byte[] publicKey, byte[] data)
        {
            var salt = data.Take(0, 32).ToArray();
            var iv = data.Take(32, 16);
            var payload = data.Take(48, data.Length - 48);
            var shared = new byte[32];

            Ed25519.key_derive(
                shared,
                salt,
                privateKey,
                publicKey);

            return Encoding.UTF8.GetString(AesDecryptor(shared, iv, payload));
        }

        #endregion


        #region Wallet Encryption

        internal static string Encrypt(string data, string privateKey)
        {
            var random = new SecureRandom();

            var ivData = new byte[16];
            random.NextBytes(ivData);

            return AesEncryptor(privateKey.FromHex(), ivData, data.FromHex()).ToHexLower();
        }

        internal static string EncodePrivateKey(string privateKey, string password)
        {
            var pass = DerivePassSha(password, 20);

            return Encrypt(privateKey, pass.ToHexLower());
        }

        internal static string DecodePrivateKey(string password, byte[] iv, byte[] cipherText)
        {
            var pass = DerivePassSha(password, 20);

            var decrypted = AesDecryptor(pass, iv, cipherText);

            return decrypted.ToHexLower();
        }

        internal static byte[] DerivePassSha(string password, int count)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if(count <= 0) throw new ArgumentOutOfRangeException(nameof(count), "must be positive");

            var sha3Hasher = new KeccakDigest(256);
            var priv = new byte[32];


            sha3Hasher.BlockUpdate(Encoding.UTF8.GetBytes(password), 0, password.Length);
            sha3Hasher.DoFinal(priv, 0);

            for (var i = 0; i < count - 1; ++i)
            {
                sha3Hasher.Reset();
                sha3Hasher.BlockUpdate(priv, 0, priv.Length);
                sha3Hasher.DoFinal(priv, 0);
            }

            return priv;
        }

        #endregion

        internal static byte[] AesEncryptor(byte[] key, byte[] iv, byte[] payload)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.CBC;

                aesAlg.Padding = PaddingMode.PKCS7;

                var encryptor = aesAlg.CreateEncryptor(key, iv);

                var encrypted = encryptor.TransformFinalBlock(payload, 0, payload.Length);

                return iv.Concat(encrypted).ToArray();
            }
        }
        

        internal static byte[] AesDecryptor(byte[] key, byte[] iv, byte[] payload)
        {
            using (var aesAlg = Aes.Create())
            {               
                aesAlg.Mode = CipherMode.CBC;

                aesAlg.Padding = PaddingMode.PKCS7;

                var decryptor = aesAlg.CreateDecryptor(key, iv);

                return decryptor.TransformFinalBlock(payload, 0, payload.Length);
            }
        }
    }
}
