namespace Leatn.Web.Mvc.UI.Components.Matrix.Renderers
{
    #region Using Directives

    using System;
    using System.IO;
    using System.Web.Mvc;

    using Leatn.Web.Mvc.UI.Components.Matrix.Renderers.Contracts;

    #endregion

    /// <summary>
    /// The matrix renderer factory.
    /// </summary>
    public static class MatrixRendererFactory
    {
        /// <summary>
        /// The get cell renderer.
        /// </summary>
        /// <param name="viewContext">
        /// The view context.
        /// </param>
        /// <param name="textWriter">
        /// The text writer.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <typeparam name="T">
        /// The model type.
        /// </typeparam>
        /// <returns>
        /// The cell renderer.
        /// </returns>
        public static ICellRenderer<T> GetCellRenderer<T>(
            ViewContext viewContext, TextWriter textWriter, Action<T> action)
        {
            var componentOutput = ComponentFactory.GetComponentOutput(viewContext, textWriter);
            return new CellRenderer<T>(componentOutput, action);
        }

        /// <summary>
        /// The get matrix renderer.
        /// </summary>
        /// <param name="viewContext">
        /// The view context.
        /// </param>
        /// <param name="textWriter">
        /// The text writer.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <typeparam name="T">
        /// The model type.
        /// </typeparam>
        /// <returns>
        /// The matrix renderer.
        /// </returns>
        public static MatrixRenderer<T> GetMatrixRenderer<T>(
            ViewContext viewContext, TextWriter textWriter, Action<T> action) where T : class
        {
            var cellRenderer = GetCellRenderer(viewContext, textWriter, action);
            var rowRenderer = GetRowRenderer(cellRenderer);
            return new MatrixRenderer<T>(rowRenderer);
        }

        /// <summary>
        /// The get row renderer.
        /// </summary>
        /// <param name="cellRenderer">
        /// The cell renderer.
        /// </param>
        /// <typeparam name="T">
        /// The model type.
        /// </typeparam>
        /// <returns>
        /// The row renderer.
        /// </returns>
        public static IRowRenderer<T> GetRowRenderer<T>(ICellRenderer<T> cellRenderer)
        {
            return new RowRenderer<T>(cellRenderer);
        }
    }
}