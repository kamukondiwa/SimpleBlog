namespace Leatn.Web.Mvc.UI.Components.Matrix.Mappers.Contracts
{
    #region Using Directives

    using System.Collections.Generic;

    using Leatn.Framework.Mapper;
    using Leatn.Web.Mvc.UI.Components.Matrix.Models;

    #endregion

    /// <summary>
    /// The row mapper contract.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public interface IRowMapper<T> : IMapper<IEnumerable<T>, Row<T>>
    {
    }
}