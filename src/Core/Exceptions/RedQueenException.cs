using System.Security.Cryptography;

namespace Nameless.Libraries.Yggdrasil.Exceptions
{
    /// <summary>
    /// RedQueenException are the exception found in Alice (Cryptography).
    /// The red queen or the queen of hearts is the evilness in wonderland, so if something goes wrong the Queen must be responsible.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Exceptions.NamelessException" />
    public class RedQueenException : NamelessException
    {
        #region Constructores
        /// <summary>
        /// Initializes a new instance of the <see cref="RedQueenException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public RedQueenException(string msg)
            : base(msg) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RedQueenException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="cryptoExc">The crypto exc.</param>
        public RedQueenException(string msg, CryptographicException cryptoExc)
            : base(msg, cryptoExc) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RedQueenException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        public RedQueenException(string msg, System.Exception innerException)
            : base(msg, innerException) { }
        #endregion
    }
}
