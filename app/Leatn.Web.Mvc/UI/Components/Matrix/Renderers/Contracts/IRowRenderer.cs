namespace Leatn.Web.Mvc.UI.Components.Matrix.Renderers.Contracts
{
    using Components.Contracts;

    using Models;

    /// <summary>
    /// The row renderer contract.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public interface IRowRenderer<T>
    {
        /// <summary>
        /// Gets the Output.
        /// </summary>
        IComponentOutput Output { get; }

        /// <summary>
        /// The render row.
        /// </summary>
        /// <param name="row">
        /// The matrix row.
        /// </param>
        void RenderRow(Row<T> row);
    }
}