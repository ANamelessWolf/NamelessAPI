using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Morrigan
{
    /// <summary>
    /// Defines a column-specific properties that apply to Table structure. 
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.DataDefinition" />
    public class Column : DataTableDefinition
    {

        /// <summary>
        /// Defines a method to get the asociated data to this column
        /// </summary>
        /// <returns>The asociated data to this column</returns>
        protected override IEnumerable<Cell> GetAsociatedData()
        {
            return this.Table.Data.Where(x => x.ColumnIndex == this.Index);
        }
        /// <summary>
        /// Print the column description
        /// </summary>
        /// <returns>The column description as string</returns>
        public override string ToString()
        {
            return String.Format("C: {0}, Name: {1}", this.Index, this.Name);
        }
    }
}
