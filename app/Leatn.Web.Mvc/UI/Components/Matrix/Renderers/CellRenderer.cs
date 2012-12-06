namespace Leatn.Web.Mvc.UI.Components.Matrix.Renderers
{
    #region Using Directives

    using System;
    using System.Web.Mvc;

    using Leatn.Web.Mvc.UI.Components.Contracts;
    using Leatn.Web.Mvc.UI.Components.Matrix.Models;
    using Leatn.Web.Mvc.UI.Components.Matrix.Renderers.Contracts;

    using MvcContrib.UI.Grid;

    #endregion

    /// <summary>
    /// The cell renderer.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public class CellRenderer<T> : ICellRenderer<T>
    {
        /// <summary>
        /// The output.
        /// </summary>
        private readonly IComponentOutput output;

        /// <summary>
        /// The custom item renderer.
        /// </summary>
        private readonly Action<RenderingContext, T> customItemRenderer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CellRenderer{T}"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        public CellRenderer(IComponentOutput output, Action<T> action)
        {
            this.output = output;
            this.customItemRenderer = (stringBuilder, item) => action(item);
        }

        /// <summary>
        /// Gets the CustomItemRenderer.
        /// </summary>
        public Action<RenderingContext, T> CustomItemRenderer
        {
            get
            {
                return this.customItemRenderer;
            }
        }

        /// <summary>
        /// Gets the Output.
        /// </summary>
        public IComponentOutput Output
        {
            get
            {
                return this.output;
            }
        }

        /// <summary>
        /// The render cell.
        /// </summary>
        /// <param name="cell">
        /// The matrix cell.
        /// </param>
        public void RenderCell(Cell<T> cell)
        {
            this.RenderStartTag();
            this.CustomItemRenderer(new RenderingContext(this.Output.Writer, this.Output.Context, ViewEngines.Engines), cell.Model);
            this.RenderEndTag();
        }

        /// <summary>
        /// The render end tag.
        /// </summary>
        public void RenderEndTag()
        {
            this.Output.Writer.Write(Environment.NewLine + "</td>");
        }

        /// <summary>
        /// The render start tag.
        /// </summary>
        public void RenderStartTag()
        {
            this.Output.Writer.Write(Environment.NewLine + "<td>");
        }
    }
}