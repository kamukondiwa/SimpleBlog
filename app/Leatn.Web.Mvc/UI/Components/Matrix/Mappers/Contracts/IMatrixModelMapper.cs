namespace Leatn.Web.Mvc.UI.Components.Matrix.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Framework.Mapper;
    using Leatn.Web.Mvc.UI.Components.Matrix.Models;

    #endregion

    /// <summary>
    /// The matrix model mapper contract.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the model element.
    /// </typeparam>
    public interface IMatrixModelMapper<T> : IMapper<MatrixSource<T>, MatrixModel<T>>
    {
    }
}