using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Nameless.Libraries.Yggdrasil.Asuna
{
    /// <summary>
    /// This class extends the XData and the XElement functionality.
    /// </summary>
    public static partial class SAOUUtils
    {
        /// <summary>
        /// Set the name of the attribute
        /// </summary>
        /// <param name="node">The XElement node</param>
        /// <param name="attName">The name of the attribute to set its value</param>
        /// <param name="value">The attribute value</param>
        public static void SetAttribute(this XElement node, string attName, string value)
        {
            if (node.Attribute(attName) == null)
                node.Add(new XAttribute(attName, value));
            else
                node.Attribute(attName).Value = value;
        }
        /// <summary>
        /// Get the attribute by name
        /// </summary>
        /// <param name="node">The XElement node</param>
        /// <param name="attName">The name of the attribute</param>
        /// <param name="defaultValue">The return default value</param>
        /// <returns>The default value</returns>
        public static String GetAttribute(this XElement node, string attName, String defaultValue = "")
        {
            String value;
            if (node.Attribute(attName) == null)
                value = defaultValue;
            else
                value = node.Attribute(attName).Value;
            return value;
        }
        /// <summary>
        /// Check if the attributes exists.
        /// </summary>
        /// <param name="node">The XElement node</param>
        /// <param name="attName">The name of the attribute</param>
        /// <returns>True if the attribute exist otherwise false</returns>
        public static Boolean AttributeExist(this XElement node, String attName)
        {
            return node.Attributes().FirstOrDefault(x => x.Name == attName) != null;
        }
        /// <summary>
        /// Check if the node exists.
        /// </summary>
        /// <param name="node">The XElement node</param>
        /// <param name="nodeName">The node name</param>
        /// <returns>True if the node exist otherwise false</returns>
        public static Boolean NodeExist(this XElement node, String nodeName)
        {
            return node.Elements().FirstOrDefault(x => x.Name == nodeName) != null;
        }
        /// <summary>
        /// Checks if the XElement has nodes.
        /// </summary>
        /// <param name="node">The XElement node</param>
        /// <returns>True if has nodes</returns>
        public static Boolean HasNodes(this XElement node)
        {
            return node.Elements().Count() > 0;
        }
        /// <summary>
        /// Gets the attribute keys from the XElement node.
        /// </summary>
        /// <param name="node">The XElement node.</param>
        /// <returns>The attribute keys</returns>
        public static IEnumerable<String> GetAttributeKeys(this XElement node)
        {
            return node.HasAttributes ? node.Attributes().Select(x => x.Name.ToString()) : new String[0];
        }
        /// <summary>
        /// Get the XElement attribute.
        /// </summary>
        /// <param name="node">The XElement node.</param>
        /// <returns>The attribute keys.</returns>
        public static IEnumerable<KeyValuePair<String, Object>> GetAttributes(this XElement node)
        {
            return node.HasAttributes ?
                node.Attributes().Select(x => new KeyValuePair<String, Object>(x.Name.ToString(), x.Value)) :
                new KeyValuePair<String, Object>[0];
        }
        /// <summary>
        /// Get the XElement nodes.
        /// </summary>
        /// <param name="node">The XElement node.</param>
        /// <returns>The attribute keys.</returns>
        public static IEnumerable<XData> GetChildren(this XElement node)
        {
            return node.HasElements ? node.Elements().Select(x => new XData(x)) : new XData[0];
        }
        /// <summary>
        /// Create a copy of the xml node recursively.
        /// </summary>
        /// <param name="expXml">The XElement node where the data is going to be exported.</param>
        /// <param name="srcXml">The XElement node source data.</param>
        public static void Copy(this XElement expXml, XElement srcXml)
        {
            XElement node;
            XAttribute att;
            foreach (XElement e in srcXml.Elements().ToArray())
            {
                node = new XElement(e.Name);
                foreach (XAttribute a in e.Attributes().ToArray())
                {
                    att = new XAttribute(a.Name, a.Value);
                    node.Add(att);
                }
                expXml.Add(node);
                Copy(node, e);
            }
        }

        /// <summary>
        /// Initializes the attributes.
        /// </summary>
        internal static void DefineAttributes(this INerveGearXml iNervGearXml)
        {
            for (int i = 0; i < iNervGearXml.AttributeEntries.Length; i++)
                if (iNervGearXml.Content.Data.AttributeExist(iNervGearXml.AttributeEntries[i].AttributeName))
                    iNervGearXml.Content.AddAttribute(iNervGearXml.AttributeEntries[i].AttributeName, iNervGearXml.AttributeEntries[i].AttributeValue);
        }
    }
}
