namespace Nameless.Libraries.Yggdrasil.Exceptions
{
    /// <summary>
    /// TinaniaException are the exception found in Asuna (XML Manager).
    /// Titania was the avatar of Asuna during the world tree saga in Swor Art Online series
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Exceptions.NamelessException" />
    public class TitaniaException : NamelessException
    {
        #region Constructores
        /// <summary>
        /// Initializes a new instance of the <see cref="TitaniaException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public TitaniaException(string msg)
            : base(msg) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TitaniaException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="xmlException">The XML exception.</param>
        public TitaniaException(string msg, System.Xml.XmlException xmlException)
            : base(msg, xmlException) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TitaniaException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        public TitaniaException(string msg, System.Exception innerException)
            : base(msg, innerException) { }
        #endregion
    }
}
