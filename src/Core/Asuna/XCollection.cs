using Nameless.Libraries.Yggdrasil.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
namespace Nameless.Libraries.Yggdrasil.Asuna
{
    /// <summary>
    /// Defines a collection of XElements that has the same node name
    /// </summary>
    /// <typeparam name="T">The type of XData</typeparam>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Asuna.XData" />
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Asuna.INerveGearXml" />
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public abstract class XCollection<T> : XData, INerveGearXml, IEnumerable<T> where T : XCommoner
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
        /// Gets the total numbre of XElement child count.
        /// </summary>
        /// <value>
        /// The child count.
        /// </value>
        public override int Count
        {
            get
            {
                return this.Data.Elements().Count(x => x.Name.ToString() == this.NodeName);
            }
        }
        /// <summary>
        /// Gets the <see cref="T"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>The Element at the given index</returns>
        /// <exception cref="IndexOutOfRangeException">An Exception is thrown when the element is not in range</exception>
        public T this[int index]
        {
            get
            {
                var nodes = this.Data.Elements().Where(x => x.Name.ToString() == this.NodeName);
                if (index < nodes.Count())
                {
                    var node = nodes.ElementAt(index);
                    return (T)Activator.CreateInstance(typeof(T), node);
                }
                else
                    throw new IndexOutOfRangeException();
            }
        }
        /// <summary>
        /// Gets or sets the attribute <see cref="String"/> with the specified index.
        /// </summary>
        /// <value>
        /// The attribute value as <see cref="String"/>.
        /// </value>
        /// <param name="index">The element index.</param>
        /// <param name="attName">Name of the attribute.</param>
        /// <returns>The attribute value</returns>
        public String this[int index, string attName]
        {
            get
            {
                try
                {
                    return this[index].GetAttribute(attName) as String;
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
                    this[index].SetAttribute(attName, value);
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="XCollection"/> class.
        /// </summary>
        /// <param name="node">The xml node.</param>
        /// <param name="parent">The XData parent.</param>
        public XCollection(String attKeyName, XElement node) : base(node)
        {

        }
        /// <summary>
        /// Adds a new item to the XCollection
        /// </summary>
        /// <param name="node">The xml node to add.</param>
        public virtual T Add(XElement node)
        {
            this.Data.Add(node);
            return (T)Activator.CreateInstance(typeof(T), node);
        }
        /// <summary>
        /// Removes an Xcommoner from the collection
        /// </summary>
        /// <param name="index">The index of the item to be removed</param>
        /// <returns>True if the item is removed</returns>
        /// <exception cref="TitaniaException">An exception occurred if the node doesn't had the attribute key name.</exception>
        public bool RemoveAt(int index)
        {
            Boolean flag = false;
            try
            {
                this[index].Delete();
                flag = true;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return flag;
        }
        /// <summary>
        /// Get the XCollection enumerator
        /// </summary>
        /// <returns>The Xcommoner enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var nodes = this.Data.Elements().Where(x => x.Name.ToString() == this.NodeName);
            return nodes.Select(x => (T)Activator.CreateInstance(typeof(T), x)).GetEnumerator();
        }
        /// <summary>
        /// Get the XCollection enumerator
        /// </summary>
        /// <returns>The Xcommoner enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            var nodes = this.Data.Elements().Where(x => x.Name.ToString() == this.NodeName);
            return nodes.GetEnumerator();
        }
        /// <summary>
        /// Initializes the attributes.
        /// </summary>
        void INerveGearXml.InitAttributes()
        {
            this.DefineAttributes();
        }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format(STR_XCOLLECTION, this.GetType().Name, this.Count);
        }
    }
}