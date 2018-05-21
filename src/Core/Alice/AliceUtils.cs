using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Nameless.Libraries.Yggdrasil.Alice
{
    /// <summary>
    /// This class extends the cryptography  actions
    /// </summary>
    public static partial class AliceUtils
    {
        /// <summary>
        /// Gets the bytes from a word.
        /// </summary>
        /// <param name="word">The string to get its bytes.</param>
        /// <returns>The word in bytes</returns>
        public static byte[] GetBytes(this String word)
        {
            return Encoding.ASCII.GetBytes(word);
        }
        /// <summary>
        /// Creates a stream that links data streams to cryptographic transformations.
        /// </summary>
        /// <param name="key">The encryption key.</param>
        /// <param name="vector">The encryption vector.</param>
        /// <param name="memoryStream">The stream whose backing store is memory.</param>
        /// <param name="mode">The encryption mode</param>
        /// <returns>The crypto stream</returns>
        public static CryptoStream CreateCryptoStream(this byte[] key, byte[] vector, out MemoryStream memoryStream,
            String originalString = null,
            CryptoStreamMode mode = CryptoStreamMode.Read)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            cryptoProvider.Mode = CipherMode.ECB;
            if (originalString != null)
                memoryStream = new MemoryStream(Convert.FromBase64String(originalString));
            else
                memoryStream = new MemoryStream();
            CryptoStream cryptoStream;
            if (mode == CryptoStreamMode.Write)
                cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(key, vector), mode);
            else
                cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(key, vector), mode);
            return cryptoStream;
        }
        /// <summary>
        /// Writes the specified word into the encryption stream.
        /// </summary>
        /// <param name="stream">The encryption stream.</param>
        /// <param name="word">The word to encrypt.</param>
        public static void Write(this CryptoStream stream, String word)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(word);
            writer.Flush();
            stream.FlushFinalBlock();
            writer.Flush();
        }
    }
}