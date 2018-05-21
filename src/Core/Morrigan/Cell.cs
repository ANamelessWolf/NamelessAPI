using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Morrigan
{
    /// <summary>
    /// This class represent a cell structure used on <seealso cref="Nameless.Libraries.Yggdrasil.Morrigan.Table"/>
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    public class Cell : NamelessObject
    {
        /// <summary>
        /// The table structure asociated to this definition
        /// </summary>
        public Table Table;
        /// <summary>
        /// The column index
        /// </summary>
        public int ColumnIndex;
        /// <summary>
        /// The row index
        /// </summary>
        public int RowIndex;
        /// <summary>
        /// The column span
        /// </summary>
        public int ColumnSpan;
        /// <summary>
        /// The row index
        /// </summary>
        public int RowSpan;
        /// <summary>
        /// Gets the row asociated to the cell.
        /// </summary>
        /// <value>
        /// The row.
        /// </value>
        public Row Row { get { return this.Table.Rows.FirstOrDefault(x => x.Index == this.RowIndex); } }
        /// <summary>
        /// Gets the column associated to the cell.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        public Column Column { get { return this.Table.Columns.FirstOrDefault(x => x.Index == this.ColumnIndex); } }
        /// <summary>
        /// The cell content data
        /// </summary>
        public Object Data;
    }
}
