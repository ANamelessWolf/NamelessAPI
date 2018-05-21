using Nameless.Libraries.Yggdrasil.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
namespace Nameless.Libraries.Yggdrasil.Asuna
{
    /// <summary>
    /// This class defines an Xml node that has children with unique XElement node names.
    /// The XElement children can be acces by a unique string name
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Asuna.XData" />
    /// <seealso cref="System.Collections.Generic.IEnumerable{Nameless.Libraries.Yggdrasil.Asuna.XData}" />
    public abstract class XUniqueCollection : XData, IEnumerable<XData>
    {
        /// <summary>
        /// Gets the <see cref="XData"/> with the specified node name.
        /// </summary>
        /// <value>
        /// The <see cref="XData"/> asociated a key name.
        /// </value>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns>The given XData</returns>
        /// <exception cref="TitaniaException">An Exception is thrown when a children is not found by its name.</exception>
        public XData this[String nodeName]
        {
            get
            {
                var node = this.Data.Elements().FirstOrDefault(x => x.Name.ToString() == nodeName);
                if (node == null)
                    throw new TitaniaException(String.Format(ERR_XML_MISSING_NODE, nodeName, this.Data.Name));
                else
                    return new XData(node);
            }
        }
        /// <summary>
        /// Gets or sets the attribute with the specified node name.
        /// </summary>
        /// <value>
        /// The <see cref="String"/>.
        /// </value>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="attName">Name of the attribute.</param>
        /// <returns>The attribute value</returns>
        public String this[String nodeName, string attName]
        {
            get
            {
                try
                {
                    return this[nodeName].GetAttribute(attName) as String;
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
            set
            {
                try
                {
                    this[nodeName].SetAttribute(attName, value);
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="XUniqueCollection"/> class.
        /// </summary>
        /// <param name="node">The xml node.</param>
        public XUniqueCollection(XElement node)
            : base(node)
        {
            var nodes = node.Elements().GroupBy(
                x => x.Name.ToString(),
                x => x,
                (key, group) => new { k = key, g = group });
        }
        /// <summary>
        /// Adds the specified node.
        /// </summary>
        /// <param name="node">The XElement node to add.</param>
        /// <returns>The added XElement</returns>
        /// <exception cref="TitaniaException">An Exception is thrown if a node with the same node name is added.</exception>
        public virtual XData Add(XElement node)
        {
            if (!this.Contains(node.Name.ToString()))
            {
                this.Data.Add(node);
                return new XData(node);
            }
            else
                throw new TitaniaException(ERR_XML_NODE_NOT_UNIQUE);
        }
        /// <summary>
        /// Removes the specified node name.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns>True if the node is removed</returns>
        protected bool Remove(String nodeName)
        {
            Boolean flag = false;
            if (this.Contains(nodeName))
            {
                this.Data.Elements().FirstOrDefault(x => x.Name == nodeName).Remove();
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// Determines whether [contains] [the specified node].
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified node]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(string nodeName)
        {
            return this.Data.Elements().FirstOrDefault(x => x.Name.ToString() == nodeName) != null;
        }
        /// <summary>
        /// Get the XCollection enumerator
        /// </summary>
        /// <returns>The Xcommoner enumerator</returns>
        public IEnumerator<XData> GetEnumerator()
        {
            return this.Children.GetEnumerator();
        }
        /// <summary>
        /// Get the XCollection enumerator
        /// </summary>
        /// <returns>The Xcommoner enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Children.GetEnumerator();
        }
    }
}
