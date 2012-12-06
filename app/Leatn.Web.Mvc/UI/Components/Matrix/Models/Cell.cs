namespace Leatn.Web.Mvc.UI.Components.Matrix.Models
{
    /// <summary>
    /// The matrix row cell.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public class Cell<T>
    {
        /// <summary>
        /// The model.
        /// </summary>
        private readonly T model;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell{T}"/> class.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public Cell(T model)
        {
            this.model = model;
        }

        /// <summary>
        /// Gets Model.
        /// </summary>
        public T Model
        {
            get
            {
                return this.model;
            }
        }
    }
}