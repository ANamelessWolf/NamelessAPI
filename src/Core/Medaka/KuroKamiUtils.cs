using Nameless.Libraries.Yggdrasil.Asuna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
namespace Nameless.Libraries.Yggdrasil.Medaka
{
    public static class KuroKamiUtils
    {
        /// <summary>
        /// Creates a property XElement node.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The property default value.</param>
        /// <returns>The property XElement node.</returns>
        public static XElement CreateProperty(this String propertyName, String value)
        {
            XElement node = new XElement(propertyName);
            node.Add(new XAttribute(ATT_NAME_VALUE, value));
            return node;
        }
        /// <summary>
        /// Creates a category XElement node.
        /// </summary>
        /// <param name="category">The category XData.</param>
        /// <param name="config">The configuration category node.</param>
        /// <returns>The property XElement node.</returns>
        public static ConfigurationCategory CreateCategory(this XData category, ConfigurationMedaka config)
        {
            return new ConfigurationCategory(config, category);
        }
    }
}
