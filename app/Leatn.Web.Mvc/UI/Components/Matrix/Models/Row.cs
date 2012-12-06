namespace Leatn.Web.Mvc.UI.Components.Matrix.Models
{
    #region Using Directives

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The matrix row.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public class Row<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Row{T}"/> class.
        /// </summary>
        public Row()
        {
            this.Cells = new List<Cell<T>>();
        }

        /// <summary>
        /// Gets or sets Cells.
        /// </summary>
        public IEnumerable<Cell<T>> Cells { get; set; }
    }
}