namespace Leatn.Web.Mvc.UI.Components.Matrix.Renderers.Contracts
{
    using Components.Contracts;

    using Models;

    /// <summary>
    /// The grig markup renderer contract.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public interface IMatrixRenderer<T>
        where T : class
    {
        /// <summary>
        /// Gets the Output.
        /// </summary>
        IComponentOutput Output { get; }

        /// <summary>
        /// The render start tag.
        /// </summary>
        void RenderStartTag();

        /// <summary>
        /// The render end tag.
        /// </summary>
        void RenderEndTag();

        /// <summary>
        /// The render matrix.
        /// </summary>
        /// <param name="matrixModel">
        /// The matrix model.
        /// </param>
        void RenderMatrix(MatrixModel<T> matrixModel);
    }
}