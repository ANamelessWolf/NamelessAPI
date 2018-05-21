using System;
using System.Xml.Linq;

namespace Nameless.Libraries.Yggdrasil.Asuna
{
    /// <summary>
    /// This class represents an Xml element with a common name in the parent node. 
    /// And manage the access to the <seealso cref="XElement "/> See Class.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Asuna.XData" />
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Asuna.INerveGearXml" />
    public abstract class XCommoner : XData, INerveGearXml
    {
        /// <summary>
        /// Define the attribute entries for the XElement
        /// </summary>
        public abstract XAttributeEntry[] AttributeEntries { get; }
        /// <summary>
        /// Gets the name of the xml node.
        /// </summary>
        /// <value>
        /// The name of the  xml node.
        /// </value>
        public abstract String NodeName { get; }
        /// <summary>
        /// Gets Xml Data.
        /// </summary>
        /// <value>
        /// The xml data.
        /// </value>
        XData INerveGearXml.Content { get { return this; } }
        /// <summary>
        /// Initializes a new instance of the <see cref="XData"/> class.
        /// Creates a new XElement specifying the node name
        /// </summary>
        /// <param name="name">The XElement node name.</param>
        /// <param name="parent">The XData parent.</param>
        public XCommoner(String xName, XData parent)
            : base(xName, parent)
        {
            (this as INerveGearXml).InitAttributes();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="XCommoner"/> class.
        /// </summary>
        /// <param name="node">The XElement node.</param>
        public XCommoner(XElement node)
            : base(node)
        {
            (this as INerveGearXml).InitAttributes();
        }
        /// <summary>
        /// Initializes the attributes.
        /// </summary>
        void INerveGearXml.InitAttributes()
        {
            this.DefineAttributes();
        }
    }
}