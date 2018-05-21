using Nameless.Libraries.Yggdrasil.Asuna;
using Nameless.Libraries.Yggdrasil.Yuffie;
using System;
using System.Xml.Linq;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
using Nameless.Libraries.Yggdrasil.Lilith;
using Nameless.Libraries.Yggdrasil.Exceptions;

namespace Nameless.Libraries.Yggdrasil.Medaka
{
    /// <summary>
    /// A configuration category is collection of nodes (properties) with unique names that has a common
    /// parent the parent name is the category name.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Asuna.XUniqueCollection" />
    public class ConfigurationCategory : XUniqueCollection
    {
        /// <summary>
        /// The configuration file acts as parent for the category
        /// </summary>
        public new ConfigurationMedaka Parent;
        /// <summary>
        /// Gets or sets a property <see cref="System.String"/> with the specified name.
        /// </summary>
        /// <value>
        /// The property <see cref="System.String"/> value.
        /// </value>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>The property value</returns>
        public new string this[String propertyName]
        {
            get
            {
                if (base.Contains(propertyName))
                    return base[propertyName, ATT_NAME_VALUE];
                else
                    return null;
            }
            set
            {
                if (base.Contains(propertyName))
                    base[propertyName, ATT_NAME_VALUE] = value;
                else
                {
                    XElement newProperty = propertyName.CreateProperty(value);
                    var node = base.Add(newProperty);
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationCategory"/> class.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <param name="config">The medaka configuration file.</param>
        public ConfigurationCategory(ConfigurationMedaka config, String categoryName) :
            base(OpenCategory(config.MedakaApp, categoryName))
        {
            this.Parent = config;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationCategory"/> class.
        /// </summary>
        /// <param name="category">The category XElement.</param>
        /// <param name="config">The medaka configuration file.</param>
        public ConfigurationCategory(ConfigurationMedaka config, XData category) :
            base(category.Data)
        {
            this.Parent = config;
        }
        /// <summary>
        /// Adds a new property to the current configuration category
        /// </summary>
        /// <param name="propertyName">The name of the property</param>
        /// <param name="value">The property value</param>
        public void Add(string propertyName, string value = "")
        {
            try
            {
                base.Add(propertyName.CreateProperty(value));
            }
            catch (Exception exc)
            {
                throw exc.CreateNamelessException<GodModeException>(ERR_PROP_DUPLICATED, propertyName);
            }
        }
        /// <summary>
        /// Removes the property from the configuration category.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public new void Remove(string propertyName)
        {
            base.Remove(propertyName);
        }
        /// <summary>
        /// Helps to open the category node. If the category node does not exists is created
        /// under the application node.
        /// </summary>
        /// <param name="appNode">The application node</param>
        /// <param name="categoryName">The name of the category</param>
        /// <returns>The category node XElement</returns>
        private static XElement OpenCategory(XUniqueCollection appNode, string categoryName)
        {
            XElement cat_node;
            //Si no existe se crea
            if (!appNode.Contains(categoryName))
            {
                cat_node = new XElement(categoryName);
                appNode.Add(cat_node);
            }
            else
                cat_node = appNode.Data.Element(categoryName);
            return cat_node;
        }
    }
}