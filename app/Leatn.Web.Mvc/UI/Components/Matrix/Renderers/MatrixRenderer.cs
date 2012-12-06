namespace Leatn.Web.Mvc.UI.Components.Matrix.Renderers
{
    using System;

    using Components.Contracts;

    using Contracts;

    using Gentax.Extensions;

    using Models;

    /// <summary>
    /// The grid markup renderer.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public class MatrixRenderer<T> : IMatrixRenderer<T>
        where T : class
    {
        /// <summary>
        /// The row renderer.
        /// </summary>
        private readonly IRowRenderer<T> rowRenderer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixRenderer{T}"/> class. 
        /// </summary>
        /// <param name="rowRenderer">
        /// The row Renderer.
        /// </param>
        public MatrixRenderer(IRowRenderer<T> rowRenderer)
        {
            this.rowRenderer = rowRenderer;
        }

        /// <summary>
        /// Gets the Output.
        /// </summary>
        public IComponentOutput Output
        {
            get
            {
                return this.rowRenderer.Output;
            }
        }

        /// <summary>
        /// The render end tag.
        /// </summary>
        public void RenderEndTag()
        {
            this.Output.Writer.Write(Environment.NewLine + "</table>");
        }

        /// <summary>
        /// The render matrix.
        /// </summary>
        /// <param name="matrixModel">
        /// The matrix model.
        /// </param>
        public void RenderMatrix(MatrixModel<T> matrixModel)
        {
            matrixModel.Rows.Each(row => this.rowRenderer.RenderRow(row));
        }

        /// <summary>
        /// The render start tag.
        /// </summary>
        public void RenderStartTag()
        {
            this.Output.Writer.Write(Environment.NewLine + "<table>");
        }
    }
}