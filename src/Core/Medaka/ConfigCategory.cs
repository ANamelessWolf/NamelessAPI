using Nameless.Libraries.Yggdrasil.Asuna;
using System;
using System.Xml.Linq;
using static Nameless.Libraries.Yggdrasil.Assets.Strings;
namespace Nameless.Libraries.Yggdrasil.Medaka
{
    /// <summary>
    /// Defines a Medaka Configuration Category
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Asuna.XUniqueCollection" />
    public class ConfigCategory : XUniqueCollection
    {
        /// <summary>
        /// Gets or sets the a property <see cref="System.String"/> with the specified property name.
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
                return this[propertyName, ATT_NAME_VALUE];
            }
            set
            {
                this[propertyName, ATT_NAME_VALUE] = value;
            }
        }
        /// <summary>
        /// The Configuration manager
        /// </summary>
        public ConfigMedaka Owner;
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigCategory"/> class.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <param name="appNode">The application node.</param>
        public ConfigCategory(String categoryName, XUniqueCollection appNode) :
            base(OpenCategoryNode(appNode, categoryName))
        {
        }
        /// <summary>
        /// Adds a new property to the current configuration category
        /// </summary>
        /// <param name="propertyName">The name of the property</param>
        /// <param name="value">The property value</param>
        public void Add(string propertyName, string value = "")
        {
            if (!this.Contains(propertyName))
                base.Add(propertyName.CreateProperty(value));
        }
        /// <summary>
        /// Helps to open the category node. If the category node does not exists is created
        /// under the application node.
        /// </summary>
        /// <param name="appNode">The application node</param>
        /// <param name="categoryName">The name of the category</param>
        /// <returns>The category node XElement</returns>
        private static XElement OpenCategoryNode(XUniqueCollection appNode, string categoryName)
        {
            XElement cat_node;
            //Si no existe se crea
            if (appNode.Data.Element(categoryName) == null)
            {
                cat_node = new XElement(categoryName);
                appNode.Data.Add(cat_node);
            }
            else
                cat_node = appNode.Data.Element(categoryName);
            return cat_node;
        }
    }
}
