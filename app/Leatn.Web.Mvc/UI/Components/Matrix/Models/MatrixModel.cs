namespace Leatn.Web.Mvc.UI.Components.Matrix.Models
{
    #region Using Directives

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The matrix model.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public class MatrixModel<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixModel{T}"/> class.
        /// </summary>
        public MatrixModel()
        {
            this.Rows = new List<Row<T>>();
        }

        /// <summary>
        /// Gets or sets Rows.
        /// </summary>
        public IEnumerable<Row<T>> Rows { get; set; }
    }
}