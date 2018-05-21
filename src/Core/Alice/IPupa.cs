using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Alice
{
    /// <summary>
    /// Implements the basic cryptographic parameters.
    /// </summary>
    public interface IPupa
    {
        /// <summary>
        /// Gets the encryption key.
        /// </summary>
        /// <value>
        /// The encryption key values.
        /// </value>
        byte[] Key { get; }
        /// <summary>
        /// Gets the encryption vector.
        /// </summary>
        /// <value>
        /// The encryption vector values.
        /// </value>
        byte[] IV { get; }
        /// <summary>
        /// Gets or sets the key string.
        /// </summary>
        /// <value>
        /// The key string.
        /// </value>
        String KeyString { get; set; }
        /// <summary>
        /// Gets or sets the vector string.
        /// </summary>
        /// <value>
        /// The vector string.
        /// </value>
        String IVString { get; set; }
        /// <summary>
        /// Encrypts the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>The string encrypted</returns>
        String Encrypt(String str);
        /// <summary>
        /// Decrypts the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>The string decrypted</returns>
        String Decrypt(String str);
    }
}
