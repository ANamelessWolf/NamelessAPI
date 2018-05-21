namespace Nameless.Libraries.Yggdrasil.Exceptions
{
    /// <summary>
    /// This class manage the Frau Threading and Client Server Exceptions
    /// Kō Kimijima (君島 コウ) is the author of the Kimijima Reports and the main antagonist of the Robotic Notes series. 
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Exceptions.NamelessException" />
    public class KoKimijamaException : NamelessException
    {
        #region Constructores
        /// <summary>
        /// Initializes a new instance of the <see cref="KoKimijamaException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public KoKimijamaException(string msg)
            : base(msg) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="KoKimijamaException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        public KoKimijamaException(string msg, System.Exception innerException)
            : base(msg, innerException) { }
        #endregion
    }
}
