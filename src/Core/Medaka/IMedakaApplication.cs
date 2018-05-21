using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Medaka
{
    /// <summary>
    /// This interface is used to add the information to an application class
    /// </summary>
    public interface IMedakaApplication
    {
        /// <summary>
        /// Gets the application directory.
        /// </summary>
        /// <value>
        /// The application directory.
        /// </value>
        DirectoryInfo AppDirectory { get; }
        /// <summary>
        /// Gets the configuration file.
        /// </summary>
        /// <value>
        /// The configuration file.
        /// </value>
        FileInfo ConfigurationFile { get; }
        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        /// <value>
        /// The application version.
        /// </value>
        String AppVersion { get; set; }
        /// <summary>
        /// Gets or sets the last access date.
        /// </summary>
        /// <value>
        /// The last access date.
        /// </value>
        DateTime Last_Access { get; set; }
    }
}
