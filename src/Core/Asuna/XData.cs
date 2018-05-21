using Nameless.Libraries.Yggdrasil.Aerith;
using Nameless.Libraries.Yggdrasil.Exceptions;
using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
namespace Nameless.Libraries.Yggdrasil.Asuna
{
    /// <summary>
    /// This class represents an Xml element. And manage the access to the <seealso cref="XElement "/> See Class.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    public class XData : NamelessObject
    {
        /// <summary>
        /// Access the Xml Data
        /// </summary>
        public readonly XElement Data;
        /// <summary>
        /// Gets the node parent.
        /// </summary>
        /// <value>
        /// The parent node.
        /// </value>
        public XData Parent { get { return IsRoot ? null : new XData(this.Data.Parent); } }
        /// <summary>
        /// Gets a value indicating whether this instance is root.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is root; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsRoot { get { return this.Data.Parent == null; } }
        /// <summary>
        /// Gets the XElement attribute keys.
        /// </summary>
        /// <value>
        /// The attribute keys.
        /// </value>
        public IEnumerable<String> AttributeKeys { get { return this.Data.GetAttributeKeys(); } }
        /// <summary>
        /// Gets the attributes asociated to the XElement.
        /// </summary>
        /// <value>
        /// The attribute as a Key Value pair.
        /// </value>
        public IEnumerable<KeyValuePair<String, Object>> Attributes { get { return this.Data.GetAttributes(); } }
        /// <summary>
        /// Gets the XElement children nodes as XData.
        /// </summary>
        /// <value>
        /// The XData children nodes.
        /// </value>
        public IEnumerable<XData> Children { get { return this.Data.GetChildren(); } }
        /// <summary>
        /// Gets the XElement node name.
        /// </summary>
        /// <value>
        /// The XElement node name as string.
        /// </value>
        public String Name { get { return this.Data.Name.ToString(); } }
        /// <summary>
        /// Gets or sets the value for the XElement.
        /// </summary>
        /// <value>
        /// The XElement value.
        /// </value>
        public String Value { get { return this.Data.Value; } set { this.Data.Value = value; } }
        /// <summary>
        /// Gets the XElement children count.
        /// </summary>
        /// <value>
        /// The chidren count.
        /// </value>
        public virtual int Count { get { return this.Data.Elements().Count(); } }
        /// <summary>
        /// Initializes a new instance of the <see cref="XData"/> class.
        /// </summary>
        /// <param name="node">The xml node.</param>
        public XData(XElement node)
        {
            this.Data = node;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="XData"/> class.
        /// Creates a new XElement specifying the XElement node name
        /// </summary>
        /// <param name="name">The XElement node name.</param>
        /// <param name="parent">The XElement parent node</param>
        public XData(String name, XData parent = null) :
            this(new XElement(name))
        {
            if (parent != null)
                parent.Data.Add(this.Data);
        }
        /// <summary>
        /// Sets the attribute.
        /// If the attribuye does not exist is created on the XElement
        /// </summary>
        /// <param name="attName">Name of the attribute.</param>
        /// <param name="value">The attribute value.</param>
        public void SetAttribute(string attName, string value)
        {
            this.Data.SetAttribute(attName, value);
        }
        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <param name="attName">Name of the attribute.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The attribute value if exists otherwise the default value</returns>
        public String GetAttribute(string attName, String defaultValue = null)
        {
            return this.Data.GetAttribute(attName);
        }
        /// <summary>
        /// Check if the XData has an specific attribute.
        /// The name is case sensitive
        /// </summary>
        /// <param name="attName">The name of the attribute</param>
        /// <returns>True if the attribute exist</returns>
        public Boolean HasAttribute(String attName)
        {
            return AttributeKeys.Contains(attName);
        }
        /// <summary>
        /// Adds a new attribute to the XData
        /// </summary>
        /// <param name="attName">The name of the attribute to add.</param>
        /// <param name="value">The attribute value.</param>
        /// <exception cref="TitaniaException">An exception might be thrown if the attribute exists on the node.</exception>
        public virtual void AddAttribute(String attName, String value = "")
        {
            if (!AttributeKeys.Contains(attName))
                this.Data.Add(new XAttribute(attName, value));
            else
                throw new TitaniaException(String.Format(ERR_XML_DUPLICATED_ATT, attName, this.Data.Name));
        }
        /// <summary>
        /// Removes an attribute by its name
        /// </summary>
        /// <param name="attName">The name of the attribute to remove</param>
        public virtual void RemoveAttribute(String attName)
        {
            if (AttributeKeys.Contains(attName))
                this.Data.Attributes(attName).Remove();
        }
        /// <summary>
        /// Adds a new child to the XData.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns>The added child</returns>
        public virtual XData AddChild(String nodeName)
        {
            return new XData(nodeName, this);
        }
        /// <summary>
        /// Gets the child from the current node
        /// </summary>
        /// <param name="nodeName">The node name.</param>
        /// <returns>The child as XData</returns>
        public virtual XData GetChild(String nodeName)
        {
            var element = this.Data.Element(nodeName);
            return new XData(element);
        }
        /// <summary>
        /// Exports the XData to a XML file.
        /// </summary>
        /// <param name="xmlFilePath">The xml file path.</param>
        /// <param name="root">Name of the root node.</param>
        /// <exception cref="TitaniaException">An exception might be thrown creating the file.</exception>
        public void Export(string xmlFilePath, String root)
        {
            try
            {
                //Creamos el archivo
                xmlFilePath.CreateFileFromPath(true);
                //Se crea el xml con la información del XData
                XNpc xml = new XNpc(root, new System.IO.FileInfo(xmlFilePath));
                XElement expXml = new XElement(this.Data.Name);
                expXml.Copy(this.Data);
                xml.Document.Root.Add(expXml);
                xml.Save();
            }
            catch (Exception exc)
            {
                throw exc.CreateNamelessException<TitaniaException>(ERR_XML_EXPORTING);
            }
        }
        /// <summary>
        /// Imports the data from a XElement to this XData
        /// </summary>
        /// <param name="xmlFilePath">The xml file path.</param>
        public void Import(string xmlFilePath)
        {
            if (!System.IO.File.Exists(xmlFilePath))
                throw new TitaniaException(String.Format(ERR_FILE_MISSING, xmlFilePath));
            else
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                XElement srcNode = doc.Elements().FirstOrDefault();
                if (srcNode != null)
                    this.Data.Copy(srcNode);
            }

        }
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void Delete()
        {
            this.Data.Remove();
        }
        /// <summary>
        /// Creates a string from this instance
        /// </summary>
        /// <returns>The xml string value</returns>
        public override string ToString()
        {
            return this.Data.ToString();
        }
    }
}