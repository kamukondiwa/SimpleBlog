namespace Leatn.Web.Mvc.UI.Components.Matrix
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    /// <summary>
    /// The matrix source contract.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the source element.
    /// </typeparam>
    public class MatrixSource<T>
    {
        /// <summary>
        /// The column count.
        /// </summary>
        private readonly int columnCount;

        /// <summary>
        /// The rows count.
        /// </summary>
        private readonly int rowCount;

        /// <summary>
        /// The source.
        /// </summary>
        private readonly IEnumerable<T> source;

        /// <summary>
        /// The row data.
        /// </summary>
        private readonly IList<IEnumerable<T>> rowData;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixSource{T}"/> class.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="rowCount">
        /// The row count.
        /// </param>
        /// <param name="columnCount">
        /// The column count.
        /// </param>
        public MatrixSource(IEnumerable<T> source, int rowCount, int columnCount)
        {
            this.source = source;
            this.columnCount = columnCount;
            this.rowCount = rowCount;
            this.rowData = this.GenerateRowData();
        }

        /// <summary>
        /// Gets Columns.
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return this.columnCount;
            }
        }

        /// <summary>
        /// Gets Rows.
        /// </summary>
        public int RowCount
        {
            get
            {
                return this.rowCount;
            }
        }

        /// <summary>
        /// Gets RowData.
        /// </summary>
        public IList<IEnumerable<T>> RowData
        {
            get
            {
                return this.rowData;
            }
        }

        /// <summary>
        /// Gets Source.
        /// </summary>
        public IEnumerable<T> Source
        {
            get
            {
                return this.source;
            }
        }

        /// <summary>
        /// The get row data.
        /// </summary>
        /// <returns>
        /// The row data.
        /// </returns>
        private IList<IEnumerable<T>> GenerateRowData()
        {
            var rowdata = new List<IEnumerable<T>>();

            var itemIndex = 0;

            for (var i = 0; i < this.RowCount; i++)
            {
                if (itemIndex < this.source.Count())
                {
                    var row = this.source.Skip(itemIndex).Take(this.columnCount).ToList();

                    rowdata.Add(row);
                }

                itemIndex += this.columnCount;
            }

            return rowdata;
        }
    }
}