using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Morrigan
{
    /// <summary>
    /// Defines a row-specific property that apply to the Table structure. 
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.DataDefinition" />
    public class Row : DataTableDefinition
    {
        /// <summary>
        /// Defines a method to get the asociated data to this column
        /// </summary>
        /// <returns>The asociated data to this column</returns>
        protected override IEnumerable<Cell> GetAsociatedData()
        {
            return this.Table.Data.Where(x => x.RowIndex == this.Index);
        }
        /// <summary>
        /// Print the row description
        /// </summary>
        /// <returns>The row description as string</returns>
        public override string ToString()
        {
            return String.Format("R: {0}, Count: {1}", this.Index, this.Data.Count());
        }

    }
}
