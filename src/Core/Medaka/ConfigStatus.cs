using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Medaka
{
    /// <summary>
    /// This enumerator specifies the status for the current configuration file
    /// </summary>
    public enum ConfigStatus
    {
        /// <summary>
        /// The configuration file is created but is empty
        /// </summary>
        Empty = 1,
        /// <summary>
        /// The configuration file is an invalid xml file.
        /// </summary>
        Damage = 2,
        /// <summary>
        /// The configuration file is fine.
        /// </summary>
        Ok = 3
    }
}
