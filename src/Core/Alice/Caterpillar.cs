using Nameless.Libraries.Yggdrasil.Exceptions;
using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.IO;
using System.Security.Cryptography;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
namespace Nameless.Libraries.Yggdrasil.Alice
{
    /// <summary>
    /// This class defines a new caterpillar. A caterpillar can encrypt and decrypt strings.
    /// The encryptions is composed by a Key and a Vector.
    /// </summary>
    public class Caterpillar : NamelessObject
    {
        /// <summary>
        /// The encryption key
        /// </summary>
        byte[] Key;
        /// <summary>
        /// The encription Vector
        /// </summary>
        byte[] IV;
        /// <summary>
        /// Initializes a new instance of the <see cref="Caterpillar"/> class.
        /// </summary>
        /// <param name="key">The key to encrypt or decrypt.</param>
        /// <param name="vector">The vector to decrypt or encrypt.</param>
        public Caterpillar(byte[] key, byte[] vector)
        {
            //1: Guardamos las propiedades del Caterpillar
            Key = key;
            IV = vector;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Caterpillar"/> class.
        /// </summary>
        /// <param name="key">The key to encrypt or decrypt.</param>
        /// <param name="vector">The vector to decrypt or encrypt.</param>
        public Caterpillar(string key, string vector) :
            this(key.GetBytes(), vector.GetBytes())
        {
        }
        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="originalString">The string to be encrypted</param>
        /// <returns>The string encrypted.</returns>
        public string Encrypt(string originalString)
        {
            try
            {
                if (originalString != null && originalString != String.Empty)
                {
                    MemoryStream memoryStream;
                    CryptoStream cryptoStream = this.Key.CreateCryptoStream(this.IV, out memoryStream, null, CryptoStreamMode.Write);
                    cryptoStream.Write(originalString);
                    return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
                }
                else
                    throw (new RedQueenException(ERR_ENCRYPTION_EMPTY_STR));
            }
            catch (System.Exception exc)
            {
                throw exc.CreateNamelessException<RedQueenException>(ERR_ENCRYPTING_STR);
            }
        }
        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="cryptedString">The string to be decrypted</param>
        /// <returns>The original string.</returns>
        public string Decrypt(string cryptedString)
        {
            try
            {
                if (cryptedString != null && cryptedString != String.Empty)
                {
                    MemoryStream memoryStream;
                    CryptoStream cryptoStream = this.Key.CreateCryptoStream(this.IV, out memoryStream, cryptedString, CryptoStreamMode.Read);
                    StreamReader reader = new StreamReader(cryptoStream);
                    return reader.ReadToEnd();
                }
                else
                    throw (new RedQueenException(ERR_ENCRYPTION_EMPTY_STR));
            }
            catch (System.Exception exc)
            {
                throw exc.CreateNamelessException<RedQueenException>(ERR_DECRYPTING_STR);
            }
        }
    }
}