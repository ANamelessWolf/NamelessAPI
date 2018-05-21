using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Nameless.Libraries.Yggdrasil.Asuna
{
    /// <summary>
    /// This interface imnplements minimum functionality of SAO Xml Nodes
    /// </summary>
    public interface INerveGearXml
    {
        /// <summary>
        /// Define the attribute entries for the XElement
        /// </summary>
        XAttributeEntry[] AttributeEntries { get; }
        /// <summary>
        /// Gets the name of the node.
        /// </summary>
        /// <value>
        /// The name of the node.
        /// </value>
        String NodeName { get; }
        /// <summary>
        /// Gets the name of the node.
        /// </summary>
        /// <value>
        /// The name of the node.
        /// </value>
        XData Content { get; }
        /// <summary>
        /// Initializes the attribute values
        /// </summary>
        void InitAttributes();
    }
}
