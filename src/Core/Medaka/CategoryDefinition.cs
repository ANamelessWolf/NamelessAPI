using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Medaka
{
    /// <summary>
    /// Creates a category definition
    /// </summary>
    public struct CategoryDefinition : INameless
    {
        /// <summary>
        /// Creates the Nameless data exception
        /// </summary>
        NamelessObject _Nameless;
        /// <summary>
        /// The category name
        /// </summary>
        public string CategoryName;
        /// <summary>
        /// The properties names asigned with a default value
        /// </summary>
        public KeyValuePair<String, String>[] Properties;
        /// <summary>
        /// Gets the nameless object definition.
        /// </summary>
        /// <value>
        /// The nameless object definition.
        /// </value>
        public NamelessObject Nameless
        {
            get
            {
                if (this._Nameless == null)
                    this._Nameless = new NamelessObject(typeof(CategoryDefinition));
                return this._Nameless;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDefinition"/> struct.
        /// </summary>
        /// <param name="categoryName">The name of the category</param>
        /// <param name="properties">The category properties.</param>
        public CategoryDefinition(string categoryName, params KeyValuePair<String, String>[] properties)
        {
            this._Nameless = new NamelessObject(typeof(CategoryDefinition));
            this.CategoryName = categoryName;
            this.Properties = properties;
        }
    }
}