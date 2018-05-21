using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Lilith
{
    /// <summary>
    /// Implements an element of nameless object type
    /// </summary>
    public interface INameless
    {
        /// <summary>
        /// Gets the nameless Object.
        /// </summary>
        /// <value>
        /// The nameless.
        /// </value>
        NamelessObject Nameless { get; }
    }
}
