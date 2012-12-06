namespace Leatn.Web.Mvc.UI.Components.Matrix.Renderers
{
    using System;

    using Components.Contracts;

    using Contracts;

    using Gentax.Extensions;

    using Models;

    /// <summary>
    /// The row renderer.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public class RowRenderer<T> : IRowRenderer<T>
    {
        /// <summary>
        /// The cell renderer.
        /// </summary>
        private readonly ICellRenderer<T> cellRenderer;

        /// <summary>
        /// Initializes a new instance of the <see cref="RowRenderer{T}"/> class.
        /// </summary>
        /// <param name="cellRenderer">
        /// The cell Renderer.
        /// </param>
        public RowRenderer(ICellRenderer<T> cellRenderer)
        {
            this.cellRenderer = cellRenderer;
        }

        /// <summary>
        /// Gets the Output.
        /// </summary>
        public IComponentOutput Output
        {
            get
            {
                return this.cellRenderer.Output;
            }
        }

        /// <summary>
        /// The render end tag.
        /// </summary>
        public void RenderEndTag()
        {
            this.cellRenderer.Output.Writer.Write(Environment.NewLine + "</tr>");
        }

        /// <summary>
        /// The render row.
        /// </summary>
        /// <param name="row">
        /// The matrix row.
        /// </param>
        public void RenderRow(Row<T> row)
        {
            this.RenderStartTag();
            row.Cells.Each(cell => this.cellRenderer.RenderCell(cell));
            this.RenderEndTag();
        }

        /// <summary>
        /// The render start tag.
        /// </summary>
        public void RenderStartTag()
        {
            this.cellRenderer.Output.Writer.Write(Environment.NewLine + "<tr>");
        }
    }
}