using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nameless.Libraries.Yggdrasil.Morrigan
{
    /// <summary>
    /// Defines a structure of table type
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    public class Table : NamelessObject
    {
        /// <summary>
        /// The table name
        /// </summary>
        public String TableName;
        /// <summary>
        /// Gets the <see cref="Cell"/> with the specified row index and columnd index.
        /// </summary>
        /// <value>
        /// The <see cref="Cell"/>.
        /// </value>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="colIndex">Index of the column.</param>
        /// <returns></returns>
        public Cell this[int rowIndex, int colIndex]
        {
            get { return this.Data.FirstOrDefault(x => x.RowIndex == rowIndex && x.ColumnIndex == colIndex); }
        }
        /// <summary>
        /// The columns collection
        /// </summary>
        public List<Column> Columns;
        /// <summary>
        /// The Rows collection
        /// </summary>
        public List<Row> Rows;
        /// <summary>
        /// The table data
        /// </summary>
        public List<Cell> Data;
        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        /// <param name="tablename">The name of the table</param>
        public Table(string tablename = "")
        {
            this.Columns = new List<Column>();
            this.Rows = new List<Row>();
            this.Data = new List<Cell>();
            this.TableName = tablename;
        }
        /// <summary>
        /// Adds a new column to the table
        /// </summary>
        /// <param name="name">The name of the column, can be nameless</param>
        public void AddColumn(String name = "")
        {
            //Agregá una nueva columna
            this.Columns.Add(
                new Column()
                {
                    Index = this.Columns.Count,
                    Next = null,
                    Previous = this.Columns.Count == 0 ? null : this.Columns.LastOrDefault(),
                    Name = name,
                    Table = this
                });
            //Actualiza el contenido de la columna pasada
            if (this.Columns.Count >= 2)
                this.Columns[this.Columns.Count - 2].Next = this.Columns.LastOrDefault();
        }
        /// <summary>
        /// Adds a new row to the table
        /// </summary>
        /// <param name="name">The name of the row, can be nameless</param>
        public void AddRow(String name = "")
        {
            //Agregá una nueva columna
            this.Rows.Add(
                new Row()
                {
                    Index = this.Rows.Count,
                    Next = null,
                    Previous = this.Rows.Count == 0 ? null : this.Rows.LastOrDefault(),
                    Name = name,
                    Table = this
                });
            //Actualiza el contenido de la fila pasada
            if (this.Rows.Count >= 2)
                this.Rows[this.Columns.Count - 2].Next = this.Rows.LastOrDefault();
        }
        /// <summary>
        /// Gets the table data as string Array.
        /// </summary>
        /// <returns>The table data as String</returns>
        public string[,] DataAsString()
        {
            String[,] data = new String[this.Rows.Count, this.Rows.Count];
            for (int i = 0; i < this.Rows.Count; i++)
                for (int j = 0; j < this.Columns.Count; j++)
                    data[i, j] = this[i, j].ToString();
            return data;
        }
        /// <summary>
        /// Adds a cell to the table
        /// </summary>
        /// <param name="rowIndex">The cell row index.</param>
        /// <param name="colIndex">The cell column index.</param>
        /// <param name="data">The cell data.</param>
        public void Add(int rowIndex, int colIndex, Object data)
        {
            this.Data.Add(new Cell()
            {
                ColumnIndex = colIndex,
                RowIndex = colIndex,
                Table = this,
                Data = data,
                ColumnSpan = 0,
                RowSpan = 0
            });
        }
        /// <summary>
        /// Print the table description
        /// </summary>
        /// <returns>The table description as string</returns>
        public override string ToString()
        {
            return String.Format("Rows: {0}, Columns: {1}", this.Columns.Count(), this.Rows.Count());
        }
    }
}
