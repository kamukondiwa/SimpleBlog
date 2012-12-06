namespace Leatn.Web.Mvc.UI.Components.Matrix.Mappers
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Leatn.Framework.Mapper;
    using Leatn.Web.Mvc.UI.Components.Matrix.Mappers.Contracts;
    using Leatn.Web.Mvc.UI.Components.Matrix.Models;

    #endregion

    /// <summary>
    /// The row mapper.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public class RowMapper<T> : IRowMapper<T>
    {
        /// <summary>
        /// The cell mapper.
        /// </summary>
        private readonly ICellMapper<T> cellMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RowMapper{T}"/> class.
        /// </summary>
        /// <param name="cellMapper">
        /// The cell mapper.
        /// </param>
        public RowMapper(ICellMapper<T> cellMapper)
        {
            this.cellMapper = cellMapper;
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="cellData">
        /// The input.
        /// </param>
        /// <returns>
        /// The mapped row.
        /// </returns>
        public Row<T> MapFrom(IEnumerable<T> cellData)
        {
            return new Row<T> { Cells = cellData.ToList().MapAllUsing(this.cellMapper) };
        }
    }
}