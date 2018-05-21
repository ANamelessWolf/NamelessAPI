namespace Nameless.Libraries.Yggdrasil.Exceptions
{
    /// <summary>
    /// GodModeException are the exception found in Medaka (Nameless Configuration File Manager).
    /// Medaka God Mode is not in controlled, her physical strength is greatly increase but his mind is damage in this state.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Exceptions.NamelessException" />
    public class GodModeException : NamelessException
    {
        #region Constructores
        /// <summary>
        /// Initializes a new instance of the <see cref="GodModeException"/> class.
        /// </summary>
        /// <param name="msg">Specify the text for the current exception</param>
        public GodModeException(string msg)
            : base(msg) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GodModeException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="xmlException">The XML exception.</param>
        public GodModeException(string msg, System.Xml.XmlException xmlException)
            : base(msg, xmlException) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GodModeException"/> class.
        /// </summary>
        /// <param name="msg">Specify the text for the current exception</param>
        /// <param name="innerException">Specify the Inner Exception for this exception</param>
        public GodModeException(string msg, System.Exception innerException)
            : base(msg, innerException) { }
        #endregion
    }
}
