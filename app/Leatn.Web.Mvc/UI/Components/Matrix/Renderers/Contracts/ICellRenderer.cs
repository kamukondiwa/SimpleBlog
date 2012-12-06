namespace Leatn.Web.Mvc.UI.Components.Matrix.Renderers.Contracts
{
    using Components.Contracts;

    using Models;

    /// <summary>
    /// The cell renderer contract.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public interface ICellRenderer<T>
    {
        /// <summary>
        /// Gets the Output.
        /// </summary>
        IComponentOutput Output { get;  }

        /// <summary>
        /// The render cell.
        /// </summary>
        /// <param name="cell">
        /// The matrix cell.
        /// </param>
        void RenderCell(Cell<T> cell);
    }
}