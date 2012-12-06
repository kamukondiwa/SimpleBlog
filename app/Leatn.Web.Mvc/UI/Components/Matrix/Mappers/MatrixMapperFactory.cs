namespace Leatn.Web.Mvc.UI.Components.Matrix.Mappers
{
    using Contracts;

    /// <summary>
    /// The matrix mapper factory.
    /// </summary>
    public static class MatrixMapperFactory
    {
        /// <summary>
        /// The get cell mapper.
        /// </summary>
        /// <typeparam name="T">
        /// The model type.
        /// </typeparam>
        /// <returns>
        /// The cell mapper.
        /// </returns>
        public static ICellMapper<T> GetCellMapper<T>()
        {
            return new CellMapper<T>();
        }

        /// <summary>
        /// The get matrix model mapper.
        /// </summary>
        /// <typeparam name="T">
        /// The model type.
        /// </typeparam>
        /// <returns>
        /// The matrix model mapper.
        /// </returns>
        public static IMatrixModelMapper<T> GetMatrixModelMapper<T>()
        {
            return new MatrixModelMapper<T>(GetRowMapper<T>());
        }

        /// <summary>
        /// The get row mapper.
        /// </summary>
        /// <typeparam name="T">
        /// The model type.
        /// </typeparam>
        /// <returns>
        /// The row mapper.
        /// </returns>
        public static IRowMapper<T> GetRowMapper<T>()
        {
            return new RowMapper<T>(GetCellMapper<T>());
        }
    }
}