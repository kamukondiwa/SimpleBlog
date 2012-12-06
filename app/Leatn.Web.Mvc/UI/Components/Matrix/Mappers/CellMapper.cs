namespace Leatn.Web.Mvc.UI.Components.Matrix.Mappers
{
    #region Using Directives

    using Leatn.Web.Mvc.UI.Components.Matrix.Mappers.Contracts;
    using Leatn.Web.Mvc.UI.Components.Matrix.Models;

    #endregion

    /// <summary>
    /// The cell mapper.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public class CellMapper<T> : ICellMapper<T>
    {
        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="cellData">
        /// The input.
        /// </param>
        /// <returns>
        /// The mapped type.
        /// </returns>
        public Cell<T> MapFrom(T cellData)
        {
            return new Cell<T>(cellData);
        }
    }
}