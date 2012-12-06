namespace Leatn.Web.Mvc.UI.Components.Matrix.Mappers
{
    #region Using Directives

    using Framework.Mapper;

    using Leatn.Web.Mvc.UI.Components.Matrix.Mappers.Contracts;
    using Leatn.Web.Mvc.UI.Components.Matrix.Models;

    #endregion

    /// <summary>
    /// The matrix model mapper.
    /// </summary>
    /// <typeparam name="T">
    /// The model element type.
    /// </typeparam>
    public class MatrixModelMapper<T> : IMatrixModelMapper<T>
    {
        /// <summary>
        /// The row mapper.
        /// </summary>
        private readonly IRowMapper<T> rowMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixModelMapper{T}"/> class.
        /// </summary>
        /// <param name="rowMapper">
        /// The row mapper.
        /// </param>
        public MatrixModelMapper(IRowMapper<T> rowMapper)
        {
            this.rowMapper = rowMapper;
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="matrixSource">
        /// The input.
        /// </param>
        /// <returns>
        /// The mapped matrix model.
        /// </returns>
        public MatrixModel<T> MapFrom(MatrixSource<T> matrixSource)
        {
            return new MatrixModel<T> { Rows = matrixSource.RowData.MapAllUsing(this.rowMapper) };
        }
    }
}