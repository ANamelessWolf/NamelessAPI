using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Exceptions
{
    /// <summary>
    /// NamelessException are the exceptions of nameless API
    /// </summary>
    public class NamelessException : System.Exception, INameless
    {
        /// <summary>
        /// Gets the nameless class definition.
        /// </summary>
        /// <value>
        /// The nameless object.
        /// </value>
        public NamelessObject Nameless
        {
            get { return this._Nameless; }
        }
        /// <summary>
        /// Creates the Nameless data exception
        /// </summary>
        NamelessObject _Nameless;
        #region Constructores
        /// <summary>
        /// Initializes a new instance of the <see cref="NamelessException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public NamelessException(string msg)
            : base(msg)
        {
            _Nameless = new NamelessObject(this.GetType());
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="NamelessException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        public NamelessException(string msg, System.Exception innerException)
            : base(msg, innerException)
        {
            _Nameless = new NamelessObject(this.GetType());
        }
        #endregion
    }
}
