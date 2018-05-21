namespace Nameless.Libraries.Yggdrasil.Exceptions
{
    /// <summary>
    /// Proxies or Proxy is the name given to supernaturally powerful creatures made by the original humans 
    /// (who are referred to by the Proxies as "The Creator" or "The Creators") before they left the planet for space.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Exceptions.NamelessException" />
    public class ErgoProxyException : NamelessException
    {
        #region Constructores
        /// <summary>
        /// Initializes a new instance of the <see cref="ErgoProxyException"/> class.
        /// </summary>
        /// <param name="msg">Specify the text for the current exception</param>
        public ErgoProxyException(string msg)
            : base(msg) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ErgoProxyException"/> class.
        /// </summary>
        /// <param name="msg">Specify the text for the current exception</param>
        /// <param name="innerException">Specify the Inner Exception for this exception</param>
        public ErgoProxyException(string msg, System.Exception innerException)
            : base(msg, innerException) { }
        #endregion
    }
}
