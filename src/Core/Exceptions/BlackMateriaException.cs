namespace Nameless.Libraries.Yggdrasil.Exceptions
{
    /// <summary>
    /// BlackMateriaException are the exception found in Aerith (File management). 
    /// Black Materia was the materia used to summon doomsday magic in Final Fantasy VII, 
    /// Aerith with holy stops the meteor.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Exceptions.NamelessException" />
    public class BlackMateriaException : NamelessException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlackMateriaException"/> class.
        /// </summary>
        /// <param name="msg">Specify the text for the current exception</param>
        public BlackMateriaException(string msg)
            : base(msg) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BlackMateriaException"/> class.
        /// </summary>
        /// <param name="msg">Specify the text for the current exception</param>
        /// <param name="innerException">Specify the Inner Exception for this exception</param>
        public BlackMateriaException(string msg, System.Exception innerException)
            : base(msg, innerException) { }
    }
}
