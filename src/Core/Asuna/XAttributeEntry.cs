using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Asuna
{
    /// <summary>
    /// This structs defines the basics of the XAttribute a key and a value
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.INameless" />
    public struct XAttributeEntry : INameless
    {
        /// <summary>
        /// Creates the Nameless data exception
        /// </summary>
        NamelessObject _Nameless;
        /// <summary>
        /// The attribute name
        /// </summary>
        public String AttributeName;
        /// <summary>
        /// The attribute value
        /// </summary>
        public String AttributeValue;
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
        /// Initializes a new instance of the <see cref="XAttributeEntry"/> struct.
        /// </summary>
        /// <param name="attName">Name of the attribte.</param>
        /// <param name="attValue">The attribute value.</param>
        public XAttributeEntry(String attName, Object attValue = null)
        {
            this.AttributeName = attName;
            if (attValue != null)
                this.AttributeValue = attValue.ToString();
            else
                this.AttributeValue = String.Empty;
            _Nameless = new NamelessObject(typeof(XAttributeEntry));
        }
    }
}