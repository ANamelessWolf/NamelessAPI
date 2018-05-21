using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Morrigan
{
    /// <summary>
    /// Defines the functionality required to support a shared-size group that is used by the 
    /// Column and Row classes.
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    public abstract class DataTableDefinition : NamelessObject
    {
        /// <summary>
        /// The table structure asociated to this definition
        /// </summary>
        public Table Table;
        /// <summary>
        /// The data table definition index
        /// </summary>
        public int Index;
        /// <summary>
        /// The data table definition name
        /// </summary>
        public String Name;
        /// <summary>
        /// Gets the next data table definition
        /// </summary>
        public DataTableDefinition Next;
        /// <summary>
        /// Gets the previous data table definition
        /// </summary>
        public DataTableDefinition Previous;
        /// <summary>
        /// The asociated data
        /// </summary>
        public IEnumerable<Cell> Data { get { return GetAsociatedData(); } }
        /// <summary>
        /// Defines a method to get the asociated data
        /// </summary>
        protected abstract IEnumerable<Cell> GetAsociatedData();
    }
}
